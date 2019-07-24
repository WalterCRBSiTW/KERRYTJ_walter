using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework02.Models;
using Homework02.ViewModel.UniForm;

namespace Homework02.Repository.BLL
{
    public interface IMasterBLO
    {
        IEnumerable<Master> GetMasterAll();

        void CreateMaster(inUniResult create);
        void UpdateMaster(inUniResult update);
        void DeleteMaster(Master master);
        Master SelectMasterProc(inUniResult select);

    }
}
