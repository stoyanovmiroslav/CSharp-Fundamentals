using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Race
{
    private int lenght;
    private string route;
    private int prizePool;
    private List<Car> participants;

    public Race(int length, string route, int prizePool)
    {
        this.Lenght = length;
        this.Route = route;
        this.PrizePool = prizePool;
        participants = new List<Car>();
    }

    public IReadOnlyCollection<Car> GetParticipants => participants as IReadOnlyCollection<Car>;

    public void AddParticipants(Car car)
    {
        participants.Add(car);
    }

    protected List<Car> Participants
    {
        get { return participants; }
        set { participants = value; }
    }

    public int PrizePool
    {
        get { return prizePool; }
        set { prizePool = value; }
    }

    public string Route
    {
        get { return route; }
        set { route = value; }
    }

    public int Lenght   
    {
        get { return lenght; }
        set { lenght = value; }
    }
}