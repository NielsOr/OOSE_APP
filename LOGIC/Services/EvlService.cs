using LOGIC.Interfaces;
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
        private readonly IRepository _repository;

        public EvlService(IRepository repository)
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
                result.UserMessage = "list of EVLs found successfully";
                result.InternalMessage = "EvlService: GetEvls() method executed successfully.";
                result.ResultSet = evls;
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.UserMessage = "failed to retrieve list of EVLs.";
                result.InternalMessage = $"ERROR: EvlService: GetEvls(): {exception.Message}";
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
                Evl evl = await _repository.Read<Evl>(id);
                result.UserMessage = $"EVL {evl.Naam} found successfully";
                result.InternalMessage = "EvlService: GetEvlById() method executed successfully.";
                result.ResultSet = evl;
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.UserMessage = "failed to find the EVL.";
                result.InternalMessage = $"ERROR: EvlService: GetEvlById(): {exception.Message}";
            }
            return result;
        }

        //add Evl aan de database
        //Indien geslaagd: geef ResultObject met Evl en succesmelding terug aan de controller
        //Indien mislukt: geef ResultObject met errormelding terug aan de controller
        public async Task<ResultObject<Evl>> AddEvl(string code, string naam, string beroepstaken, string eindkwalificaties, string beschrijving, double studiepunten)
        {
            ResultObject<Evl> result = new();
            try
            {
                Evl evl = new()
                {
                    Code = code,
                    Naam = naam,
                    Beroepstaken = beroepstaken,
                    Eindkwalificaties = eindkwalificaties,
                    Beschrijving = beschrijving,
                    Studiepunten = studiepunten,
                };
                evl = await _repository.Create(evl);
                result.UserMessage = $"EVL {evl.Naam} added successfully";
                result.InternalMessage = "EvlService: AddEvl() method executed successfully.";
                result.ResultSet = evl;
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.UserMessage = "failed to add the EVL.";
                result.InternalMessage = $"ERROR: EvlService: AddEvl(): {exception.Message}";
            }
            return result;
        }

        //update Evl in de database
        //Indien geslaagd: geef ResultObject met Evl en succesmelding terug aan de controller
        //Indien mislukt: geef ResultObject met errormelding terug aan de controller
        public async Task<ResultObject<Evl>> UpdateEvl(int id, string code, string naam, string beroepstaken, string eindkwalificaties, string beschrijving, double studiepunten)
        {
            ResultObject<Evl> result = new();
            try
            {
                Evl evl = new()
                {
                    Id = id,
                    Code = code,
                    Naam = naam,
                    Beroepstaken = beroepstaken,
                    Eindkwalificaties = eindkwalificaties,
                    Beschrijving = beschrijving,
                    Studiepunten = studiepunten,
                };
                evl = await _repository.Update(evl, id);
                result.UserMessage = $"EVL {evl.Naam} updated successfully";
                result.InternalMessage = "EvlService: UpdateEvl() method executed successfully.";
                result.ResultSet = evl;
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.UserMessage = "failed to update the EVL.";
                result.InternalMessage = $"ERROR: EvlService: UpdateEvl(): {exception.Message}";
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
                result.UserMessage = $"EVL deleted successfully";
                result.InternalMessage = "EvlService: DeleteEvl() method executed successfully.";
                result.ResultSet = null;
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.UserMessage = "failed to delete the EVL.";
                result.InternalMessage = $"ERROR: EvlService: DeleteEvl(): {exception.Message}";
            }
            return result;
        }
    }
}
