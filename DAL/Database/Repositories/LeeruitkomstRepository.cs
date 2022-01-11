using AutoMapper;
using DAL.Database.Context;
using DAL.Entities;
using LOGIC.Interfaces.Repositories;
using LOGIC.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace DAL.Database.Repositories
{
    public class LeeruitkomstRepository : ILeeruitkomstRepository
    {
        public readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public LeeruitkomstRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        private async Task<LeeruitkomstEntity> FindById(int id)
        {
            return await _dbContext.Leeruitkomsten.FirstAsync(x => x.Id == id);
        }

        public async Task<Leeruitkomst> Create(Leeruitkomst leeruitkomst)
        {
            LeeruitkomstEntity leeruitkomstEntity = _mapper.Map<LeeruitkomstEntity>(leeruitkomst);
            await _dbContext.AddAsync(leeruitkomstEntity);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Leeruitkomst>(leeruitkomstEntity);
        }

        public async Task<Leeruitkomst> Read(int id)
        {
            LeeruitkomstEntity leeruitkomstEntity = await FindById(id);
            return _mapper.Map<Leeruitkomst>(leeruitkomstEntity);
        }

        public async Task<Leeruitkomst> Update(Leeruitkomst leeruitkomst, int id)
        {
            LeeruitkomstEntity leeruitkomstEntity = await FindById(id);
            if (leeruitkomstEntity != null)
            {
                leeruitkomstEntity.Naam = leeruitkomst.Naam;
                leeruitkomstEntity.Beschrijving = leeruitkomst.Beschrijving;
                await _dbContext.SaveChangesAsync();
            }
            return _mapper.Map<Leeruitkomst>(leeruitkomstEntity);
        }

        public async Task<bool> Delete(int id)
        {
            LeeruitkomstEntity leeruitkomstEntity = await FindById(id);
            if (leeruitkomstEntity != null)
            {
                _dbContext.Remove(leeruitkomstEntity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
