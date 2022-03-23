using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_III
{
    public static class ClassCouncil
    {
        public static void SchoolMeans(string input, string output)
        {
            var means = new Dictionary<string, List<double>>();
            using (StreamReader reader = new StreamReader(input))
            {
                //  Console.WriteLine(reader.ReadLine());
                //  Console.WriteLine(reader.ReadLine());
                while (!reader.EndOfStream)
                {
                    string[] contenu = reader.ReadLine().Split(';');
                    string matiere = contenu[1];
                    string note = contenu[2].Replace('.', ',');
                    if (means.ContainsKey(matiere))
                        means[matiere].Add(float.Parse(note));
                    if (!means.ContainsKey(matiere))
                        means.Add(matiere, new List<double>() { float.Parse(note) });


                }



            }
            using (StreamWriter writer = new StreamWriter(output))
            {
                foreach (var matiere in means)
                {
                    writer.WriteLine($"{matiere.Key};{matiere.Value.Average()}");
                }

            }
        }
    }
}
