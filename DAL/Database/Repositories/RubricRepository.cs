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
    public class RubricRepository : IRubricRepository
    {
        public readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public RubricRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        private async Task<RubricEntity> FindById(int id)
        {
            return await _dbContext.Rubrics
                .Include(t => t.Beoordelingscriteria)
                .FirstAsync(x => x.Id == id);
        }

        public async Task<Rubric> Create(Rubric rubric)
        {
            RubricEntity rubricEntity = _mapper.Map<RubricEntity>(rubric);
            await _dbContext.Rubrics.AddAsync(rubricEntity);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Rubric>(rubricEntity);
        }

        public async Task<Rubric> Read(int id)
        {
            RubricEntity rubricEntity = await FindById(id);
            return _mapper.Map<Rubric>(rubricEntity);
        }

        public async Task<Rubric> Update(int id, Rubric rubric)
        {
            RubricEntity rubricEntity = await FindById(id);
            if (rubricEntity != null)
            {
                rubricEntity.Code = rubric.Code;
                rubricEntity.Naam = rubric.Naam;
                rubricEntity.Weging = rubric.Weging;
                rubricEntity.MinimaalOordeel = rubric.MinimaalOordeel;
                rubricEntity.Beschrijving = rubric.Beschrijving;
                rubricEntity.Beoordelingscriteria = _mapper.Map<List<RubricCriteriumEntity>>(rubric.Beoordelingscriteria);
                await _dbContext.SaveChangesAsync();
            }
            return _mapper.Map<Rubric>(rubricEntity);
        }

        public async Task<bool> Delete(int id)
        {
            RubricEntity rubricEntity = await FindById(id);
            if (rubricEntity != null)
            {
                _dbContext.Remove(rubricEntity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}
