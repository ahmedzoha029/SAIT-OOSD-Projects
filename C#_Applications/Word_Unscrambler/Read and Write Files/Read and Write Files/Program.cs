using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Read_and_Write_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\835909\Documents\Data.txt";
            //string path1;



            //string[] data = { "Zoha,Ahmed,ahmez@ucalgary.ca","Rafat,Iqbal,riqbal@gmail.com" };
            //File.WriteAllLines(path, data);

            var output = File.ReadAllLines(path);

            List<string> output1 = File.ReadLines(path).ToList();

            List<Person> data = new List<Person>();
            // Rreading file and converting into objects
            foreach(var item in output1)
            {
                string[] value = item.Split(',');

                Person person = new Person();

                person.firstName = value[0];
                person.lastName = value[1];
                person.email = value[2];
                data.Add(person);
            }
            Console.WriteLine("Reading Files");
            foreach(var item in data)
            {
                    Console.WriteLine(item.firstName);
                    Console.WriteLine(item.lastName);
                    Console.WriteLine(item.email);
               
            }

            data.Add(new Person { firstName = "umer", lastName = "Siddiqui", email = "usiddiqui@gmail.com" });
            // wrting object in file
            List<string> writeData = new List<string>();

            foreach(var item in data)
            {
                writeData.Add($"{item.firstName},{item.lastName},{item.email}");

            }

            File.WriteAllLines(path, writeData);

            Console.WriteLine("Files Added");

            //foreach (var item in output1)
            //{
            //    Console.WriteLine(item);
            //}
            //for (var i = 0; i < output.Length; i++)
            //{
            //    Console.WriteLine(output[i]);
            //}


            //foreach(var line in File.ReadLines(path))
            //{
            //    Console.WriteLine(line);
            //}
            Console.ReadKey();

            //string[] lines = { "This is the first line", "This is the second line", " This is third lines" };
            //File.WriteAllLines("MyFirstLines", lines);

            //string[] lineread = File.ReadAllLines("MyFirstLines");

            //foreach(var line in File.ReadLines("MyFirstLines"))
            //{
            //    Console.WriteLine(line);
            //}


        }
    }
}
