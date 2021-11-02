using EZLaborAPI.Accounts.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLaborAPI.Commons.Domain.Persistence.Context
{
    public class AppDbContext: DbContext
    {
        //incializar
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //Accounts System

        public DbSet<Freelancer> Freelancers { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Proposal> Proposals { get; set; }

        //More Systems



        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Added from documentation
            base.OnModelCreating(builder);
            // Accounts System------------------------------------------

            //Freelancer Entity
            builder.Entity<Freelancer>().ToTable("Freelancer");
            //Constraints
            builder.Entity<Freelancer>().HasKey(p => p.Id);
            builder.Entity<Freelancer>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Freelancer>().Property(p => p.UserName).IsRequired().HasMaxLength(20);
            builder.Entity<Freelancer>().Property(p => p.Email).IsRequired().HasMaxLength(25);
            builder.Entity<Freelancer>().Property(p => p.Password).IsRequired().HasMaxLength(20);
            builder.Entity<Freelancer>().Property(p => p.Name).IsRequired();
            builder.Entity<Freelancer>().Property(p => p.LastName).IsRequired();
            builder.Entity<Freelancer>().Property(p => p.Rating);
            builder.Entity<Freelancer>().Property(p => p.About);

            //Seed data 
            builder.Entity<Freelancer>().HasData
                (
                    new Freelancer
                    {
                        Id = 100,
                        UserName = "J.Andrew",
                        Email = "address100@gmail.com",
                        Password = "password",
                        Name = "Jhon",
                        LastName = "Doe",
                        Rating = 8
                    },
                    new Freelancer
                    {
                        Id = 101,
                        UserName = "Jobzzzz",
                        Email = "address101@mail.com",
                        Password = "password",
                        Name = "Steve",
                        LastName = "Jobs",
                        Rating = 9
                    }
                );


            ///Employer Entity
            builder.Entity<Employer>().ToTable("Employer");
            //Contraints
            builder.Entity<Employer>().HasKey(p => p.Id);
            builder.Entity<Employer>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Employer>().Property(p => p.UserName).IsRequired().HasMaxLength(20);
            builder.Entity<Employer>().Property(p => p.Email).IsRequired().HasMaxLength(25);
            builder.Entity<Employer>().Property(p => p.Password).IsRequired().HasMaxLength(20);
            builder.Entity<Employer>().Property(p => p.Name).IsRequired();
            builder.Entity<Employer>().Property(p => p.LastName).IsRequired();

            //Seed Data
            builder.Entity<Employer>().HasData
                (
                    new Employer
                    {
                        Id = 200,
                        UserName = "MFer",
                        Email = "address100@gmail.com",
                        Password = "password",
                        Name = "Maria",
                        LastName = "Fernandez",
                    },
                    new Employer
                    {
                        Id = 201,
                        UserName = "MJane",
                        Email = "address2200@gmail.com",
                        Password = "password",
                        Name = "Mary",
                        LastName = "Jane",
                    }
                );


            ///Skill Entity
            builder.Entity<Skill>().ToTable("Skill");
            //Contraints
            builder.Entity<Skill>().HasKey(p => p.Id);
            builder.Entity<Skill>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Skill>().Property(p => p.SkillName).IsRequired().HasMaxLength(25);
            builder.Entity<Skill>()
                .HasOne(pt => pt.Freelancer)
                .WithMany(pt => pt.Skills)
                .HasForeignKey(pt => pt.FreelancerId);

            //Seed Data
            builder.Entity<Skill>().HasData
                (
                    new Skill
                    {
                        Id = 300,
                        SkillName = "VueJS Developer",
                        FreelancerId = 100
                    }

                );


            ///Proposal Entity
            builder.Entity<Proposal>().ToTable("Proposal");
            //Contraints
            builder.Entity<Proposal>().HasKey(p => p.Id);
            builder.Entity<Proposal>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Proposal>().Property(p => p.Title).IsRequired();
            builder.Entity<Proposal>().Property(p => p.Description).IsRequired();
            builder.Entity<Proposal>().Property(p => p.Fee).IsRequired();

            //Relationships
            builder.Entity<Proposal>()
                .HasOne(pt => pt.Freelancer)
                .WithMany(pt => pt.Proposals)
                .HasForeignKey(pt => pt.FreelancerId);
            builder.Entity<Proposal>()
                .HasOne(pt => pt.Employer)
                .WithMany(pt => pt.Proposals)
                .HasForeignKey(pt => pt.EmployerId);

            //Seed Data
            builder.Entity<Proposal>().HasData
                (
                    new Proposal
                    {
                        Id = 400,
                        Title = "Company logo",
                        Description = "I want a nice logo with ...",
                        Fee = 25.00,
                        FreelancerId = 100,
                        EmployerId = 200
                    },
                    new Proposal
                    {
                        Id = 401,
                        Title = "API Development",
                        Description = "I want a fastfood API for my bussiness",
                        Fee = 125.00,
                        FreelancerId = 101,
                        EmployerId = 200
                    }

                );

            //Some extension if you want





        }

    }
}
