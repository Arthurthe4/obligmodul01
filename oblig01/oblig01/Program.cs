using System;

namespace oblig01
{
    class Program
    {
        static void Main(string[] args)
        {
            var sverreMagnus = new Person { ID = "1", FirstName = "Sverre Magnus", BirthYear = "2005" };
            var ingridAlexandra = new Person { ID = "2", FirstName = "Ingrid Alexandra", BirthYear = "2004" };
            var haakon = new Person { ID = "3", FirstName = "Haakon Magnus", BirthYear = "1973" };
            var metteMarit = new Person { ID = "4", FirstName = "Mette-Marit", BirthYear = "1973" };
            var marius = new Person { ID = "5", FirstName = "Marius", LastName = "Borg Høiby", BirthYear = "1997" };
            var harald = new Person { ID = "6", FirstName = "Harald", BirthYear = "1937" };
            var sonja = new Person { ID = "7", FirstName = "Sonja", BirthYear = "1937" };
            var olav = new Person { ID = "8", FirstName = "Olav", BirthYear = "1903" };

            sverreMagnus.Father = haakon;
            sverreMagnus.Mother = metteMarit;
            ingridAlexandra.Father = haakon;
            ingridAlexandra.Mother = metteMarit;
            marius.Mother = metteMarit;
            haakon.Father = harald;
            haakon.Mother = sonja;
            harald.Father = olav;

            var app = new FamilyApp(sverreMagnus, ingridAlexandra, haakon,
                metteMarit, marius, harald, sonja, olav);
            Console.WriteLine(app.WelcomeMessage);
            while (true)
            {
                Console.Write(app.CommandPrompt);
                var command = Console.ReadLine();
                var response = app.HandleCommand(command);
                Console.WriteLine(response);
            }
        }
    }
}
