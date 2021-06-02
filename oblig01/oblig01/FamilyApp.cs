using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oblig01
{
    // var app = new FamilyApp(sverreMagnus, ingridAlexandra, haakon,
    // metteMarit, marius, harald, sonja, olav);
    // Console.WriteLine(app.WelcomeMessage);
    public class FamilyApp
    {
        public List<Person> _persons;
        public FamilyApp(params Person[] persons)
        {
            _persons = new List<Person>(persons);
        }

        public string WelcomeMessage = "Hello welcome to the app";
        public string CommandPrompt = "hjelp =>  viser en hjelpetekst som forklarer alle kommandoene \n" +
                                      "liste => lister alle personer med id, fornavn, fødselsår, dødsår og navn og id på mor og far om det finnes registrert \n" +
                                      "vis <id>  =>  viser en bestemt person med mor, far og barn (og id for disse, slik at man lett kan vise en av dem) \n";

        public string HandleCommand(string command)
        {
            if (command == "hjelp") { return CommandPrompt; }
            if (command == "liste")
            {
                foreach (var e in _persons)
                {
                    var Description = "";
                    if (e.Father != null) { Description += $"Far: {e.Father.FirstName} (Id={e.Father.ID})"; }
                    if (e.Mother != null) { Description += $"Mor: {e.Mother.FirstName} (Id={e.Mother.ID})"; }
                    Console.WriteLine($"Id:{e.ID} Navn:{e.FirstName} {e.LastName} Født:{e.BirthYear} Død:{e.DeathYear} {Description}");
                }
            }

            int id = getId(command);
            if (id != 0)
            {
                foreach (var i in _persons)
                {
                    Person foundPerson = findPerson(id, i);
                    if (foundPerson != null)
                    {
                        return listOutPersonWithChildren(i);
                    }
                }
            }
            return null;
        }

        private Person findPerson(int id, Person Person)
        {
            if (Person.ID == id.ToString())
            {
                return Person;
            }
            else
            {
                return null;
            }
        }

        private int getId(string command)
        {
            var commandArray = command.Split(' ');
            int ID;
            if (commandArray.Length == 2)
            {
                var isInt = int.TryParse(commandArray[1], out ID);
                if (isInt && commandArray[0] == "vis")
                {
                    return ID;
                }
            }
            return 0;
        }

        private string listOutPersonWithChildren(Person onlyOnePerson)
        {
            string PersonWithRightIdReturn = onlyOnePerson.GetDescription();
            PersonWithRightIdReturn += ReturnChildren(onlyOnePerson.ID);
            return PersonWithRightIdReturn;
        }

        private string ReturnChildren(string id)
        {
            string PersonWithRightIdReturn = "";
            PersonWithRightIdReturn += ReturnChildrenOfMother(id);
            PersonWithRightIdReturn += ReturnChildrenOfFather(id);
            return PersonWithRightIdReturn;
        }

        private string ReturnChildrenOfMother(string id)
        {
            string PersonWithRightIdReturn = "";
            bool FirstTime = true;
            foreach (var child in _persons)
            {
                if (child.Mother != null)
                {
                    if (child.Mother.ID == id)
                    {
                        if (FirstTime)
                        {
                            PersonWithRightIdReturn += $"\n"; PersonWithRightIdReturn += $"  Barn:\n";
                            FirstTime = false;
                        }
                        PersonWithRightIdReturn +=
                            $"    {child.FirstName} {child.LastName} (Id={child.ID}) Født: {child.BirthYear}\n";
                    }
                }
            }
            return PersonWithRightIdReturn;
        }

        public string ReturnChildrenOfFather(string id)
        {
            string PersonWithRightIdReturn = "";
            bool FirstTime = true;
            foreach (var child in _persons)
            {
                if (child.Father != null)
                {
                    if (child.Father.ID == id)
                    {
                        if (FirstTime)
                        {
                            PersonWithRightIdReturn += $"\n"; PersonWithRightIdReturn += $"  Barn:\n";
                            FirstTime = false;
                        }
                        PersonWithRightIdReturn +=
                            $"    {child.FirstName} {child.LastName} (Id={child.ID}) Født: {child.BirthYear}\n";
                    }
                }
            }
            return PersonWithRightIdReturn;
        }

    }
}
