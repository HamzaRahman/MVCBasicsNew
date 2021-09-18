using MVCBasicsNew.Models;
using MVCBasicsNew.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasicsNew.Services
{
    public class PeopleService : IPeopleService
    {
        //PeopleService – Implements IPeopleService interface.
        //Use Dependency Injection to constructor inject IPeopleRepo interface into PeopleService class.
        IPeopleRepo PeopleDatabase;
        //Use Dependency Injection to constructor inject IPeopleRepo interface into PeopleService class.
        public PeopleService(IPeopleRepo _PeopleDatabase)
        {
            PeopleDatabase = _PeopleDatabase;
        }
        //Here we take CreatePersonViewModel object which is used to validate input
        //from user and then we send its properties to InMemoryPeopleRepo
        public Person Add(CreatePersonViewModel person)
        {
            PeopleDatabase.Create(person.Name, person.PhoneNumber, person.City);
            return person.Model;
        }
        //Below we are making a PeopleViewModel object which can be used in multiple functions
        PeopleViewModel pvm = new PeopleViewModel();
        public PeopleViewModel All()
        {
            var people = PeopleDatabase.Read();
            pvm.people = people;
            return pvm;
        }

        public Person Edit(int ID, Person person)
        {
            return PeopleDatabase.Update(person);
        }
        //Below we are a PeopleViewModel object which will contains a string variable containing the user search input
        public PeopleViewModel FindBy(PeopleViewModel Search)
        {
            //Here we are spliting the string variable in two strings if it contains a space
            string[] parameters = Search.SearchPhrase.Split(new char[' ']);
            //Here we are fetching all the people in a list variable
            var people = PeopleDatabase.Read();
            //Now we are comparing each persons each property with user's search input and storing the results in PeopleViewModel Object
            //we created earlier
            pvm.people = people.Where(person => parameters.Any(param =>
                person.Name.Contains(param) ||
                person.PhoneNumber.ToString().Contains(param) ||
                person.City.Contains(param)
                )).ToList();
            //then returning it
            return pvm;
        }

        public Person FindBy(int ID)
        {
            return PeopleDatabase.Read(ID);
        }

        public bool Remove(int ID)
        {
            var people = PeopleDatabase.Read();
            //Here first we find the person to be removed based on ID given by user
            var person = people.Where(p => p.ID == ID).FirstOrDefault();
            //then sending it to InMemoryPeopleRepo to be deleted
            return PeopleDatabase.Delete(person);
        }
    }
}
