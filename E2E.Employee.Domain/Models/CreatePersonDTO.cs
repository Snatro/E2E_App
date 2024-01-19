using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2E.Employee.Domain.Models
{
    public class CreatePersonDTO
    {
        public String Name { get; set; }
        public String Surname { get; set; }
        public Gender Gender { get; set; }
        public String PicturePath { get; set; }
        public DateTime DateBirth { get; set; }
        public DateTime FirstDayDate { get; set; }
        public String ContractType { get; set; }
        public DateTime? ContractDueDate { get; set; }
        public String Department { get; set; }
        public int VacationDays { get; set; }
        public int FreeDays { get; set; }
        public int PaidFreeDays { get; set; }

    }
}
