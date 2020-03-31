using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMembers.Model{
    /// <summary>
    /// A class that uses a text file to store information about the gym members long-term.
    /// </summary>
    class MemberDB : ObservableObject    {
        /// <summary>
        /// The list of members to be saved.
        /// </summary>
        private ObservableCollection<Member> members;
        /// <summary>
        /// Where the database is stored.
        /// </summary>
        private const string filepath = "../members.txt";

        public MemberDB() { }

        /// <summary>
        /// Creates a new member database.
        /// </summary>
        /// <param name="m">The list to saved from or written to.</param>
        public MemberDB(ObservableCollection<Member> m)        {
            members = m;
        }

        /// <summary>
        /// Reads the saved text file database into the program's list of members.
        /// </summary>
        /// <returns>The list containing the text file data read in.</returns>
        public ObservableCollection<Member> GetMemberships()        {
            try            {
                StreamReader input = new StreamReader(new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Read));
                input.Close();
            }
            catch (FileNotFoundException)            {
                Console.WriteLine("File not found");
            }
            catch (FormatException)            {
                Console.WriteLine("Invalid e-mail address format.");
            }
            return members;
        }

        public void SaveMemberships(ObservableCollection<Member> newMembers)        {
            try            {
                using (StreamWriter output = new StreamWriter(new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write)))                {
                    foreach (Member m in newMembers)                    {
                        output.Write(m.GetDisplayText());
                        output.WriteLine();
                    }
                }
            }
            catch (Exception)            {
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// Saves the program's list of members into the text file database.
        /// </summary>
        public void SaveMemberships()
        {
            try
            {
                using (StreamWriter output = new StreamWriter(new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write)))
                {
                    foreach (Member m in members)
                    {
                        output.Write(m.GetDisplayText());
                        output.WriteLine();
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("");
            }
        }
    }
}
