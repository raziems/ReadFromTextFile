using System;
using Newtonsoft.Json;
namespace ReadFromTextFile
{
    class Program
    {
        static void Main(string[] args)
        {
            //Textfile location
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\457129\OneDrive - Jabil\Desktop\release.txt");            

            ReleaseInfo releaseInfo = new ReleaseInfo();

            foreach (string line in lines)
            {
                if (line.Contains( "RELEASE"))
                {                    
                    releaseInfo.release = line.Replace("RELEASE:", string.Empty).Trim();                   
                }
                
            }

            releaseInfo.artifactory_url = lines[8];
            releaseInfo.other_version = new[] { lines[22], lines[23] };

            string json = JsonConvert.SerializeObject(releaseInfo, Formatting.Indented);
            Console.WriteLine(json);

            
        }
    }

    internal class ReleaseInfo
    {
        public string release { get; set; }
        public string artifactory_url { get; set; }
        public String[] other_version { get; set; }
    }
}
