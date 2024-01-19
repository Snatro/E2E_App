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
                Gender = createPersonDTO.Gender,
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
            await dbContext.SaveChangesAsync();
            return person.Id;
        }

        public async Task<Person> GetPersonById(int id, CancellationToken cancellationToken)
        {
            return await dbContext.Employees.Where(person => person.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<PersonDTO>> GetPersons(CancellationToken cancellationToken)
        {
            return await dbContext.Employees.AsNoTracking().Select(person => new PersonDTO
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
            Person person = await dbContext.Employees.FindAsync(new object[] { updatePersonDTO.Id }, cancellationToken: cancellationToken);

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
