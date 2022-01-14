using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;


namespace Filhant1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<person> persons = new List<person>();
 
           for ( int i = 0; i < 3; i++){
                
                Console.WriteLine("Skriv ner förnamn");
                string Fnam = Console.ReadLine();
                Console.WriteLine("Skriv ner efterenamn");
                string Enam = Console.ReadLine();
                persons.Add(new person() { Fname = Fnam, Lname = Enam });
                
            }
            foreach (person b in persons) 
            {
                Console.WriteLine($"Förnamn: {b.Fname}\n" +
                                  $"Efternamn {b.Lname}\n"); 

            }
            Console.WriteLine("Tryck enter för att spara filen");
            Console.ReadLine();

            FileStream fs = new FileStream("data.bin", FileMode.Create);

            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, persons);
            }
            catch(SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason " + e.Message);
            }
            finally 
            {
                fs.Close();
            }
             
        }
        [Serializable()]
        public class person
        {
            public string Fname { get; set; }
            public string Lname { get; set; }
        }

    }
    
}
