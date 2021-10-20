using LOGIC.Interfaces;
using LOGIC.Models;
using System;
using System.Threading.Tasks;

namespace LOGIC.Services
{
    /// <summary>
    /// This service allows us to Add, Fetch and Update Leeruitkomst Data
    /// </summary>
    public class LeeruitkomstService : ILeeruitkomstService
    {
        private readonly IRepository _repository;

        public LeeruitkomstService(IRepository repository)
        {
            _repository = repository;
        }

        //Add Leeruitkomst Entiteit in de database
        //Indien geslaagd: geef ResultObject met Leeruitkomst en succesmelding terug aan de controller
        //Indien mislukt: geef ResultObject met errormelding terug aan de controller
        public async Task<ResultObject<Leeruitkomst>> AddLeeruitkomst(int evlId, string naam, string beschrijving)
        {
            ResultObject<Leeruitkomst> result = new();
            try
            {
                Leeruitkomst leeruitkomst = new() { Naam = naam, EvlId = evlId, Beschrijving = beschrijving };
                leeruitkomst = await _repository.Create(leeruitkomst);
                result.UserMessage = $"Leeruitkomst {leeruitkomst.Naam} added successfully";
                result.InternalMessage = "LeeruitkomstService: AddLeeruitkomst() method executed successfully.";
                result.ResultSet = leeruitkomst;
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.UserMessage = "Failed to add Leeruitkomst.";
                result.InternalMessage = $"ERROR: LeeruitkomstService: AddLeeruitkomst(): {exception.Message}";
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
                result.UserMessage = $"Leeruitkomst {leeruitkomst.Naam} found successfully";
                result.InternalMessage = "LeeruitkomstService: GetLeeruitkomstById() method executed successfully.";
                result.ResultSet = leeruitkomst;
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.UserMessage = "Failed to get Leeruitkomst.";
                result.InternalMessage = $"ERROR: LeeruitkomstService: GetLeeruitkomstById(): {exception.Message}";
            }
            return result;
        }

        //update Leeruitkomst Entiteit in de database
        //Indien geslaagd: geef ResultObject met Leeruitkomst en succesmelding terug aan de controller
        //Indien mislukt: geef ResultObject met errormelding terug aan de controller
        public async Task<ResultObject<Leeruitkomst>> UpdateLeeruitkomst(int leeruitkomstId, string naam, string beschrijving)
        {
            ResultObject<Leeruitkomst> result = new();
            try
            {
                Leeruitkomst leeruitkomst = await _repository.Read<Leeruitkomst>(leeruitkomstId);
                leeruitkomst.Naam = naam;
                leeruitkomst.Beschrijving = beschrijving;
                leeruitkomst = await _repository.Update(leeruitkomst, leeruitkomstId);
                result.UserMessage = $"Leeruitkomst {leeruitkomst.Naam} updated successfully";
                result.InternalMessage = "LeeruitkomstService: UpdateLeeruitkomst() method executed successfully.";
                result.ResultSet = leeruitkomst;
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.UserMessage = "Failed to update Leeruitkomst.";
                result.InternalMessage = $"ERROR: LeeruitkomstService: UpdateLeeruitkomst(): {exception.Message}";
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
                result.UserMessage = $"Leeruitkomst deleted successfully";
                result.InternalMessage = "LeeruitkomstService: DeleteLeeruitkomst() method executed successfully.";
                result.ResultSet = null;
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.UserMessage = "Failed to delete Leeruitkomst.";
                result.InternalMessage = $"ERROR: LeeruitkomstService: DeleteLeeruitkomst(): {exception.Message}";
            }
            return result;
        }
    }
}
