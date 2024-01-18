﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using E2E.Employee.Domain.Models;


namespace E2E.Employee.Application.Context
{
    public class E2EDbContext : DbContext
    {
        public DbSet<Person>? Employees { get; set; }
        public DbSet<Gender>? Genders { get; set; }
        public E2EDbContext(DbContextOptions<E2EDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            GenderSeeder(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private static void GenderSeeder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>().HasData(

                new Gender()
                {
                    Id = 1,
                    Name = "Female"
                },
                new Gender()
                {
                    Id = 2,
                    Name = "Male"
                },
                new Gender()
                {
                    Id = 3,
                    Name = "Undisclosed"
                }
                );
        }
    }
}