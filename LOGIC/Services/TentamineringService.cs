using LOGIC.Enums;
using LOGIC.Interfaces;
using LOGIC.Interfaces.Files;
using LOGIC.Interfaces.Repositories;
using LOGIC.Interfaces.Services;
using LOGIC.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services
{
    public class TentamineringService : ITentamineringService
    {
        private readonly ITentamineringRepository _repository;
        private readonly IRubricsFileBuilder _filebuilder;

        public TentamineringService(ITentamineringRepository repository, IRubricsFileBuilder filebuilder)
        {
            _repository = repository;
            _filebuilder = filebuilder;
        }

        public async Task<ResultObject<Tentaminering>> CreateTentaminering(Tentaminering tentaminering)
        {
            ResultObject<Tentaminering> result = new();
            try
            {
                result.ResultSet = await _repository.Create(tentaminering);
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.Message = "Failed to add Tentaminering.";
            }
            return result;
        }

        public async Task<ResultObject<Tentaminering>> ReadTentaminering(int id)
        {
            ResultObject<Tentaminering> result = new();
            try
            {
                result.ResultSet = await _repository.Read(id);
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.Message = "Failed to get Tentaminering.";
            }
            return result;
        }

        public async Task<ResultObject<Tentaminering>> UpdateTentaminering(int id, Tentaminering tentaminering)
        {
            ResultObject<Tentaminering> result = new();
            try
            {
                result.ResultSet = await _repository.Update(id, tentaminering);
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.Message = "Failed to update Tentaminering.";
            }
            return result;
        }

        public async Task<ResultObject<bool>> DeleteTentaminering(int id)
        {
            ResultObject<bool> result = new();
            try
            {
                bool isDeleted = await _repository.Delete(id);
                result.Message = "Succesfully deleted Tentaminering.";
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.Message = "Failed to delete Tentaminering.";
            }
            return result;
        }

        //factory method?
        public async Task<ResultObject<FileResultObject>> DownloadRubrics(int id, int contentType)
        {
            ResultObject<FileResultObject> result = new();
            try
            {
                var tentaminering = await _repository.Read(id);
                switch (contentType)
                {
                    case (int)ContentType.CSV:
                        {
                            result.ResultSet = _filebuilder.BuildFileCSV(tentaminering.Rubrics);
                            result.Success = true;
                            break;
                        }
                    case (int)ContentType.PDF:
                        {
                            result.ResultSet = _filebuilder.BuildFilePDF(tentaminering.Rubrics);
                            result.Success = true;
                            break;
                        }
                    case (int)ContentType.DOCX:
                        {
                            result.ResultSet = _filebuilder.BuildFileDOCX(tentaminering.Rubrics);
                            result.Success = true;
                            break;
                        }
                    default:
                        throw new NullReferenceException("content type not found or supported");
                }
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.Message = "failed to find the Tentamineringen.";
            }
            return result;
            
       }
    }
}
