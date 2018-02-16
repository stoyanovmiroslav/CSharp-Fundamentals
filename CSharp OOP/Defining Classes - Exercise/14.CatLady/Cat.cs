using System;
using System.Collections.Generic;
using System.Text;


class Cat
{
    //public string Name { get; set; }
    //public string MyProperty { get; set; }


    private List<Cymric> cymric = new List<Cymric>();
    private List<StreetExtraordinaire> streetExtraordinaire = new List<StreetExtraordinaire>();
    private List<Siamese> siamese = new List<Siamese>();

    public List<Siamese> Siamese
    {
        get { return siamese; }
        set { siamese = value; }
    }

    public List<StreetExtraordinaire> StreetExtraordinaire
    {
        get { return streetExtraordinaire; }
        set { streetExtraordinaire = value; }
    }

    public List<Cymric> Cymric
    {
        get { return cymric; }
        set { cymric = value; }
    }
}

