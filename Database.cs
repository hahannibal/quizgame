using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizgame
{
    public static class Database
    {
        /// <summary>
        /// Contains the name of the Database for an easier handling
        /// </summary>
        /// <returns>The name of the database</returns>
        public static string DataBaseName()
        {
            string x = "Database.txt";
            return x;
        }
        /// <summary>
        /// Check if the Database file exists. If not, creates it.
        /// </summary>
        public static void FileExist()
        {
            if (File.Exists(DataBaseName()))
            {
                return;
            }
            var filestream = File.Create(DataBaseName());
            filestream.Close();
        }


    }
}
