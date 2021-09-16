using Microsoft.AspNetCore.Mvc;
using MVCBasicsNew.Models;
using MVCBasicsNew.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasicsNew.Controllers
{
    public class PersonController : Controller
    {
        PeopleService PS = new PeopleService();
        //We will use this method both for all people in a table or based on user search
        //When we load or reload the webpage, it will automatically call this method
        //This is a get method, as we use it to get data to show on page
        public IActionResult Index(PeopleViewModel search)
        {
            //Use Below Code For Table Data If Not Using AJAX
            //Here we check whether the user has entered something in search or not
            if (string.IsNullOrEmpty(search.SearchPhrase))
            {
                //if not , then get all people from PeopleService and Show on Table
                return View(PS.All());
            }
            //Else Find People Based on User search and Show on Table
            return View(PS.FindBy(search));
        }
        //Below We use this method to add a person in database 
        //We take a PeopleViewModel object which contains a CreatePersonViewModel by which we validate Data on a Person given by a user
        //Here a get method can also be used
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PeopleViewModel m)
        {
            //Here we send PeopleViewModel -> CreatePersonViewModel object to PeopleService to add it to database
            PS.Add(m.CreatePerson);
            //Then we go to Index Method which is defined above
            return RedirectToAction("Index");
        }
        //public ActionResult Edit(int ID)
        //{
        //    var pvm = PS.All();
        //    var p = PS.FindBy(ID);
        //    pvm.CreatePerson.Model = p;
        //    return RedirectToAction("Index",pvm);
        //}
        //Below We use this method to edit a person in database 
        //We take a PeopleViewModel object which contains a CreatePersonViewModel by which we validate Data on a Person given by a user
        //Here a get method can also be used    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PeopleViewModel p)
        {
            //Here we send PeopleViewModel -> CreatePersonViewModel object to PeopleService to edit it in database
            PS.Edit(p.CreatePerson.ID, p.CreatePerson.Model);
            //Then we go to Index Method which is defined above
            return RedirectToAction("Index");
        }
        //Below We use this method to delete a person in database
        //We take an int variable ID which is automatically given when we click on delete in people table
        public IActionResult Delete(int ID)
        {
            PS.Remove(ID);
            return RedirectToAction("Index"); 
        }
    }
}
