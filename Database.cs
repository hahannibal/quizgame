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
        /// Check if the Database file exists. If not, creates it.
        /// </summary>
        public static void FileExist()
        {
            if (File.Exists("Database.txt"))
            {
                return;
            }
            var filestream = File.Create("Database.txt");
            filestream.Close();
        }
    }
}
