using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;//позволяет работать с ITable

namespace addressbook_web_tests
{
    class AddressBookDB : LinqToDB.Data.DataConnection //позволяет работать  с бд.
    {
        public AddressBookDB() : base("AddressBook") { }// конструктор вызывает конструктор базового класса и указывает имя бд

        public ITable<GroupData> Groups { get { return GetTable<GroupData>(); } }//метод возвращает таблицу данных GroupData
        public ITable<ContactData> Contacts { get { return GetTable<ContactData>(); } }////метод возвращает таблицу данных ContactData
    }
}
