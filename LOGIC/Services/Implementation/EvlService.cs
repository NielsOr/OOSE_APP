using DAL.Entities;
using DAL.Functions.Crud;
using LOGIC.Interfaces;
using LOGIC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LOGIC.Implementation
{
    /// <summary>
    /// This service allows us to Add, Get and Update Applicant Data
    /// </summary>
    public class EvlService : IEvlService
    {
        //Reference to our DAL crud functions
        private readonly ICrud _crud = new Crud();

        public async Task<ResultObject<List<EvlDto>>> GetEvls()
        {
            ResultObject<List<EvlDto>> result = new();
            try
            {
                List<Evl> evls = await _crud.ReadAll<Evl>();
                List<EvlDto> evlModels = evls.Select(evl => new EvlDto
                {
                    Id = evl.Id,
                    Code = evl.Code,
                    Naam = evl.Naam,
                    Beroepstaken = evl.Beroepstaken,
                    Eindkwalificaties = evl.Eindkwalificaties,
                    Beschrijving = evl.Beschrijving,
                    Studiepunten = evl.Studiepunten
                }).ToList();

                result.UserMessage = "list of EVLs found successfully";
                result.InternalMessage = "Evl_Service: GetEvls() method executed successfully.";
                result.ResultSet = evlModels;
                result.Success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.Exception = exception;
                result.UserMessage = "failed to retrieve list of EVLs.";
                result.InternalMessage = $"ERROR: Evl_Service: GetEvls(): {exception.Message}";
            }
            return result;
        }

        public async Task<ResultObject<EvlDto>> GetEvlById(int id)
        {
            ResultObject<EvlDto> result = new();
            try
            {
                Evl evl = await _crud.Read<Evl>(id);
                EvlDto evlModel = new()
                {
                    Id = evl.Id,
                    Code = evl.Code,
                    Naam = evl.Naam,
                    Beroepstaken = evl.Beroepstaken,
                    Eindkwalificaties = evl.Eindkwalificaties,
                    Beschrijving = evl.Beschrijving,
                    Studiepunten = evl.Studiepunten
                };

                result.UserMessage = $"EVL {evlModel.Naam} found successfully";
                result.InternalMessage = "Evl_Service: GetEvlById() method executed successfully.";
                result.ResultSet = evlModel;
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.UserMessage = "failed to find the EVL.";
                result.InternalMessage = $"ERROR: Evl_Service: GetEvlById(): {exception.Message}";
            }
            return result;
        }

        public async Task<ResultObject<EvlDto>> AddEvl(string code, string naam, string beroepstaken, string eindkwalificaties, string beschrijving, double studiepunten)
        {
            ResultObject<EvlDto> result = new();
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

                evl = await _crud.Create(evl);

                EvlDto evlModel = new()
                {
                    Id = evl.Id,
                    Code = evl.Code,
                    Naam = evl.Naam,
                    Beroepstaken = evl.Beroepstaken,
                    Eindkwalificaties = evl.Eindkwalificaties,
                    Beschrijving = evl.Beschrijving,
                    Studiepunten = evl.Studiepunten
                };

                result.UserMessage = $"EVL {evlModel.Naam} added successfully";
                result.InternalMessage = "Evl_Service: AddEvl() method executed successfully.";
                result.ResultSet = evlModel;
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.UserMessage = "failed to add the EVL.";
                result.InternalMessage = $"ERROR: Evl_Service: AddEvl(): {exception.Message}";
            }
            return result;
        }

        public async Task<ResultObject<EvlDto>> UpdateEvl(int id, string code, string naam, string beroepstaken, string eindkwalificaties, string beschrijving, double studiepunten)
        {
            ResultObject<EvlDto> result = new();
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
                // UPDATE Applicant FROM DB
                evl = await _crud.Update(evl, id);

                // MANUAL MAPPING OF UPDATED Applicant VALUES TO OUR Applicant_ResultSet
                EvlDto evlModel = new()
                {
                    Id = evl.Id,
                    Code = evl.Code,
                    Naam = evl.Naam,
                    Beroepstaken = evl.Beroepstaken,
                    Eindkwalificaties = evl.Eindkwalificaties,
                    Beschrijving = evl.Beschrijving,
                    Studiepunten = evl.Studiepunten
                };

                result.UserMessage = $"EVL {evlModel.Naam} updated successfully";
                result.InternalMessage = "Evl_Service: UpdateEvl() method executed successfully.";
                result.ResultSet = evlModel;
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.UserMessage = "failed to update the EVL.";
                result.InternalMessage = $"ERROR: Evl_Service: UpdateEvl(): {exception.Message}";
            }
            return result;
        }

        public async Task<ResultObject<EvlDto>> DeleteEvl(int id)
        {
            ResultObject<EvlDto> result = new();
            try
            {
                var isDeleted = await _crud.Delete<Evl>(id);
                result.UserMessage = $"EVL deleted successfully";
                result.InternalMessage = "Evl_Service: DeleteEvl() method executed successfully.";
                result.ResultSet = null;
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.UserMessage = "failed to delete the EVL.";
                result.InternalMessage = $"ERROR: Evl_Service: DeleteEvl(): {exception.Message}";
            }
            return result;
        }
    }
}
