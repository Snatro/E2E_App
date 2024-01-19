using E2E.Employee.Application.Persistence;
using E2E.Employee.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2E.Employee.Application.Persons
{
    public class PersonService : IPersonService
    {

        private readonly E2EDbContext dbContext;

        public PersonService(E2EDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> CreatePerson(CreatePersonDTO createPersonDTO, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(createPersonDTO, nameof(createPersonDTO));
            Person person = new Person()
            {
                Name = createPersonDTO.Name,
                Surname = createPersonDTO.Surname,
                GenderId = createPersonDTO.Gender.Id,
                PicturePath = createPersonDTO.PicturePath,
                Department = createPersonDTO.Department,
                DateBirth = createPersonDTO.DateBirth,
                ContractDueDate = createPersonDTO.ContractDueDate,
                ContractType = createPersonDTO.ContractType,
                FirstDayDate = createPersonDTO.FirstDayDate,
                FreeDays = createPersonDTO.FreeDays,
                VacationDays = createPersonDTO.VacationDays,
                PaidFreeDays = createPersonDTO.PaidFreeDays,
            };
            dbContext.Add(person);
            try
            {
                // Code to save changes to the database using Entity Framework
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Handle the DbUpdateException
                foreach (var entry in ex.Entries)
                {
                    if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                    {
                        // The entry that caused the exception
                        var entity = entry.Entity;

                        // Handle or log the exception details
                        Console.WriteLine($"Error saving entity of type {entity.GetType().Name}: {ex.Message}");
                    }
                }

                // If there is an inner exception, examine it for more details
                if (ex.InnerException != null)
                {
                    // Log or handle the inner exception
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
            }
            return person.Id;
        }

        public async Task<Person> GetPersonById(int id, CancellationToken cancellationToken)
        {
            return await dbContext.Persons.Where(p => p.Id == id).Include(p => p.Gender).
                Select(p => new Person
                {
                    Id = p.Id,
                   Name = p.Name,
                   Surname = p.Surname,
                   Gender = p.Gender,
                   PicturePath = p.PicturePath,
                   Department = p.Department,
                   DateBirth = p.DateBirth,
                   FirstDayDate = p.FirstDayDate,
                   ContractType = p.ContractType,
                   ContractDueDate = p.ContractDueDate,
                   PaidFreeDays = p.PaidFreeDays,
                   VacationDays = p.VacationDays,
                   FreeDays = p.FreeDays

                }).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<PersonDTO>> GetPersons(CancellationToken cancellationToken)
        {
            return await dbContext.Persons.AsNoTracking().Select(person => new PersonDTO
            {
                Id = person.Id,
                Name = person.Name,
                Surname = person.Surname,
                PicturePath = person.PicturePath,
                Department = person.Department
            }).ToListAsync(cancellationToken);
        }

        public async Task UpdatePerson(Person updatePersonDTO, CancellationToken cancellationToken)
        {
            Person person = await dbContext.Persons.FindAsync(new object[] { updatePersonDTO.Id }, cancellationToken: cancellationToken);

            if (person != null)
            {
                person.Name = updatePersonDTO.Name;
                person.Surname = updatePersonDTO.Surname;
                person.Department = updatePersonDTO.Department;
                person.Gender = updatePersonDTO.Gender;
                person.PicturePath = updatePersonDTO.PicturePath;
                person.DateBirth = updatePersonDTO.DateBirth;
                person.ContractType = updatePersonDTO.ContractType;
                person.ContractDueDate = updatePersonDTO.ContractDueDate;
                person.FirstDayDate = updatePersonDTO.FirstDayDate;
                person.FreeDays = updatePersonDTO.FreeDays;
                person.VacationDays = updatePersonDTO.VacationDays;
                person.PaidFreeDays = updatePersonDTO.PaidFreeDays;
            }

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
