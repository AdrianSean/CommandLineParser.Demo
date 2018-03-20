using CommandLine;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        class Options {

            // using longname you can pass in cmd parameter as --id=1234 or --id 1234
            [Option("id", HelpText ="This is the id of the user, usage guide: --id=1234", Required =true)]
            public int Id { get; set; }


            // using shortname with '' quotes you pass in cmd parameter as -n Adrian
            [Option('n', HelpText = "This is the name of the user, usage guide: -n Adrian", Required =true)]
            public string Name { get; set; }

            // using seperator : with cmd parameter as -h football:golf
            [Option('h', HelpText ="This is the list of hobbies of the user, usage guide: -h: football:golf", Separator =':')]
            public IEnumerable<string> Hobbies { get; set; }
        }

        


        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                    .WithParsed(opts => DisplayOptionsInputted(opts))
                    .WithNotParsed((errs) => HandleParseError(errs));
                      

            Console.Read();
        }


        static void DisplayOptionsInputted(Options option) {

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
