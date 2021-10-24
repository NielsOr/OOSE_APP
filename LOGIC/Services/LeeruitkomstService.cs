using LOGIC.Interfaces;
using LOGIC.Interfaces.Services;
using LOGIC.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services
{
    /// <summary>
    /// This service allows us to Add, Fetch and Update Leeruitkomst Data
    /// </summary>
    public class LeeruitkomstService : ILeeruitkomstService
    {
        private readonly ILeeruitkomstRepository _repository;

        public LeeruitkomstService(ILeeruitkomstRepository repository)
        {
            _repository = repository;
        }

        //Add Leeruitkomst Entiteit in de database
        //Indien geslaagd: geef ResultObject met Leeruitkomst en succesmelding terug aan de controller
        //Indien mislukt: geef ResultObject met errormelding terug aan de controller
        public async Task<ResultObject<Leeruitkomst>> AddLeeruitkomst(Leeruitkomst leeruitkomst)
        {
            ResultObject<Leeruitkomst> result = new();
            try
            {
                leeruitkomst = await _repository.Create(leeruitkomst);
                result.ResultSet = leeruitkomst;
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.Message = "Failed to add Leeruitkomst.";
            }
            return result;
        }

        //get Leeruitkomst Entity from the database
        //Indien geslaagd: geef ResultObject met Leeruitkomst en succesmelding terug aan de controller
        //Indien mislukt: geef ResultObject met errormelding terug aan de controller
        public async Task<ResultObject<Leeruitkomst>> GetLeeruitkomstById(int leeruitkomstId)
        {
            ResultObject<Leeruitkomst> result = new();
            try
            {
                Leeruitkomst leeruitkomst = await _repository.Read<Leeruitkomst>(leeruitkomstId);
                result.ResultSet = leeruitkomst;
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.Message = "Failed to get Leeruitkomst.";
            }
            return result;
        }


        public async Task<ResultObject<List<Leeruitkomst>>> GetLeeruitkomstenByEvlId(int evlId)
        {
            ResultObject<List<Leeruitkomst>> result = new();
            try
            {
                List<Leeruitkomst> leeruitkomsten = await _repository.GetLeeruitkomstenByEvlId(evlId);
                result.ResultSet = leeruitkomsten;
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.Message = "failed to find the EVL.";
            }
            return result;
        }


        //update Leeruitkomst Entiteit in de database
        //Indien geslaagd: geef ResultObject met Leeruitkomst en succesmelding terug aan de controller
        //Indien mislukt: geef ResultObject met errormelding terug aan de controller
        public async Task<ResultObject<Leeruitkomst>> UpdateLeeruitkomst(Leeruitkomst leeruitkomst)
        {
            ResultObject<Leeruitkomst> result = new();
            try
            {
                Leeruitkomst existingLeeruitkomst = await _repository.Read<Leeruitkomst>(leeruitkomst.Id);
                existingLeeruitkomst.Naam = leeruitkomst.Naam;
                existingLeeruitkomst.Beschrijving = leeruitkomst.Beschrijving;
                leeruitkomst = await _repository.Update(existingLeeruitkomst, existingLeeruitkomst.Id);
                result.ResultSet = existingLeeruitkomst;
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.Message = "Failed to update Leeruitkomst.";
            }
            return result;
        }

        //Delete Leeruitkomst Entiteit in de database
        //Indien geslaagd: geef ResultObject met succesmelding terug aan de controller
        //Indien mislukt: geef ResultObject met errormelding terug aan de controller
        public async Task<ResultObject<Leeruitkomst>> DeleteLeeruitkomst(int id)
        {
            ResultObject<Leeruitkomst> result = new();
            try
            {
                bool isDeleted = await _repository.Delete<Leeruitkomst>(id);
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
