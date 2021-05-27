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

    public class TypeService : ITypeService
    {
        private readonly IMapper _mapper;
        private readonly ERPDbContext _context;

        public TypeService(IMapper mapper, ERPDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public void AddTypeConge(TypeConge p)
        {
            try
            {
                _context.TypeConge.Add(p);
                _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }

    

   

        public IEnumerable<TypeConge> GetTypeConges()
        {
            return _context.TypeConge.ToList();
        }

       

        public TypeConge GetById(int Id)
        {
            return _context.TypeConge.FirstOrDefault(e => e.Id == Id);
        }
    }
}

