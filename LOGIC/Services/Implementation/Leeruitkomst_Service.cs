using DAL.Entities;
using DAL.Functions.Crud;
using LOGIC.Interfaces;
using LOGIC.Models;
using System;
using System.Threading.Tasks;

namespace LOGIC.Implementation
{
    /// <summary>
    /// This service allows us to Add, Fetch and Update Leeruitkomst Data
    /// </summary>
    public class Leeruitkomst_Service : ILeeruitkomst_Service
    {
        private ICRUD _crud = new CRUD();

        //Add Leeruitkomst Entiteit in de database
        //Indien geslaagd: geef ResultObject met LeeruitkomstModel en succesmelding terug aan de controller
        //Indien mislukt: geef ResultObject met errormelding terug aan de controller
        public async Task<ResultObject<LeeruitkomstModel>> AddLeeruitkomst(int evlId, string naam, string beschrijving)
        {
            ResultObject<LeeruitkomstModel> result = new ResultObject<LeeruitkomstModel>();
            try
            {
                Evl evl = await _crud.Read<Evl>(evlId);
                Leeruitkomst leeruitkomst = new Leeruitkomst { Naam = naam, Evl = evl, Beschrijving = beschrijving };
                leeruitkomst = await _crud.Create<Leeruitkomst>(leeruitkomst);
                LeeruitkomstModel leeruitkomstModel = new LeeruitkomstModel { Id = leeruitkomst.Id, Naam = leeruitkomst.Naam, Beschrijving = leeruitkomst.Beschrijving };
                result.userMessage = $"Leeruitkomst {leeruitkomstModel.Naam} added successfully";
                result.internalMessage = "Leeruitkomst_Service: AddLeeruitkomst() method executed successfully.";
                result.result_set = leeruitkomstModel;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to add Leeruitkomst.";
                result.internalMessage = $"ERROR: Leeruitkomst_Service: AddLeeruitkomst(): {exception.Message}";
            }
            return result;
        }

        //get Leeruitkomst Entity from the database
        //Indien geslaagd: geef ResultObject met LeeruitkomstModel en succesmelding terug aan de controller
        //Indien mislukt: geef ResultObject met errormelding terug aan de controller
        public async Task<ResultObject<LeeruitkomstModel>> GetLeeruitkomstById(int leeruitkomstId)
        {
            ResultObject<LeeruitkomstModel> result = new ResultObject<LeeruitkomstModel>();
            try
            { 
                Leeruitkomst leeruitkomst = await _crud.Read<Leeruitkomst>(leeruitkomstId);
                LeeruitkomstModel leeruitkomstModel = new LeeruitkomstModel { Id = leeruitkomst.Id, Naam = leeruitkomst.Naam, Beschrijving = leeruitkomst.Beschrijving };
                result.userMessage = $"Leeruitkomst {leeruitkomstModel.Naam} found successfully";
                result.internalMessage = "Leeruitkomst_Service: GetLeeruitkomstById() method executed successfully.";
                result.result_set = leeruitkomstModel;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to get Leeruitkomst.";
                result.internalMessage = $"ERROR: Leeruitkomst_Service: GetLeeruitkomstById(): {exception.Message}";
            }
            return result;
        }

        //update Leeruitkomst Entiteit in de database
        //Indien geslaagd: geef ResultObject met LeeruitkomstModel en succesmelding terug aan de controller
        //Indien mislukt: geef ResultObject met errormelding terug aan de controller
        public async Task<ResultObject<LeeruitkomstModel>> UpdateLeeruitkomst(int leeruitkomstId, string naam, string beschrijving)
        {
            ResultObject<LeeruitkomstModel> result = new ResultObject<LeeruitkomstModel>();  
            try
            {
                Leeruitkomst leeruitkomst = await _crud.Read<Leeruitkomst>(leeruitkomstId);
                leeruitkomst.Naam = naam;
                leeruitkomst.Beschrijving = beschrijving;
                leeruitkomst = await _crud.Update<Leeruitkomst>(leeruitkomst, leeruitkomstId);
                LeeruitkomstModel leeruitkomstModel = new LeeruitkomstModel{ Id = leeruitkomst.Id, Naam = leeruitkomst.Naam, Beschrijving = leeruitkomst.Beschrijving};
                result.userMessage = $"Leeruitkomst {leeruitkomstModel.Naam} updated successfully";
                result.internalMessage = "Leeruitkomst_Service: UpdateLeeruitkomst() method executed successfully.";
                result.result_set = leeruitkomstModel;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to update Leeruitkomst.";
                result.internalMessage = $"ERROR: Leeruitkomst_Service: UpdateLeeruitkomst(): {exception.Message}";
            }
            return result;
        }

        //Delete Leeruitkomst Entiteit in de database
        //Indien geslaagd: geef ResultObject met LeeruitkomstModel en succesmelding terug aan de controller
        //Indien mislukt: geef ResultObject met errormelding terug aan de controller
        public async Task<ResultObject<LeeruitkomstModel>> DeleteLeeruitkomst(int id)
        {
            ResultObject<LeeruitkomstModel> result = new ResultObject<LeeruitkomstModel>();
            try
            {
                Leeruitkomst leeruitkomst = await _crud.Read<Leeruitkomst>(id);
                var isDeleted = await _crud.Delete<Leeruitkomst>(id);
                result.userMessage = $"Leeruitkomst deleted successfully";
                result.internalMessage = "Leeruitkomst_Service: DeleteLeeruitkomst() method executed successfully.";
                result.result_set = null;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to delete Leeruitkomst.";
                result.internalMessage = $"ERROR: Leeruitkomst_Service: DeleteLeeruitkomst(): {exception.Message}";
            }
            return result;
        }
    }
}
