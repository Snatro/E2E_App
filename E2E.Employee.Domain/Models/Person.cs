using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace E2E.Employee.Domain.Models
{
    public class Person
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public Gender Gender { get; set; }
        public String PicturePath {  get; set; }
        public DateOnly DateBirth { get; set; }
        public DateOnly FirstDayDate { get; set; }
        public String ContractType { get; set; }
        public DateOnly? ContractDueDate { get; set; }
        public String Department { get; set; }
        public int VacationDays { get; set; }
        public int FreeDays { get; set; }
        public int PaidFreeDays { get; set; }

    }
}
