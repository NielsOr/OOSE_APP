using LOGIC.Interfaces;
using LOGIC.Interfaces.Services;
using LOGIC.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services
{
    /// <summary>
    /// This service allows us to Add, Get and Update Applicant Data
    /// </summary>
    public class EvlService : IEvlService
    {
        private readonly IEvlRepository _repository;

        public EvlService(IEvlRepository repository)
        {
            _repository = repository;
        }

        //get alle Evls uit de database
        //Indien geslaagd: geef ResultObject met List<Evl> en succesmelding terug aan de controller
        //Indien mislukt: geef ResultObject met errormelding terug aan de controller
        public async Task<ResultObject<List<Evl>>> GetEvls()
        {
            ResultObject<List<Evl>> result = new();
            try
            {
                List<Evl> evls = await _repository.ReadAll<Evl>();
                result.ResultSet = evls;
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.Message = "failed to retrieve list of EVLs.";
            }
            return result;
        }

        //get Evl uit de database
        //Indien geslaagd: geef ResultObject met Evl en succesmelding terug aan de controller
        //Indien mislukt: geef ResultObject met errormelding terug aan de controller
        public async Task<ResultObject<Evl>> GetEvlById(int id)
        {
            ResultObject<Evl> result = new();
            try
            {
                Evl evl = await _repository.GetEvlById(id);
                result.ResultSet = evl;
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.Message = "failed to find the EVL.";
            }
            return result;
        }

        
        //add Evl aan de database
        //Indien geslaagd: geef ResultObject met Evl en succesmelding terug aan de controller
        //Indien mislukt: geef ResultObject met errormelding terug aan de controller
        public async Task<ResultObject<Evl>> AddEvl(Evl evl)
        {
            ResultObject<Evl> result = new();
            try
            {
                evl = await _repository.Create(evl);
                result.ResultSet = evl;
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.Message = "failed to add the EVL.";
            }
            return result;
        }

        //update Evl in de database
        //Indien geslaagd: geef ResultObject met Evl en succesmelding terug aan de controller
        //Indien mislukt: geef ResultObject met errormelding terug aan de controller
        public async Task<ResultObject<Evl>> UpdateEvl(Evl evl)
        {
            ResultObject<Evl> result = new();
            try
            {
                evl = await _repository.Update(evl, evl.Id);
                result.ResultSet = evl;
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.Message = "failed to update the EVL.";
            }
            return result;
        }

        //Delete Evl Entiteit in de database
        //Indien geslaagd: geef ResultObject met succesmelding terug aan de controller
        //Indien mislukt: geef ResultObject met errormelding terug aan de controller
        public async Task<ResultObject<Evl>> DeleteEvl(int id)
        {
            ResultObject<Evl> result = new();
            try
            {
                bool isDeleted = await _repository.Delete<Evl>(id);
                result.Message = "Succesfully deleted EVL.";
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.Message = "failed to delete the EVL.";
            }
            return result;
        }


    }
}
