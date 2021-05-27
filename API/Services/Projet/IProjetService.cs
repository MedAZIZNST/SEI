using Solution.Entities;
using Solution.ViewModel;
using System;
using System.Collections.Generic;

namespace Solution.Service
{
    public interface IProjetService
    {
        Projet GetById(int Id);
        Projet GetByName(string ProjetName);
        void DeleteProjet(Projet p);
        void UpdateProjet(Projet p);
        void AddProjet(Projet p);
        IEnumerable<Projet> GetProjets();

        IEnumerable<User> GetUsers();
    }
}
