using System;
using System.IO;// для того чтобы использовать метод StreamWriter нужно добавить этот using 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using addressbook_web_tests; //для того чтобы методы из другого проекта необходимо добавить reference к этому +
//проекту и потом обращаться к namespace через using

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            for (int i = 0; i < count; i++)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                  TestBase.GenerateRandomString(10),
                  TestBase.GenerateRandomString(10),
                  TestBase.GenerateRandomString(10)));
            }
            writer.Close();
        }
        
    }
}
