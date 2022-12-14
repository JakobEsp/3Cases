using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_Cases
{
    internal class Login
    {
        
        static void Main(string[] args)
        {
            RunLogin login = new RunLogin();
            
            //Runs the methods used to login and setup the user.
            login.GetOutput();
            login.Login();
            login.GetProgram();  
        }
    }
    public class RunLogin
    {
        public bool debug;
        string file = "", path;
        Output output = new Output();
        FileHandlers fileHandlers = new FileHandlers();
        ConsoleKey tast;
        public void GetOutput()
        {
            //choose where system outup will be.
            Console.WriteLine("Standard[S] | Debug[D]");
            output.KeyPress(out tast);
            if (tast == ConsoleKey.S)
            {
                output.Debug = false;
            }
            else if (tast == ConsoleKey.D)
            {
                output.Debug = true;
                Console.WriteLine(output.Debug);
                output.Printline(output.Debug, $"Debug = true");
            }
            else
            {   
                //tells you if you pressed wrong.
                Console.WriteLine("you pressed wrong try again");
                Console.ReadLine();
                Console.Clear();
                GetOutput();
            }
            debug = output.Debug;
        }
        public void Login()
        {
            bool valid = false;
            string name, pw;
            do
            {   
                output.Printline(debug, "Login[L] Opret[O]");
                //gets user input.
                output.KeyPress(out tast);
                if (tast == ConsoleKey.L)
                {   //asks for name and password
                    output.Printline(debug, "Indtast navn:");
                    name = Console.ReadLine();
                    output.Printline(debug, "Indtast kodeord:");
                    pw = Console.ReadLine();
                    if(file == "")
                    {   //if there isn't a path to a file it will get the default file route.
                        fileHandlers.GetStandartPath(file, out file);
                    }
                    //gets all lines with username & passwords from file. 
                    string[] lines = File.ReadAllLines(file);
                    // goes trough lines in file 1 by 1.
                    for (int i = 0; i < lines.Length; i++)
                    {
                        //check lines for the name and password.
                        if (lines[i].Contains(name + pw))
                        {
                            valid = true;
                            Console.Clear();
                        }
                    }
                }
                else if (tast == ConsoleKey.O)
                {
                    //Makes file where password and username is stored.
                    fileHandlers.Create(debug, file, out file, out path);
                    output.Printline(debug, "Indtast navn:");
                    name = Console.ReadLine();
                    output.Printline(debug, "Indtast kodeord:");
                    pw = Console.ReadLine();
                    //checks if password passes.
                    if (fileHandlers.CheckPassword(debug, pw, name))
                    {
                        //puts username and password into file.
                        fileHandlers.WriteText(debug, path, (name + pw));
                    }
                }
                else if (tast == ConsoleKey.H)
                {
                    //shortcut.
                    valid = true;
                    Console.Clear();
                }
            } while (!valid);
        }
        public void GetProgram()
        {
            ConsoleKey tasts;
            Fodbold fodbold = new Fodbold();
            DanseKonkurrence danseKonkurrence = new DanseKonkurrence();
            Output output = new Output();

            output.Printline(debug, $"Football[F] Dance[D]");
            
            output.KeyPress(out tasts);
            //Get's program from Key
            if (tasts == ConsoleKey.F)
            {
                //Clears Console and starts program.
                Console.Clear();
                fodbold.MatchStart(debug);
            }
            else if (tasts == ConsoleKey.D)
            {
                Console.Clear();
                danseKonkurrence.GetInputs(debug);
            }
            else
            {
                output.Printline(debug, $"Something went wrong. Press Enter and try agin");
                Console.ReadLine();
                Console.Clear();
                GetProgram();
            }
        }
    }
    class FileHandlers
    {
        // A function to create a file
        public void Create(bool Debug, string file, out string filename, out string path)
        {

            // Create a new instance of 'OutPut'
            Output output = new Output();
            // Check if the filename is nothing
            if (file == "")
            {
                // Inform about what we are going to do
                output.Printline(Debug, "[Opret fil]");
                // Tell the client to write a filename
                output.Printline(Debug, "Indtast et filnavn: ");
                // Trim the end in case of a whitespace
                file = Console.ReadLine().TrimEnd();
                // If they didnt type anything and file is still nothing
                if (file == "")
                {
                    // Declare file name
                    file = "output.txt";
                }
            }
            // Check if the path of this program + filename exists
            if (!File.Exists(Path.Combine(Directory.GetCurrentDirectory(), file)))
            {
                // Create the file
                File.Create(Path.Combine(Directory.GetCurrentDirectory(), file));
                // Check if the file exists
                if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), file)))
                {
                    // Inform that the file is created
                    output.Printline(Debug, $"{file} er nu oprettet");
                }
            }
            // Return the path of the file
            path = Path.Combine(Directory.GetCurrentDirectory(), file);
            filename = file;
        }
        public void GetStandartPath(string file, out string filename)
        {
            if (file == "")
            {
                // Declare file name
                file = "output.txt";
            }
            filename = file;
        }

        // Delete file function
        public void Delete(bool Debug, string file)
        {
            Output output = new Output();
            if (file == "")
            {
                output.Printline(Debug, "[Slet fil]");
                output.Printline(Debug, "Indtast et filnavn");
            }
            // Check if the file exists
            if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), file)))
            {
                // Delete the file
                File.Delete(Path.Combine(Directory.GetCurrentDirectory(), file));
                // Check if the file is still there
                if (!File.Exists(Path.Combine(Directory.GetCurrentDirectory(), file)))
                {
                    // Inform that we deleted the file
                    output.Printline(Debug, $"{file} er nu slettet");
                }
            }
        }
        // Write text to a file
        public void WriteText(bool Debug, string file, string input)
        {
            // Check if the file exists
            if (!File.Exists(file))
            {
                // Use our create function
                Create(Debug, file, out file, out string tmp);
            }
            // Write the text ot the file
            File.WriteAllText(file, input);
        }

        public bool CheckPassword(bool debug, string pw, string un)
        {
            Output output = new Output();
            string specialCh = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=-""";
            char[] specialChar = specialCh.ToCharArray();
            int charNum = 0;

            // checks for Special characters.
            foreach (char ch in specialChar)
            {
                if (pw.Contains(specialChar[charNum]))  
                {      
                    //checks Length.
                    if (pw.Length > 12)
                    {   //checks for blank spaces.
                        if (!pw.Contains(" "))
                        {   //Checls for both upper and lower case letters.
                            if (pw.Any(char.IsUpper) && pw.Any(char.IsLower))
                            {   //checks first and last character in password for letters.
                                if (char.IsLetter(pw[0]) && char.IsLetter(pw[pw.Length - 1]))
                                {   //makes sure password isn't the same as username.
                                    if(pw.ToLower() != un.ToLower())
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        output.Printline(debug, "username and password cant be the same");
                                    }
                                }
                                else
                                {
                                    output.Printline(debug, "you can't have a number at the front or end");
                                }
                            }
                            else
                            {
                                output.Printline(debug, "Use both upper and lower case letters");
                            }
                        }
                        else
                        {
                            output.Printline(debug, "You Can't use spaces");
                        }
                    }
                    else
                    {
                        output.Printline(debug, "password is too short");
                    }
                    return false;
                }
                else
                {
                    charNum++;
                }

            }
            output.Printline(debug, "Password failed\nYou need to use at least one special charecter");
            return false;

        }
    }
    class Output
    {
        public bool Debug { get; set; }

        //funktion outs key.
        public void KeyPress(out ConsoleKey tasts)
        {   
            //gets key.
            tasts = Console.ReadKey().Key;
            Console.Clear();
        }

        
        public void Printline(bool debug, string print)
        {
            //from passed in boll finds out what uotput method is used.
            if (debug)
            {
                System.Diagnostics.Debug.WriteLine($"{print} ");
                Console.Clear();
            }
            else
            {
                Console.WriteLine($"{print} ");
            }
        }

    }
}

