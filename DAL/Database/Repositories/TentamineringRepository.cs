using AutoMapper;
using DAL.Database.Context;
using DAL.Entities;
using LOGIC.Interfaces.Repositories;
using LOGIC.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DAL.Database.Repositories
{
    public class TentamineringRepository : ITentamineringRepository
    {
        public readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public TentamineringRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        private async Task<TentamineringEntity> FindById(int id)
        {
            return await _dbContext.Tentamineringen
                .Include(t => t.Leeruitkomsten)
                .Include(t => t.Rubrics)
                .ThenInclude(rubrics => rubrics.Beoordelingscriteria)
                .FirstAsync(x => x.Id == id);
        }

        public async Task<Tentaminering> Create(Tentaminering tentaminering)
        {
            TentamineringEntity tentamineringEntity = _mapper.Map<TentamineringEntity>(tentaminering);
            await _dbContext.AddAsync(tentamineringEntity);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Tentaminering>(tentamineringEntity);
        }

        public async Task<Tentaminering> Read(int id)
        {
            TentamineringEntity tentamineringEntity = await FindById(id);
            return _mapper.Map<Tentaminering>(tentamineringEntity);
        }

        public async Task<Tentaminering> Update(int id, Tentaminering tentaminering)
        {
            TentamineringEntity tentamineringEntity = await FindById(id);
            if (tentamineringEntity != null)
            {
                tentamineringEntity.Code = tentaminering.Code;
                tentamineringEntity.Naam = tentaminering.Naam;
                tentamineringEntity.Aanmeldingstype = tentaminering.Aanmeldingstype;
                tentamineringEntity.Hulpmiddelen = tentaminering.Hulpmiddelen;
                tentamineringEntity.Weging = tentaminering.Weging;
                tentamineringEntity.MinimaalOordeel = tentaminering.MinimaalOordeel;
                tentamineringEntity.Tentamenvorm = tentaminering.Tentamenvorm;
                tentamineringEntity.Leeruitkomsten = _mapper.Map<List<TentamineringLeeruitkomstEntity>>(tentaminering.Leeruitkomsten);
                tentamineringEntity.Rubrics = _mapper.Map<List<RubricEntity>>(tentaminering.Rubrics);
                await _dbContext.SaveChangesAsync();
            }
            return _mapper.Map<Tentaminering>(tentamineringEntity);
        }

        public async Task<bool> Delete(int id)
        {
            TentamineringEntity tentamineringEntity = await FindById(id);
            if (tentamineringEntity != null)
            {
                _dbContext.Remove(tentamineringEntity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}
