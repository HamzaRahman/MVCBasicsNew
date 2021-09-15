using MVCBasicsNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasicsNew.Repository
{
    public interface IPeopleRepo
    {
        //        IPeopleRepo – Interface with following methods.
        //          ▪ Person Create(“parameters needed to create Person excluding id”)
        //          ▪ List<Person> Read()
        //          ▪ Person Read(int id)
        //          ▪ Person Update(Person person)
        //          ▪ bool Delete(Person person)
        Person Create(string Name, int PhoneNumber, string City);
        List<Person> Read();
        Person Read(int ID);
        Person Update(Person person);
        bool Delete(Person person);
    }
}
