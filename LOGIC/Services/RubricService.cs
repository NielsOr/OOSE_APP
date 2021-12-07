using LOGIC.Interfaces;
using LOGIC.Interfaces.Repositories;
using LOGIC.Interfaces.Services;
using LOGIC.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services
{
    public class RubricService : IRubricService
    {
        private readonly IRubricRepository _repository;

        public RubricService(IRubricRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultObject<Rubric>> CreateRubric(Rubric rubric)
        {
            ResultObject<Rubric> result = new();
            try
            {
                result.ResultSet = await _repository.Create(rubric);
                result.Message = "Succesfully added Rubric.";
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.Message = "Failed to add Rubric.";
            }
            return result;
        }

        public async Task<ResultObject<Rubric>> ReadRubric(int id)
        {
            ResultObject<Rubric> result = new();
            try
            {
                result.ResultSet = await _repository.Read(id);
                result.Message = "Succesfully read Rubric.";
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.Message = "Failed to read Rubric.";
            }
            return result;
        }
       
        public async Task<ResultObject<Rubric>> UpdateRubric(int id, Rubric rubric)
        {
            ResultObject<Rubric> result = new();
            try
            {
                result.ResultSet = await _repository.Update(id, rubric);
                result.Message = "Succesfully updated Rubric.";
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.Message = "Failed to update Rubric.";
            }
            return result;
        }

        public async Task<ResultObject<bool>> DeleteRubric(int id)
        {
            ResultObject<bool> result = new();
            try
            {
                bool isDeleted = await _repository.Delete(id);
                result.Message = "Succesfully deleted Rubric.";
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception; 
                result.Message = "Failed to delete Rubric.";
            }
            return result;
        }

    }
}
