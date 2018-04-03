using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CreateCustomClassAttribute
{
    public class CustomAttribute : Attribute
    {
        private string author;
        private int revision;
        private string description;
        private List<string> reviewers;

        public CustomAttribute(string author, int revision, string description, params string[] reviewers)
        {
            this.Author = author;
            this.Revision = revision;
            this.Description = description;
            this.Reviewers = new List<string>(reviewers);
        }

        public List<string> Reviewers
        {
            get { return reviewers; }
            private set { reviewers = value; }
        }

        public string Description
        {
            get { return description; }
            private set { description = value; }
        }

        public int Revision
        {
            get { return revision; }
            private set { revision = value; }
        }

        public string Author
        {
            get { return author; }
            private set { author = value; }
        }
    }
}
