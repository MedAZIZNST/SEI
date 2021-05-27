using API.Models;
using API.Service;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Solution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class DemandeService : IDemandeService
    {
        private readonly IMapper _mapper;
        private readonly ERPDbContext _context;

        public DemandeService(IMapper mapper, ERPDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public void AddDemande(Demande d)
        {
            try
            {
                _context.Demande.Add(d);
                _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }


        }

        public void DeleteDemande(Demande d)
        {
            var Demande = _context.Demande.FindAsync(d.Id);
            if (Demande != null)
            {
                _context.Demande.Remove(d);
                _context.SaveChangesAsync();
            }
        }


        public Demande GetById(int Id)
        {
            return _context.Demande.Include(x=>x.Piece_Justificative).FirstOrDefault(e => e.Id == Id);
        }

        public IEnumerable<Demande> GetDemandes()
        {
            return _context.Demande.ToList();
        }

        public void UpdateDemande(Demande d)
        {

            _context.Entry(d).State = EntityState.Modified;

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
    

