﻿using System;
using System.Collections.Generic;
using System.Text;


class Trainer
{
    private string name;
    private int numberOfBadges;
    private List<Pokemon> pokemons;

    public Trainer(string name, Pokemon pokemons)
    {
        this.name = name;
        this.pokemons = new List<Pokemon>{ pokemons };
    }

    public List<Pokemon> Pokemons
    {
        get { return pokemons; }
        set { pokemons = value; }
    }

    public int NumberOfBadges
    {
        get { return numberOfBadges; }
        set { numberOfBadges = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
}

