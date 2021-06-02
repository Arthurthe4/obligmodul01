using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oblig01
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthYear { get; set; }
        public string DeathYear { get; set; }
        public string ID { get; set; }

        public Person Mother { get; set; }

        public Person Father { get; set; }

        public Person(string firstName = null, string lastName = null, string birthYear = null, string deathYear = null, string id = null, Person mother = null, Person father = null)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthYear = birthYear;
            DeathYear = deathYear;
            ID = id;
            Mother = mother;
            Father = father;
        }

        public Person(string theID)
        {
            ID = theID;
        }

        public string GetDescription()
        {
            var Description = "";
            if (FirstName != null) { Description += $"{FirstName} "; }
            if (LastName != null) { Description += $"{LastName}"; }


            Description += $"(Id={ID})";
            if (BirthYear != null) { Description += $" Født: {BirthYear}" ; }
            if (DeathYear != null) { Description += $"{DeathYear}"; }
            if (Father != null) { Description += $" Far: {Father.FirstName} (Id={Father.ID})"; }
            if (Mother != null) { Description += $"Mor: {Mother.FirstName} (Id={Mother.ID})"; }
            return Description;
        }

    }
}
