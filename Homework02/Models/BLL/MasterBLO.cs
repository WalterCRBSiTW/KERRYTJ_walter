using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework02.Factory;
using Homework02.Models;
using Homework02.Repository.BLL;
using Homework02.Repository.DAL;
using Homework02.ViewModel.UniForm;

namespace Homework02.Models.BLL
{
    [DependencyRegister]

    public class MasterBLO : IMasterBLO
    {
        private IMasterDAO iMasterDAO;

        public MasterBLO(IMasterDAO _iMasterDAO)
        {
            iMasterDAO = _iMasterDAO;
        }

        // 取得Master資料庫的商業邏輯
        public IEnumerable<Master> GetMasterAll()
        {
            try
            {
                IEnumerable<Master> _master = iMasterDAO.Get_Master();
                return _master;
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        public void CreateMaster(inUniResult create)
        {
            try
            {
                Master _master = new Master
                {
                    Value1 = create.value1,
                    Value2 = create.value2,
                    Id = Guid.NewGuid(),
                    Date = DateTime.UtcNow
                };

                iMasterDAO.CreateMaster(_master);

            }
            catch (Exception e)
            {
               
                throw new Exception();
            }
        }

        public void UpdateMaster(inUniResult update)
        {
            try
            {
                Master _master = new Master
                {
                    Id = update.Id,
                    Value1 = update.value1,
                    Value2 = update.value2,
                    Date = DateTime.UtcNow
                };


                iMasterDAO.UpdateMaster(_master);
            } 
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        public void DeleteMaster(Master master)
        {
            try
            {
                iMasterDAO.DeleteMaster(master);
            }
            catch (Exception e)
            {
                throw new Exception();
            }

        }

        public Master SelectMasterProc(inUniResult select)
        {
            try
            {
                Master Id = iMasterDAO.Select_Master(select);  //??????????????
                return Id;
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

    }
}
