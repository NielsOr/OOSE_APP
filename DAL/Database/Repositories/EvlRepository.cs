using AutoMapper;
using DAL.Database.Context;
using DAL.Entities;
using LOGIC.Interfaces.Repositories;
using LOGIC.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Database.Repositories
{
    public class EvlRepository : IEvlRepository
    {
        public readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public EvlRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        private async Task<EvlEntity> FindById(int id)
        {
            return await _dbContext.Evls
                .Include(evl => evl.Eindkwalificaties)
                .Include(evl => evl.Leeruitkomsten)
                .Include(evl => evl.Tentamineringen)
                .ThenInclude(tentamineringen => tentamineringen.Leeruitkomsten)
                .Include(evl => evl.Tentamineringen)
                .ThenInclude(tentamineringen => tentamineringen.Rubrics)
                .ThenInclude(rubrics => rubrics.Beoordelingscriteria)
                .FirstAsync(x => x.Id == id);
        }

        public async Task<Evl> Create(Evl evl)
        {
            EvlEntity evlEntity = _mapper.Map<EvlEntity>(evl);
            await _dbContext.AddAsync(evlEntity);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Evl>(evlEntity);
        }

        public async Task<Evl> Read(int id)
        {
            EvlEntity evlEntity = await FindById(id);
            return _mapper.Map<Evl>(evlEntity);
        }

        public async Task<Evl> Update(int id, Evl evl)
        {
            EvlEntity evlEntity = await FindById(id);
            if (evlEntity != null)
            {
                evlEntity.Code = evl.Code;
                evlEntity.Naam = evl.Naam;
                evlEntity.Beschrijving = evl.Beschrijving;
                evlEntity.Studiepunten = evl.Studiepunten;
                evlEntity.Beroepstaken = evl.Beroepstaken;
                evlEntity.Eindkwalificaties = _mapper.Map<List<EindkwalificatieEntity>>(evl.Eindkwalificaties);
                evlEntity.Leeruitkomsten = _mapper.Map<List<LeeruitkomstEntity>>(evl.Leeruitkomsten);
                evlEntity.Tentamineringen = _mapper.Map<List<TentamineringEntity>>(evl.Tentamineringen);
                await _dbContext.SaveChangesAsync();
            }
            return _mapper.Map<Evl>(evlEntity);
        }

        public async Task<bool> Delete(int id)
        {
            EvlEntity evlEntity = await FindById(id);
            if (evlEntity != null)
            {
                _dbContext.Remove(evlEntity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Evl>> ReadAll()
        {
            List<EvlEntity> evlEntities = await _dbContext.Evls.FromSqlRaw("SELECT * From evl Where Discriminator = 'EvlEntity'").ToListAsync();
            return _mapper.Map<List<Evl>>(evlEntities);
        }

        public async Task<List<EvlRevisie>> GetRevisiesByEvlId(int id)
        {
            List<EvlRevisieEntity> evlRevisieEntities = await _dbContext.EvlRevisies.Where(revisie => revisie.EvlId == id).ToListAsync();
            return _mapper.Map<List<EvlRevisie>>(evlRevisieEntities);
        }

        public async Task<EvlRevisie> CreateRevisie(int id)
        {
            EvlEntity evl = await FindById(id);
            EvlRevisieEntity revisie = CreateEvlRevisie(evl);
            await _dbContext.AddAsync(revisie);
            await _dbContext.SaveChangesAsync();
            revisie.Tentamineringen = AddRevisieTentamineringen(evl.Tentamineringen, revisie.Leeruitkomsten);
            return _mapper.Map<EvlRevisie>(revisie);
        }

        private EvlRevisieEntity CreateEvlRevisie(EvlEntity evl)
        {
            return new EvlRevisieEntity()
            {
                EvlId = evl.Id,
                ModifiedBy = "Test",
                ModifiedDate = System.DateTime.Now,
                Code = evl.Code,
                Naam = evl.Naam,
                Beschrijving = evl.Beschrijving,
                Studiepunten = evl.Studiepunten,
                Beroepstaken = evl.Beroepstaken,
                Leeruitkomsten = AddRevisieLeeruitkomsten(evl.Leeruitkomsten),
                Eindkwalificaties = AddRevisieEindkwalificaties(evl.Eindkwalificaties)
            };
        }


        private List<EindkwalificatieEntity> AddRevisieEindkwalificaties(IEnumerable<EindkwalificatieEntity> eindkwalificaties)
        {
            return eindkwalificaties.Select(x => new EindkwalificatieEntity
            {
                Beschrijving = x.Beschrijving
            }).ToList();
        }


        private List<LeeruitkomstEntity> AddRevisieLeeruitkomsten(IEnumerable<LeeruitkomstEntity> leeruitkomsten)
        {
            return leeruitkomsten.Select(x => new LeeruitkomstEntity
            {
                Naam = x.Naam,
                Beschrijving = x.Beschrijving
            }).ToList();
        }


        private List<TentamineringEntity> AddRevisieTentamineringen(IEnumerable<TentamineringEntity> tentamineringen, IEnumerable<LeeruitkomstEntity> leeruitkomsten)
        {
            List<TentamineringEntity> revisieTentamineringen = tentamineringen.Select(tentaminering => new TentamineringEntity
            {
                Naam = tentaminering.Naam,
                Code = tentaminering.Code,
                Aanmeldingstype = tentaminering.Aanmeldingstype,
                Hulpmiddelen = tentaminering.Hulpmiddelen,
                Weging = tentaminering.Weging,
                MinimaalOordeel = tentaminering.MinimaalOordeel,
                Tentamenvorm = tentaminering.Tentamenvorm,
                Rubrics = AddRevisieRubrics(tentaminering.Rubrics),
                Leeruitkomsten = AddRevisieTentamineringLeeruitkomsten(tentaminering.Leeruitkomsten, leeruitkomsten),
            }).ToList();
            return revisieTentamineringen;
        }


        private List<TentamineringLeeruitkomstEntity> AddRevisieTentamineringLeeruitkomsten(IEnumerable<TentamineringLeeruitkomstEntity> tentamineringLeeruitkomsten, IEnumerable<LeeruitkomstEntity> leeruitkomsten)
        {
            return tentamineringLeeruitkomsten.Select(tentamineringLeeruitkomst => new TentamineringLeeruitkomstEntity
            {
                Beoordelingcriteria = tentamineringLeeruitkomst.Beoordelingcriteria,
                LeeruitkomstId = leeruitkomsten.Where(x => x.Naam == tentamineringLeeruitkomst.Leeruitkomst.Naam).Select(x => x.Id).First()
            }).ToList();
        }


        private List<RubricEntity> AddRevisieRubrics(IEnumerable<RubricEntity> rubrics)
        {
            return rubrics.Select(rubric => new RubricEntity
            {
                Naam = rubric.Naam,
                Code = rubric.Code,
                Weging = rubric.Weging,
                MinimaalOordeel = rubric.MinimaalOordeel,
                Beschrijving = rubric.Beschrijving,
                Beoordelingscriteria = AddRevisieRubricCriteria(rubric.Beoordelingscriteria)
            }).ToList();
        }

        private List<RubricCriteriumEntity> AddRevisieRubricCriteria(IEnumerable<RubricCriteriumEntity> rubrics)
        {
            return rubrics.Select(rubric => new RubricCriteriumEntity
            {
                Oordeel = rubric.Oordeel,
                Beschrijving = rubric.Beschrijving
            }).ToList();
        }
    }
}
