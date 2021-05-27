using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class ObjectifService : IObjectifService
    {
        private readonly IMapper _mapper;
        private readonly ERPDbContext _context;

        public ObjectifService(IMapper mapper, ERPDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public void AddObjectif(Objectif o)
        {
            try
            {
                _context.Objectif.Add(o);
                _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }


        }

        public void DeleteObjectif(Objectif o)
        {
            var objectif = _context.Objectif.FindAsync(o.Id);
            if (objectif != null)
            {
                _context.Objectif.Remove(o);
                _context.SaveChangesAsync();
            }
        }


        public Objectif GetById(int Id)
        {
            return _context.Objectif.FirstOrDefault(e => e.Id == Id);
        }

        public IEnumerable<Objectif> GetObjectifs()
        {
            return _context.Objectif.ToList();
        }

        public void UpdateObjectif(Objectif o)
        {

            _context.Entry(o).State = EntityState.Modified;

            try
            {
                _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}

      



