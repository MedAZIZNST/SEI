using Solution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Service
{
    public interface IDemandeService
    {
        Demande GetById(int Id);
        void DeleteDemande(Demande d);
        void UpdateDemande(Demande d);
        void AddDemande(Demande d);
        IEnumerable<Demande > GetDemandes();
    }
}

