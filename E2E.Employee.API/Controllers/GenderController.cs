using E2E.Employee.Application.Genders;
using E2E.Employee.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace E2E.Employee.API.Controllers
{
    [ApiController]
    public class GenderController : ControllerBase
    {

        private readonly IGenderService genderService;

        public GenderController(IGenderService genderService)
        {
            this.genderService = genderService;
        }

        [HttpGet]
        [Route("GetGenders")]
        public async Task<IReadOnlyList<Gender>> GetGenders(CancellationToken cancellationToken)
        {
            return await this.genderService.GetGenders(cancellationToken);
        }
    }
}
