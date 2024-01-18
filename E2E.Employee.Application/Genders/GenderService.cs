using E2E.Employee.Application.Context;
using E2E.Employee.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2E.Employee.Application.Genders
{
    public class GenderService : IGenderService
    {
        private readonly E2EDbContext dbContext;

        public GenderService(E2EDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IReadOnlyList<Gender>> GetGenders(CancellationToken cancellationToken)
        {
            return await this.dbContext.Genders.Select(gender => new Gender
            {
                Id = gender.Id,
                Name = gender.Name
            }).AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}
