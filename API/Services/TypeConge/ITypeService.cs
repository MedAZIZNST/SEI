using Solution.Entities;
using Solution.ViewModel;
using System;
using System.Collections.Generic;

namespace Solution.Service
{
    public interface ITypeService
    {
        TypeConge GetById(int Id);
        void AddTypeConge(TypeConge p);
        IEnumerable<TypeConge> GetTypeConges();
    }
}
