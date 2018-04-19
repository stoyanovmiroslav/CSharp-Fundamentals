using System;
using System.Collections.Generic;
using System.Text;

namespace _02.ExtendedDatabase
{
    public class Person
    {
        private long id;
        private string userName;

        public Person(long id, string userName)
        {
            this.Id = id;
            this.UserName = userName;
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public long Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}