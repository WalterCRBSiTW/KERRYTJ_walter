using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework02.Models;
using Homework02.ViewModel.UniForm;

namespace Homework02.Repository.DAL
{
    public interface IMasterDAO
    {
        IEnumerable<Master> Get_Master();
        void CreateMaster(Master create);
        void UpdateMaster(Master update);
        void DeleteMaster(Master master);
        Master Select_Master(inUniResult select);  //??????????????????
    }
}
