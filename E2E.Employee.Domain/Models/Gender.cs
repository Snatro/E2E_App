﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2E.Employee.Domain.Models
{
    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Person>? Persons { get; set;}
    }
}
