using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Nix_Project
{
    class Serialization
    {
        static public void SerializeInFile(string path, Hotel c)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            if (File.Exists(path))
                File.Delete(path);

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, c);
            }
        }

        static public Hotel DeserializeFromFile(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                Hotel c = formatter.Deserialize(fs) as Hotel;
                return c;
            }
        }
    }
}
