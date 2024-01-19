using E2E.Employee.Application.Persons;
using E2E.Employee.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace E2E.Employee.API.Controllers
{
    [ApiController]
    public class PersonController : Controller
    {
       private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        [Route("persons")]
        public async Task<IReadOnlyList<PersonDTO>> GetPersons(CancellationToken cancellationToken)
        {
            return await this._personService.GetPersons(cancellationToken);
        }

        [HttpGet]
        [Route("person/{id}")]
        public async Task<Person> GetPersonById(int id, CancellationToken cancellationToken)
        {
            return await this._personService.GetPersonById(id, cancellationToken);
        }

        [HttpPost]
        [Route("person")]
        public async Task<int> CreatePerson([FromBody] CreatePersonDTO person, CancellationToken cancellationToken)
        {
            int id =  await this._personService.CreatePerson(person, cancellationToken);
            return id;
        }

        [HttpPut]
        [Route("person")]
        public async Task<IActionResult> UpdatePerson([FromBody] Person person, CancellationToken cancellationToken)
        {
            await this._personService.UpdatePerson(person, cancellationToken);
            return Ok();
        }
    }
}
