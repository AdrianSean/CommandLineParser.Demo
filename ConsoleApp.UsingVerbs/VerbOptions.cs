using CommandLine;
using System.Collections.Generic;

namespace ConsoleApp.UsingVerbs
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
   
}
