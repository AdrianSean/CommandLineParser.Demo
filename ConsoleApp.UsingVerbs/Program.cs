using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;

namespace ConsoleApp.UsingVerbs
{
    class Program
    {
        [Verb("Create", HelpText = "Use this command to add a user, usage guide: Create --id=1234 --name=Adrian --hobbies=football:golf")]
        class CreateOptions
        {
            [Option("id", HelpText = "This is the id of the new user", Required = true)]
            public int Id { get; set; }

            // using shortname with '' quotes ou pass in cmd parameter as -n Adrian
            [Option(HelpText = "This is the name of the new user", Required = true)]
            public string Name { get; set; }
            
            // using seperator : with cmd parameter as -h football:golf
            [Option(HelpText = "This is the list of hobbies of the new user", Separator = ':')]
            public IEnumerable<string> Hobbies { get; set; }          

        }        

        [Verb("Amend", HelpText = "Use this command to edit/update a user, usage guide: Amend --id=1234 -n AdrianSean -h football:UFC:golf")]
        class AmendOptions
        {
            [Option("id", HelpText = "This is the id of the user to update", Required = true)]
            public int Id { get; set; }

            [Option('n', HelpText = "This is the updated name of the user")]
            public string Name { get; set; }

            [Option('h', HelpText = "This is the updated list of hobbies of the user", Separator = ':')]
            public IEnumerable<string> Hobbies { get; set; }

        }

        [Verb("Delete", HelpText = "Use this command to remove a user, usage guide: Delete --id=1234")]
        class DeleteOptions
        {
            [Option("id", HelpText = "This is the id of the user to be removed", Required = true)]
            public int Id { get; set; }
        }

        

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<CreateOptions, AmendOptions, DeleteOptions>(args)
                                          .WithParsed<CreateOptions>(opts => AddUser(opts))
                                          .WithParsed<AmendOptions>(opts => AmendUser(opts))
                                          .WithParsed<DeleteOptions>(opts => DeleteUser(opts))
                                          .WithNotParsed(errs => HandleParseError(errs));

            Console.Read();
        }



        static void AddUser(CreateOptions option)
        {
            Console.WriteLine("Id: {0}", option.Id);
            Console.WriteLine("Name: {0}", option.Name);
            Console.Write("Hobbies: ");
            foreach (string hobbie in option.Hobbies)
            {
                Console.Write("{0} ", hobbie);
            }
            Console.WriteLine();

            // add the user..
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("User has been successfully created");
        }


        /// <summary>
        /// This will update a specified user on the system
        /// </summary>
        /// <param name="option"></param>
        static void AmendUser(AmendOptions option)
        {
            Console.WriteLine("Searched by Id: {0}", option.Id);
            Console.WriteLine("Updated Name: {0}", option.Name);
            Console.Write("Updated Hobbies: ");
            foreach (string hobbie in option.Hobbies)
            {
                Console.Write("{0} ", hobbie);
            }
            Console.WriteLine();


            // update a user..
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("User has been successfully updated");
        }


        /// <summary>
        /// THis will remove a specifeid user from the system
        /// </summary>
        /// <param name="option"></param>
        static void DeleteUser(DeleteOptions option)
        {
            Console.WriteLine("Remove User with Id: {0}", option.Id);           

            // remove a user..
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("User has been successfully removed");
        }



        static void HandleParseError(IEnumerable<Error> errors)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Woops...bad input given");
        }
    }
}
