using Core.Security.Entities;
using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<LanguageTechnology> LanguageTechnologies { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Social> Socials { get; set; }

        //Security Entity
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }


        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(a =>
            {
                a.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasMany(p => p.LanguageTechnologies).WithOne(p => p.ProgrammingLanguage);
            });

            modelBuilder.Entity<LanguageTechnology>(a =>
            {
                a.ToTable("LanguageTechnologies").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasOne(p => p.ProgrammingLanguage).WithMany(p => p.LanguageTechnologies);
            });

            modelBuilder.Entity<User>(a =>
            {
                a.ToTable("Users").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.FirstName).HasColumnName("FirstName");
                a.Property(p => p.LastName).HasColumnName("LastName");
                a.Property(p => p.Email).HasColumnName("Email");
                a.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
                a.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
                a.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");
                a.HasMany(p => p.UserOperationClaims);
                a.HasMany(p => p.RefreshTokens);
            });

            modelBuilder.Entity<Developer>(a =>
            {
                a.ToTable("Developers");
                a.HasMany(p => p.Socials);
            });

            modelBuilder.Entity<OperationClaim>(a =>
            {
                a.ToTable("OperationClaims").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
            });

            modelBuilder.Entity<UserOperationClaim>(a =>
            {
                a.ToTable("UserOperationClaims").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.UserId).HasColumnName("UserId");
                a.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");
                a.HasOne(p => p.OperationClaim);
                a.HasOne(P => P.User);
            });

            modelBuilder.Entity<Social>(a =>
            {
                a.ToTable("Socils").HasKey(k => k.Id);
                a.Property(a => a.Id).HasColumnName("Id");
                a.Property(a => a.DeveloperId).HasColumnName("DeveloperId");
                a.Property(a => a.GitHubProfile).HasColumnName("GitHubProfile");
                a.HasOne(p => p.Developer);
            });

            ProgrammingLanguage[] programmingLanguageEntitySeeds = { new(1, "C#"), new(2, "Java"), new(3, "JavaScript") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);

            LanguageTechnology[] languageTechnologyEntitySeeds = { new(1, 1, "WPF"), new(2, 1, "ASP.NET"), new(3, 2, "Spring"), new(4, 2, "JSP"), new(5, 3, "Vue"), new(6, 3, "React") };
            modelBuilder.Entity<LanguageTechnology>().HasData(languageTechnologyEntitySeeds);
        }

    }
}
