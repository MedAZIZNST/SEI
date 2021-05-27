//using AutoMapper;
using API;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Solution.Entities;
using Solution.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Solution.Service
{

    public class ProjetService : IProjetService
    {
        private readonly IMapper _mapper;
        private readonly ERPDbContext _context;

        public ProjetService(IMapper mapper, ERPDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Projet GetByName(string projetname)
        {
            var projet = _context.Projet.FirstOrDefault(x => x.ProjetName == projetname);
            return projet;
        }
        public void AddProjet(Projet p)
        {
            try
            {
                _context.Projet.Add(p);
                _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void UpdateProjet(Projet p)
        {
            _context.Entry(p).State = EntityState.Modified;

            try
            {
                _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void DeleteProjet(Projet p)
        {
            var projet = _context.Projet.FindAsync(p.Id);
            if (projet != null)
            {
                _context.Projet.Remove(p);
                _context.SaveChangesAsync();
            }
        }


        public IEnumerable<Projet> GetProjets()
        {
            return _context.Projet.ToList();
        }

       

        public Projet GetById(int Id)
        {
            return _context.Projet.FirstOrDefault(e => e.Id == Id);
        }

        private bool ItemExists(int id)
        {
            return _context.Projet.Any(e => e.Id == id);
        }


        //GetAllUsers
        public IEnumerable<User> GetUsers()
        {
            return _context.User.ToList();
        }
    }
}

