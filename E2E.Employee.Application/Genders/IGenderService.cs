using E2E.Employee.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2E.Employee.Application.Genders
{
    public interface IGenderService
    {
        public Task<IReadOnlyList<Gender>> GetGenders(CancellationToken cancellationToken);
    }
}
