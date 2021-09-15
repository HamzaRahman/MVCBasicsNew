using MVCBasicsNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasicsNew.Repository
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {
        //        InMemoryPeopleRepo – Implements IPeopleRepo interface and these two fields.
        //          ▪ Private static List of Person.
        //          ▪ Private static int idCounter.
        static List<Person> people = new List<Person>();
        static int IDCounter = 0;
        public Person Create(string Name, int PhoneNumber, string City)
        {
            Person p = new Person();
            p.ID = ++IDCounter;
            p.Name = Name;
            p.PhoneNumber = PhoneNumber;
            p.City = City;
            people.Add(p);
            return p;
        }

        public bool Delete(Person person)
        {
            foreach (var p in people)
            {
                if (p == person)
                {
                    people.Remove(p);
                    return true;
                }
            }
            return false;
        }

        public List<Person> Read()
        {
            return people;
        }

        public Person Read(int ID)
        {
            return people.Where(p => p.ID == ID).FirstOrDefault();
        }

        public Person Update(Person person)
        {
            int i = 0;
            foreach (var p in people)
            {
                if (p.ID == person.ID)
                {
                    people[i] = person;
                    return person;
                }
                ++i;
            }
            return person;
        }
    }
}
