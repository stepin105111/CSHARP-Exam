using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    [Serializable]
    class Student
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double PhoneNo { get; set; }
        public string State { get; set; }
        
        {
            return string.Format($"The name: {Name}\nAddress: {Address}\nPhone No: {PhoneNo}\nState: {State}");
        }
    }
    class BinarySerializationDemo
    {
        static void Main(string[] args)
        {
            BinarySerialization();
        }
        private static void BinarySerialization()
        {
            Console.Write("Serialize or Deserialize? (S/D): ");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "s")
                serialize();
            else
                deserialize();
        }

        private static void serialize()
        {
            Student s = new Student { Name = "Aneena", Address = "Trivandrum", PhoneNo = "9747378942", State = "Kerala"};
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("Demo.bin", FileMode.OpenOrCreate, FileAccess.Write);
            bf.Serialize(fs, s);
            fs.Close();
        }

        private static void deserialize()
        {
            FileStream fs = new FileStream("Demo.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            Student s = bf.Deserialize(fs) as Student;
            Console.WriteLine(s.Name);
            Console.WriteLine(s.Address);
            Console.WriteLine(s.PhoneNo);
            Console.WriteLine(s.State);
            fs.Close();
        }
    }
}
