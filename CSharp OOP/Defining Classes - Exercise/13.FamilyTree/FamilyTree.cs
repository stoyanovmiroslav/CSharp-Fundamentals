using System;
using System.Collections.Generic;
using System.Text;


public class FamilyTree
{
    private List<Children> childrens = new List<Children>();
    private List<Parent> parents = new List<Parent>();
    private PersonTree person;

    public PersonTree Person
    {
        get { return person; }
        set { person = value; }
    }

    public List<Parent> Parents
    {
        get { return parents; }
        set { parents = value; }
    }

    public List<Children> Childrens
    {
        get { return childrens; }
        set { childrens = value; }
    }
}

