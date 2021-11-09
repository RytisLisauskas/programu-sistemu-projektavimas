using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ValidatorsUnitTests.Source.Base.Repository
{
    public class UserRepository
    {

        IFormatter formatter = new BinaryFormatter();
        private const string FILENAME = "data.txt";

        public bool SaveAll(User[] users)
        {
            try
            {
                Stream stream = new FileStream(FILENAME, FileMode.OpenOrCreate, FileAccess.Write);
                formatter.Serialize(stream, users);
                stream.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not save to file");
                return false;
            }
        }

        public User[] LoadAll()
        {
            try
            {
                Stream stream = new FileStream(FILENAME, FileMode.OpenOrCreate, FileAccess.Read);
                if (stream.Length != 0)
                {
                    User[] users = (User[])formatter.Deserialize(stream);
                    return users;
                }
                else return new User[0];
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not load data from file");
                return new User[0];
            }
        }
    }
}

