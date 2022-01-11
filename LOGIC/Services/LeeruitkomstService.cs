using LOGIC.Interfaces.Repositories;
using LOGIC.Interfaces.Services;
using LOGIC.Models;
using System;
using System.Threading.Tasks;

namespace LOGIC.Services
{

    public class LeeruitkomstService : ILeeruitkomstService
    {
        private readonly ILeeruitkomstRepository _repository;

        public LeeruitkomstService(ILeeruitkomstRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultObject<Leeruitkomst>> CreateLeeruitkomst(Leeruitkomst leeruitkomst)
        {
            ResultObject<Leeruitkomst> result = new();
            try
            {
                result.ResultSet = await _repository.Create(leeruitkomst);
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.Message = "Failed to add Leeruitkomst.";
            }
            return result;
        }

        public async Task<ResultObject<Leeruitkomst>> ReadLeeruitkomst(int id)
        {
            ResultObject<Leeruitkomst> result = new();
            try
            {
                result.ResultSet = await _repository.Read(id);
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.Message = "Failed to get Leeruitkomst.";
            }
            return result;
        }

        public async Task<ResultObject<Leeruitkomst>> UpdateLeeruitkomst(int id, Leeruitkomst leeruitkomst)
        {
            ResultObject<Leeruitkomst> result = new();
            try
            {
                result.ResultSet = await _repository.Update(leeruitkomst, id);
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.Message = "Failed to update Leeruitkomst.";
            }
            return result;
        }

        public async Task<ResultObject<bool>> DeleteLeeruitkomst(int id)
        {
            ResultObject<bool> result = new();
            try
            {
                bool isDeleted = await _repository.Delete(id);
                result.Message = "Succesfully deleted Leeruitkomst.";
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.Message = "Failed to delete Leeruitkomst.";
            }
            return result;
        }

    }
}
