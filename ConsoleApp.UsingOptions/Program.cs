using CommandLine;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<UserOptions>(args)
                    .WithParsed(opts => DisplayOptionsInputted(opts))
                    .WithNotParsed((errs) => HandleParseError(errs));
                      

            Console.Read();
        }


        static void DisplayOptionsInputted(UserOptions option) {

            Console.WriteLine("***** DISPLAYING USER INFO SUPPLIED ********");
            Console.WriteLine("Id: {0}",option.Id);
            Console.WriteLine("Name: {0}", option.Name);
            Console.Write("Hobbies: ");
            foreach (string hobbie in option.Hobbies) {
                Console.Write("{0} ", hobbie);
            }
        }

       
        static void HandleParseError(IEnumerable<Error> errors) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Woops...bad input given");
        }
    }
}
