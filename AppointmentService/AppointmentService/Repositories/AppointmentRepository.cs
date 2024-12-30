using AppointmentService.Contexts;
using AppointmentService.Interfaces;
using AppointmentService.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentService.Repositories
{
    public class AppointmentRepository : IRepository<int, Appointment>
    {
        private readonly AppointmentContext _appointmentContext;

        public AppointmentRepository(AppointmentContext appointmentContext)
        {
            _appointmentContext = appointmentContext;
        }
        public async Task<Appointment> Add(Appointment entity)
        {
           await _appointmentContext.Appointments.AddAsync(entity);
           await _appointmentContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Appointment> Delete(int key)
        {
            var entity = await Get(key);
            if (entity != null)
            {
                _appointmentContext.Appointments.Remove(entity);
                _appointmentContext.SaveChanges();
                return entity;
            }
            throw new Exception("Entity not found");
        }

        public async Task<Appointment> Get(int key)
        {
            var appointment = _appointmentContext.Appointments.Find(key);
            if (appointment == null)
            {
                throw new Exception("Entity not found");
            }
            return appointment;
        }

        public async Task<ICollection<Appointment>> GetAll()
        {
            if (_appointmentContext.Appointments.Count() == 0)
            {
                throw new Exception("No entities found");
            }
            return await _appointmentContext.Appointments.ToListAsync();
        }

        public async Task<Appointment> Update(int key, Appointment entity)
        {
            var myEntity = await Get(key);
            if (myEntity != null)
            {
                _appointmentContext.Appointments.Update(entity);
                await _appointmentContext.SaveChangesAsync();
                return myEntity;
            }
            throw new Exception("Entity not found");
        }
    }
}
