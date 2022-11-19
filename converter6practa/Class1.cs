using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace converter6practa
{
    public class Figura
    {
        public string name;
        public int width;
        public int height;
        public Figura()
        {

        }
        public Figura(string Name, int Height, int Width)
        {
            name=Name;
            height=Height;
            width=Width;
        }
    }
    public class Preobrazovanie
    {
        private static List<Figura> ConvertToObject(string file)
        {
            List<Figura> figury = new List<Figura>();
            if (file.Contains(".xml"))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Figura>));
                using (FileStream fs = new FileStream(file, FileMode.Open))
                {
                    figury = (List<Figura>)xml.Deserialize(fs);
                }
            }
            if (file.Contains(".json"))
            {
                figury = JsonConvert.DeserializeObject<List<Figura>>(File.ReadAllText(file));
            }

            if (file.Contains(".txt"))
            {
                string[] linii = File.ReadAllLines(file);
                for (int i = 0; i < linii.GetLength(0); i = i + 3)
                {
                    Figura figura = new Figura();
                    if (i != linii.GetLength(0))
                    {
                        figura.name = linii[i];
                    }
                    else break;
                    if (i + 1 != linii.GetLength(0))
                    {
                        figura.width = Convert.ToInt32(linii[i + 1]);

                    }
                    else break;
                    if (i + 2 != linii.GetLength(0))
                    {
                        figura.height = Convert.ToInt32(linii[i + 2]);
                    }
                    else break;
                    figury.Add(figura);
                }
            }
            return figury;
        }
        public static string ConvertToText(string file)
        {
            string text = "";
            List<Figura> figury = ConvertToObject(file);
            for (int i = 0; i < figury.Count(); i++)
            {
                text = text + figury[i].name + "\n";
                text = text + figury[i].height + "\n";
                text = text + figury[i].width + "\n";
            }
            return text;
        }
        public static void SaveFile(string oldFile, string newFile)
        {
            List<Figura> figury = ConvertToObject(oldFile);
            if (newFile.Contains(".xml"))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Figura>));
                using (FileStream fs = new FileStream(newFile, FileMode.OpenOrCreate))
                {
                    xml.Serialize(fs, figury);
                }
            }
            if (newFile.Contains(".json"))
            {
                File.WriteAllText(newFile, JsonConvert.SerializeObject(figury));
            }
            if (newFile.Contains(".txt"))
            {
                File.WriteAllText(newFile, ConvertToText(newFile));
            }
        }
    }
}
