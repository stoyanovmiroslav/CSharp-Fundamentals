using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    public string Name { get; set; }
    public Car Car { get; set; }
    public Company Company { get; set; }
    private List<Pokemon> pokemons = new List<Pokemon>();
    private List<Parent> parent = new List<Parent>();
    private List<Children> children = new List<Children>();

    public List<Children> Childrens
    {
        get { return children; }
        set { children = value; }
    }

    public List<Parent> Parents
    {
        get { return parent; }
        set { parent = value; }
    }

    public List<Pokemon> Pokemons
    {
        get { return pokemons; }
        set { pokemons = value; }
    }
}

