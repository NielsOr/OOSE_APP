﻿using LOGIC.Interfaces.Repositories;
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

        public async Task<ResultObject<Evl>> CreateEvl(Evl evl)
        {
            ResultObject<Evl> result = new();
            try
            {
                result.ResultSet = await _repository.Create(evl);
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.Message = "failed to add the EVL.";
            }
            return result;
        }

        public async Task<ResultObject<Evl>> ReadEvl(int id)
        {
            ResultObject<Evl> result = new();
            try
            {
                result.ResultSet = await _repository.Read(id);
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.Message = "failed to find the EVL.";
            }
            return result;
        }
        public async Task<ResultObject<List<Evl>>> ReadAllEvls()
        {
            ResultObject<List<Evl>> result = new();
            try
            {
                result.ResultSet = await _repository.ReadAll();
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.Message = "failed to retrieve list of EVLs.";
            }
            return result;
        }
        public async Task<ResultObject<Evl>> UpdateEvl(int id, Evl evl)
        {
            ResultObject<Evl> result = new();
            try
            {
                result.ResultSet = await _repository.Update(id, evl);
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.Message = "failed to update the EVL.";
            }
            return result;
        }

        public async Task<ResultObject<bool>> DeleteEvl(int id)
        {
            ResultObject<bool> result = new();
            try
            {
                bool isDeleted = await _repository.Delete(id);
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

        public async Task<ResultObject<EvlRevisie>> CreateRevisie(int id)
        {
            ResultObject<EvlRevisie> result = new();
            try
            {
                result.ResultSet = await _repository.CreateRevisie(id);
                result.Message = "Succesfully revised EVL.";
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.Message = "failed to revise the EVL.";
            }
            return result;
        }

        public async Task<ResultObject<List<EvlRevisie>>> GetRevisiesByEvlId(int id)
        {
            ResultObject<List<EvlRevisie>> result = new();
            try
            {
                result.ResultSet = await _repository.GetRevisiesByEvlId(id);
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.Message = "failed to retrieve list of EVLs.";
            }
            return result;
        }


        //factory method?
        /* public async Task<ResultObject<FileResultObject>> DownloadRubrics(int id, int contentType)
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

         }*/

    }
}
