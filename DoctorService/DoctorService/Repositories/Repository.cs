using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using DoctorService.Contexts;
using DoctorService.Interfaces;
using DoctorService.Models;
using System.Linq.Expressions;

namespace DoctorService.Repositories
{
    public  class Repository : IRepository<int, Schedule> 
    {
        private readonly  DoctorContext _context;
        public Repository(DoctorContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Schedule>> GetAll()
        {
            if (_context.Schedules.Count() == 0)
            {
                throw new Exception("No entities found");
            }
            return await _context.Schedules.ToListAsync();
        }

        public async Task<Schedule> Get(int key)
        {
            var schedule = _context.Schedules.Find(key);
            if (schedule == null)
            {
                throw new Exception("Entity not found");
            }
            return schedule;
        }


        public async Task<Schedule> Add(Schedule entity)
        {
             _context.Schedules.Add(entity);
             _context.SaveChanges();
            return entity;
        }

        public async Task<Schedule> Delete(int id)
        {
            var entity = await Get(id);
            if (entity != null)
            {
                _context.Schedules.Remove(entity);
                _context.SaveChanges();
                return entity;
            }
            throw new Exception("Entity not found");
        }

        public async Task<Schedule> Update(int key, Schedule entity)
        {
            var myEntity = await Get(key);
            if (myEntity != null)
            {
                _context.Schedules.Update(entity);
                await _context.SaveChangesAsync();
                return myEntity;
            }
            throw new Exception("Entity not found");
        }
        public async Task<ICollection<Schedule>> Find(Expression<Func<Schedule, bool>> predicate) 
        { 
            return await _context.Schedules.Where(predicate).ToListAsync(); 
        }
        
    }
}
