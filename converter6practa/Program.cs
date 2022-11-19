using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using Newtonsoft.Json;
namespace converter6practa
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Путь до файла");
            string putDoFaila = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Нажмите F1 чтобы сохранить файл");
            Console.WriteLine(Preobrazovanie.ConvertToText(putDoFaila));
            while (true) {
                if (Console.ReadKey().Key == ConsoleKey.F1)
                {
                    break;
                };
            }
            Console.Clear();
            Console.WriteLine("Путь до файла чтобы сохранить");
            string putDlyaSohranenia = Console.ReadLine();
            Preobrazovanie.SaveFile(putDoFaila, putDlyaSohranenia);
            Console.Clear();
            Console.WriteLine("Сохранено!");

        }
    }
}