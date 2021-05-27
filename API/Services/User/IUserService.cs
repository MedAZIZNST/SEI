using API.Helpers;
using Solution.Entities;
using Solution.ViewModel;
using System;
using System.Collections.Generic;

namespace Solution.Service
{
    public interface IUserService
    {
        User GetById(int Id);
        User GetByEmail(string email);
        void DeleteUser(User u);
        void UpdateUser(User u);
        void AddUser(User u);
        IEnumerable<User> GetUsers();

        IEnumerable<Role> GetRoles();
        void AddRole(Role u);

        //DeleteRole
        //void DeleteRole(Role u);


    }
}
