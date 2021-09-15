using MVCBasicsNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasicsNew.Services
{
    public interface IPeopleService
    {
        //IPeopleService – Interface with following methods.
        //▪ Person Add(CreatePersonViewModel person)
        //▪ PeopleViewModel All()
        //▪ PeopleViewModel FindBy(PeopleViewModel search)
        //▪ Person FindBy(int id)
        //▪ Person Edit(int id, Person person)
        //▪ bool Remove(int id)
        Person Add(CreatePersonViewModel person);
        PeopleViewModel All();
        PeopleViewModel FindBy(PeopleViewModel Search);
        Person FindBy(int ID);
        Person Edit(int ID, Person person);
        bool Remove(int ID);
    }
}
