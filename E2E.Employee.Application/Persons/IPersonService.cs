using E2E.Employee.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2E.Employee.Application.Employees
{
    public interface IPersonService
    {
        public Task<IReadOnlyList<PersonDTO>> GetPersons(CancellationToken cancellationToken);
        public Task<Person> GetPersonById(int id, CancellationToken cancellationToken);
        public Task<int> CreatePerson(Person createPersonDTO, CancellationToken cancellationToken);
        public Task UpdatePerson(Person updatePersonDTO, CancellationToken cancellationToken);
    }
}
