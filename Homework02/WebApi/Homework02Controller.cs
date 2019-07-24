using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Homework02.Repository.BLL;
using Homework02.ViewModel.UniForm;
using Homework02.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework02.WebApi
{
    [Route("api/[controller]/[action]")]
    public class Homework02Controller : Controller
    {
        private IMasterBLO iMasterBLO; //物件指標宣告

        public Homework02Controller(IMasterBLO _iMasterBLO) //注入物件
        {
            iMasterBLO = _iMasterBLO;

        }

        [HttpGet]
        public outUniResult Get_DB()
        {
            outUniResult _outUniResult = new outUniResult();

            try
            {
                _outUniResult.StatusCode = 200;
                _outUniResult.Result = iMasterBLO.GetMasterAll();
                _outUniResult.Error = null;

                return _outUniResult;
            }
            catch(Exception e)
            {
                _outUniResult.StatusCode = (int)HttpStatusCode.NotFound;
                _outUniResult.Result = "發生錯誤";
                _outUniResult.Error = null;

                return _outUniResult;
            }
        }

        [HttpPost]
        public outUniResult CreateResult([FromBody]inUniResult create)
        {
            outUniResult _outUniResult = new outUniResult();

            try
            { 
                
                iMasterBLO.CreateMaster(create);


                _outUniResult.StatusCode = StatusCodes.Status200OK;  
                _outUniResult.Result = iMasterBLO.SelectMasterProc(create); 
                _outUniResult.Error = null;

                return _outUniResult;
            }
            catch (Exception e)
            {
                _outUniResult.StatusCode = (int)HttpStatusCode.NotFound;
                _outUniResult.Result = "發生錯誤";
                _outUniResult.Error = null;

                return _outUniResult;
            }

        }

        [HttpPost]
        public outUniResult UpdateResult([FromBody]inUniResult update)
        {
            outUniResult _outUniResult = new outUniResult();

            try
            {
                _outUniResult.StatusCode = StatusCodes.Status200OK;
                iMasterBLO.UpdateMaster(update);
                _outUniResult.Result = iMasterBLO.SelectMasterProc(update); 
                _outUniResult.Error = null;

                return _outUniResult;
            }
            catch (Exception e)
            {
                _outUniResult.StatusCode = (int)HttpStatusCode.NotFound;
                _outUniResult.Result = "發生錯誤";
                _outUniResult.Error = null;

                return _outUniResult;
            }

        }

        [HttpPost]
        public void DeleteResult([FromBody]Master master)
        {
            outUniResult _outUniResult = new outUniResult();

            try
            {
                _outUniResult.StatusCode = StatusCodes.Status200OK;
                iMasterBLO.DeleteMaster(master);
                _outUniResult.Result = iMasterBLO.GetMasterAll();
                _outUniResult.Error = null;

                //return _outUniResult;
            }
            catch (Exception e)
            {
                _outUniResult.StatusCode = (int)HttpStatusCode.NotFound; //狀態碼
                _outUniResult.Result = "發生錯誤";
                _outUniResult.Error = null;

                //return _outUniResult;
            }

        }
    }

    
}
