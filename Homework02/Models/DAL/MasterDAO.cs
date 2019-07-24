using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework02.Repository.DAL;
using Homework02.Models;
using Homework02.Factory;
using Homework02.ViewModel.UniForm;
using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.EntityFrameworkCore;

namespace Homework02.Models.DAL
{
    [DependencyRegister]
    public class MasterDAO : IMasterDAO
    {
        private readonly HomeworkDBContext _context;

        public MasterDAO(HomeworkDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Master> Get_Master()
        {
            try
            {
                IEnumerable<Master> _master = from x in _context.Master select x;

                return _master;
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        public void CreateMaster(Master create)
        {
            try
            {
                _context.Master.Add(create);
                _context.SaveChanges();


            }
            catch (Exception e)
            {
                throw new Exception();
            }

        }

        public void UpdateMaster(Master update)
        {
            try
            {
                //var number = _context.Master.Find(id);
                //number.Date = DateTime.UtcNow;
                //number.Value1 = update.Value1;
                //number.Value2 = update.Value2;
                //_context.Master.Update(number);

                _context.Entry(update).State = EntityState.Modified;
                _context.SaveChanges();



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
                var number = _context.Master.Find(master.Id);
                //var number = _context.Master.FirstOrDefault(x => x.Id == id);
                _context.Master.Remove(number);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        public Master Select_Master(inUniResult select)
        {
            try
            {
                Master Id = _context.Master.FirstOrDefault(x => x.Id == select.Id);

                return Id;
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }
    }
}
