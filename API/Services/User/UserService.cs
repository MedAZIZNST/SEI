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
   
    public class UserService : IUserService
    {
        private readonly ERPDbContext  _context;

        public UserService(ERPDbContext context)
        {
            _context = context;
        }

        public User GetByEmail(string email)
        {
            var user =  _context.User.FirstOrDefault(x=>x.Email == email);
            return user;
        }
        public void AddUser(User u)
        {
            try
            {
                _context.User.Add(u);
                _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
           
        }
        public void AddRole(Role u)
        {
            try
            {
                _context.Role.Add(u);
                _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void UpdateUser(User u)
        {
            _context.Entry(u).State = EntityState.Modified;

            try
            {
                 _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                    throw;              
            }
        }

        public void DeleteUser(User u)
        {
            var user = _context.User.FirstOrDefault(u => u.Id == u.Id);
            if (user != null)
            {
                _context.User.Remove(u);
                 _context.SaveChangesAsync();
            }
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.User.ToList();
        }


        
        public IEnumerable<Role> GetRoles()
        {
            return _context.Role.ToList();
        }

        public User GetById(int Id)
        {
            return _context.User.Include(c => c.UsersInRoles).FirstOrDefault(e => e.Id == Id);
        }

        private bool ItemExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }


        //DeleteRole
        //public void DeleteRole(Role u)
        //{
        //    var role = _context.Role.FirstOrDefault(u => u.Id == u.Id);
        //    if (role != null)
        //    {
        //        _context.Role.Remove(u);
        //        _context.SaveChangesAsync();
        //    }
        //}
    }
}

