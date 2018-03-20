using CommandLine;
using System.Collections.Generic;

namespace ConsoleApp
{
    class UserOptions
    {
        // using longname you can pass in cmd parameter as --id=1234 or --id 1234
        [Option("id", HelpText = "This is the id of the user, usage guide: --id=1234", Required = true)]
        public int Id { get; set; }

        // using shortname with '' quotes you pass in cmd parameter as -n Adrian
        [Option('n', HelpText = "This is the name of the user, usage guide: -n Adrian", Required = true)]
        public string Name { get; set; }


        // using seperator : with cmd parameter as -h football:golf
        [Option('h', HelpText = "This is the list of hobbies of the user, usage guide: -h: football:golf", Separator = ':')]
        public IEnumerable<string> Hobbies { get; set; }
        
    }
}
