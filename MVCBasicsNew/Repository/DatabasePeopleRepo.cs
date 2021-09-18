using MVCBasicsNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasicsNew.Repository
{
    public class DatabasePeopleRepo : IPeopleRepo
    {
        //Create a DatabasePeopleRepo class that implements the IPeopleRepo interface.
        public Person Create(string Name, int PhoneNumber, string City)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Person person)
        {
            throw new NotImplementedException();
        }

        public List<Person> Read()
        {
            throw new NotImplementedException();
        }

        public Person Read(int ID)
        {
            throw new NotImplementedException();
        }

        public Person Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
