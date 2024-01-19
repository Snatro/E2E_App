using E2E.Employee.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2E.Employee.Application.Persistence.Configuration
{
    public class PeopleConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable(nameof(Person));

            builder.HasOne(person => person.Gender)
                .WithMany(gender => gender.Persons)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
