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
    public class LeeruitkomstService : ILeeruitkomstService
    {
        private readonly ICrud _crud = new Crud();

        //Add Leeruitkomst Entiteit in de database
        //Indien geslaagd: geef ResultObject met LeeruitkomstModel en succesmelding terug aan de controller
        //Indien mislukt: geef ResultObject met errormelding terug aan de controller
        public async Task<ResultObject<LeeruitkomstDto>> AddLeeruitkomst(int evlId, string naam, string beschrijving)
        {
            ResultObject<LeeruitkomstDto> result = new();
            try
            {
                Evl evl = await _crud.Read<Evl>(evlId);
                Leeruitkomst leeruitkomst = new() { Naam = naam, Evl = evl, Beschrijving = beschrijving };
                leeruitkomst = await _crud.Create(leeruitkomst);
                LeeruitkomstDto leeruitkomstModel = new() { Id = leeruitkomst.Id, Naam = leeruitkomst.Naam, Beschrijving = leeruitkomst.Beschrijving };
                result.UserMessage = $"Leeruitkomst {leeruitkomstModel.Naam} added successfully";
                result.InternalMessage = "Leeruitkomst_Service: AddLeeruitkomst() method executed successfully.";
                result.ResultSet = leeruitkomstModel;
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.UserMessage = "Failed to add Leeruitkomst.";
                result.InternalMessage = $"ERROR: Leeruitkomst_Service: AddLeeruitkomst(): {exception.Message}";
            }
            return result;
        }

        //get Leeruitkomst Entity from the database
        //Indien geslaagd: geef ResultObject met LeeruitkomstModel en succesmelding terug aan de controller
        //Indien mislukt: geef ResultObject met errormelding terug aan de controller
        public async Task<ResultObject<LeeruitkomstDto>> GetLeeruitkomstById(int leeruitkomstId)
        {
            ResultObject<LeeruitkomstDto> result = new();
            try
            {
                Leeruitkomst leeruitkomst = await _crud.Read<Leeruitkomst>(leeruitkomstId);
                LeeruitkomstDto leeruitkomstModel = new() { Id = leeruitkomst.Id, Naam = leeruitkomst.Naam, Beschrijving = leeruitkomst.Beschrijving };
                result.UserMessage = $"Leeruitkomst {leeruitkomstModel.Naam} found successfully";
                result.InternalMessage = "Leeruitkomst_Service: GetLeeruitkomstById() method executed successfully.";
                result.ResultSet = leeruitkomstModel;
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.UserMessage = "Failed to get Leeruitkomst.";
                result.InternalMessage = $"ERROR: Leeruitkomst_Service: GetLeeruitkomstById(): {exception.Message}";
            }
            return result;
        }

        //update Leeruitkomst Entiteit in de database
        //Indien geslaagd: geef ResultObject met LeeruitkomstModel en succesmelding terug aan de controller
        //Indien mislukt: geef ResultObject met errormelding terug aan de controller
        public async Task<ResultObject<LeeruitkomstDto>> UpdateLeeruitkomst(int leeruitkomstId, string naam, string beschrijving)
        {
            ResultObject<LeeruitkomstDto> result = new();
            try
            {
                Leeruitkomst leeruitkomst = await _crud.Read<Leeruitkomst>(leeruitkomstId);
                leeruitkomst.Naam = naam;
                leeruitkomst.Beschrijving = beschrijving;
                leeruitkomst = await _crud.Update(leeruitkomst, leeruitkomstId);
                LeeruitkomstDto leeruitkomstModel = new() { Id = leeruitkomst.Id, Naam = leeruitkomst.Naam, Beschrijving = leeruitkomst.Beschrijving };
                result.UserMessage = $"Leeruitkomst {leeruitkomstModel.Naam} updated successfully";
                result.InternalMessage = "Leeruitkomst_Service: UpdateLeeruitkomst() method executed successfully.";
                result.ResultSet = leeruitkomstModel;
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.UserMessage = "Failed to update Leeruitkomst.";
                result.InternalMessage = $"ERROR: Leeruitkomst_Service: UpdateLeeruitkomst(): {exception.Message}";
            }
            return result;
        }

        //Delete Leeruitkomst Entiteit in de database
        //Indien geslaagd: geef ResultObject met LeeruitkomstModel en succesmelding terug aan de controller
        //Indien mislukt: geef ResultObject met errormelding terug aan de controller
        public async Task<ResultObject<LeeruitkomstDto>> DeleteLeeruitkomst(int id)
        {
            ResultObject<LeeruitkomstDto> result = new();
            try
            {
                Leeruitkomst leeruitkomst = await _crud.Read<Leeruitkomst>(id);
                var isDeleted = await _crud.Delete<Leeruitkomst>(id);
                result.UserMessage = $"Leeruitkomst deleted successfully";
                result.InternalMessage = "Leeruitkomst_Service: DeleteLeeruitkomst() method executed successfully.";
                result.ResultSet = null;
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.UserMessage = "Failed to delete Leeruitkomst.";
                result.InternalMessage = $"ERROR: Leeruitkomst_Service: DeleteLeeruitkomst(): {exception.Message}";
            }
            return result;
        }
    }
}
