using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IObjectifService
    {
        Objectif GetById(int Id);
        void DeleteObjectif(Objectif o);
        void UpdateObjectif(Objectif o);
        void AddObjectif(Objectif o);
        IEnumerable<Objectif> GetObjectifs();
    }
}
