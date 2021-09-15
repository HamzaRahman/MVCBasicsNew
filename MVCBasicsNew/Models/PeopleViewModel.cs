using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasicsNew.Models
{
    public class PeopleViewModel
    {
        // PeopleViewModel – container for the information you need in your people view.
        public PeopleViewModel()
        {

        }
        public List<Person> people = new List<Person>();
        public string SearchPhrase { get; set; }
        public CreatePersonViewModel CreatePerson { get; set; }
    }
}
