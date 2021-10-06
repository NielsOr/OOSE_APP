using DAL.Functions.Crud;
using LOGIC.Interfaces;
using LOGIC.Models;
using DAL.Entities;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace LOGIC.Implementation
{
    /// <summary>
    /// This service allows us to Add, Get and Update Applicant Data
    /// </summary>
    public class Evl_Service : IEvl_Service
    {
        //Reference to our DAL crud functions
        private ICRUD _crud = new CRUD();

        public async Task<ResultObject<List<EvlModel>>> GetEvls()
        {
            ResultObject<List<EvlModel>> result = new ResultObject<List<EvlModel>>();
            try
            {
                List<Evl> evls = await _crud.ReadAll<Evl>();
                List<EvlModel> evlModels = evls.Select(evl => new EvlModel
                {
                    Id = evl.Id,
                    Code = evl.Code,
                    Naam = evl.Naam,
                    Beroepstaken = evl.Beroepstaken,
                    Eindkwalificaties = evl.Eindkwalificaties,
                    Beschrijving = evl.Beschrijving,
                    Studiepunten = evl.Studiepunten
                }).ToList();

                result.userMessage = "list of EVLs found successfully";
                result.internalMessage = "Evl_Service: GetEvls() method executed successfully.";
                result.result_set = evlModels;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "failed to retrieve list of EVLs.";
                result.internalMessage = $"ERROR: Evl_Service: GetEvls(): {exception.Message}";
            }
            return result;
        }

        public async Task<ResultObject<EvlModel>> GetEvlById(int id)
        {
            ResultObject<EvlModel> result = new ResultObject<EvlModel>();
            try
            {
                Evl evl = await _crud.Read<Evl>(id);
                EvlModel evlModel = new EvlModel
                {
                    Id = evl.Id,
                    Code = evl.Code,
                    Naam = evl.Naam,
                    Beroepstaken = evl.Beroepstaken,
                    Eindkwalificaties = evl.Eindkwalificaties,
                    Beschrijving = evl.Beschrijving,
                    Studiepunten = evl.Studiepunten
                };
                
                result.userMessage = $"EVL {evlModel.Naam} found successfully";
                result.internalMessage = "Evl_Service: GetEvlById() method executed successfully.";
                result.result_set = evlModel;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "failed to find the EVL.";
                result.internalMessage = $"ERROR: Evl_Service: GetEvlById(): {exception.Message}";
            }
            return result;
        }

        public async Task<ResultObject<EvlModel>> AddEvl(string code, string naam, string beroepstaken, string eindkwalificaties, string beschrijving, double studiepunten)
        {
            ResultObject<EvlModel> result = new ResultObject<EvlModel>();
            try
            {
                Evl evl = new Evl
                {
                    Code = code,
                    Naam = naam,
                    Beroepstaken = beroepstaken,
                    Eindkwalificaties = eindkwalificaties,
                    Beschrijving = beschrijving,
                    Studiepunten = studiepunten,
                };

                evl = await _crud.Create<Evl>(evl);

                EvlModel evlModel = new EvlModel
                {
                    Id = evl.Id,
                    Code = evl.Code,
                    Naam = evl.Naam,
                    Beroepstaken = evl.Beroepstaken,
                    Eindkwalificaties = evl.Eindkwalificaties,
                    Beschrijving = evl.Beschrijving,
                    Studiepunten = evl.Studiepunten
                };

                result.userMessage = $"EVL {evlModel.Naam} added successfully";
                result.internalMessage = "Evl_Service: AddEvl() method executed successfully.";
                result.result_set = evlModel;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "failed to add the EVL.";
                result.internalMessage = $"ERROR: Evl_Service: AddEvl(): {exception.Message}";
            }
            return result;
        }    

        public async Task<ResultObject<EvlModel>> UpdateEvl(int id, string code, string naam, string beroepstaken, string eindkwalificaties, string beschrijving, double studiepunten)
        {
            ResultObject<EvlModel> result = new ResultObject<EvlModel>();
            try
            {
                Evl evl = new Evl
                {
                    Id = id,
                    Code = code,
                    Naam = naam,
                    Beroepstaken = beroepstaken,
                    Eindkwalificaties = eindkwalificaties,
                    Beschrijving = beschrijving,
                    Studiepunten = studiepunten,
                };
                //UPDATE Applicant FROM DB
                evl = await _crud.Update<Evl>(evl, id);

                //MANUAL MAPPING OF UPDATED Applicant VALUES TO OUR Applicant_ResultSet
                EvlModel evlModel = new EvlModel
                {
                    Id = evl.Id,
                    Code = evl.Code,
                    Naam = evl.Naam,
                    Beroepstaken = evl.Beroepstaken,
                    Eindkwalificaties = evl.Eindkwalificaties,
                    Beschrijving = evl.Beschrijving,
                    Studiepunten = evl.Studiepunten
                };

                result.userMessage = $"EVL {evlModel.Naam} updated successfully";
                result.internalMessage = "Evl_Service: UpdateEvl() method executed successfully.";
                result.result_set = evlModel;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "failed to update the EVL.";
                result.internalMessage = $"ERROR: Evl_Service: UpdateEvl(): {exception.Message}";
            }
            return result;
        }

        public async Task<ResultObject<EvlModel>> DeleteEvl(int id)
        {
            ResultObject<EvlModel> result = new ResultObject<EvlModel>();
            try
            {
                var isDeleted = await _crud.Delete<Evl>(id);
                result.userMessage = $"EVL deleted successfully";
                result.internalMessage = "Evl_Service: DeleteEvl() method executed successfully.";
                result.result_set = null;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "failed to delete the EVL.";
                result.internalMessage = $"ERROR: Evl_Service: DeleteEvl(): {exception.Message}";
            }
            return result;
        }

    }
}
