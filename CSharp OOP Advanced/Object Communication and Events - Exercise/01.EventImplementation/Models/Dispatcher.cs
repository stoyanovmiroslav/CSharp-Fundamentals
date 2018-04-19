using System;
using System.Collections.Generic;
using System.Text;

namespace _01.EventImplementation
{
    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);

    public class Dispatcher
    {
        public event NameChangeEventHandler NameChange;

        private string name;


        public void OnNameChange(NameChangeEventArgs args)
        {
            if (this.NameChange != null)
            {
                this.NameChange.Invoke(this, args);
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                OnNameChange(new NameChangeEventArgs(value));
                name = value;
            }
        }
    }
}
