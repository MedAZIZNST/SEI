using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Solution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class PieceJustificativeService : IPieceJustificativeService
    {
        private readonly IMapper _mapper;
        private readonly ERPDbContext _context;

        public PieceJustificativeService(IMapper mapper, ERPDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public void AddPieceJustificative(PieceJustificative p)
        {
            try
            {
                _context.PieceJustificative.Add(p);
                _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }


        }
        public PieceJustificative GetById(int Id)
        {
            return _context.PieceJustificative.FirstOrDefault(e => e.Id == Id);
        }


        public IEnumerable<PieceJustificative> GetPieceJustificatives()
        {
            return _context.PieceJustificative.ToList();

        }
    }
}
