using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsgFiskDll.Logical.ApiCalls
{
    internal class Utils
    {
        public static void SaveJsonBodyToFile(string body, string filePath)
        {
            try
            {
                string _filePath = filePath; // Set the desired path here
                // Serialize the body to JSON
                File.WriteAllText(_filePath, body); // Save to the file
            }
            catch (Exception ex)
            {
                throw new Exception("Error while saving the JSON body to file: " + ex.Message);
            }
        }
    }
}
