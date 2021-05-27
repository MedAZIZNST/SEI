using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using Solution.Entities;
namespace API
{
        public class ERPDbContext : DbContext
        {
            public ERPDbContext(DbContextOptions options) : base(options) { }
     
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UsersInRoles> UsersInRoles { get; set; }

        public virtual DbSet<UsersInProjects> UsersInProjects { get; set; }
        public virtual DbSet<RealiserObjectif> RealiserObjectif { get; set; }
        public virtual DbSet<TypeConge> TypeConge { get; set; }
        public virtual DbSet<PieceJustificative> PieceJustificative { get; set; }

        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Projet> Projet { get; set; }
        public virtual DbSet<Objectif> Objectif { get; set; }
        public virtual DbSet<Demande> Demande { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UsersInRoles>()
                .HasKey(bc => new { bc.UserId, bc.RoleId });
            modelBuilder.Entity<UsersInRoles>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.UsersInRoles)
                .HasForeignKey(bc => bc.UserId);
            modelBuilder.Entity<UsersInRoles>()
                .HasOne(bc => bc.Role)
                .WithMany(c => c.UsersInRoles)
                .HasForeignKey(bc => bc.RoleId);

            modelBuilder.Entity<UsersInProjects>()
    .HasKey(bc => new { bc.UserId, bc.ProjetId });
            modelBuilder.Entity<UsersInProjects>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.UsersInProjects)
                .HasForeignKey(bc => bc.UserId);
            modelBuilder.Entity<UsersInProjects>()
                .HasOne(bc => bc.Projet)
                .WithMany(c => c.UsersInProjects)
                .HasForeignKey(bc => bc.ProjetId);

            modelBuilder.Entity<RealiserObjectif>()
               .HasKey(bc => new { bc.UserId, bc.ObjectifId });
            modelBuilder.Entity<RealiserObjectif>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.RealiserObjectif)
                .HasForeignKey(bc => bc.UserId);
            
            modelBuilder.Entity<RealiserObjectif>()
                .HasOne(bc => bc.Objectif)
                .WithMany(c => c.RealiserObjectif)
                .HasForeignKey(bc => bc.ObjectifId);

           
        }

    }



}
