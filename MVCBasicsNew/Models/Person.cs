using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasicsNew.Models
{
    public class Person
    {
        //Code Requirements:• Models ---- Person – Person data
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string City { get; set; }
    }
}
