using CommandLine;
using System;
using System.Collections.Generic;

namespace ConsoleApp.UsingVerbs
{
    class Program
    {
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
