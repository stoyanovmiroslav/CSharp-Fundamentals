using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

public class Clinic : IEnumerable<Pet>
{
    private string name;
    private Pet[] rooms;

    public Clinic(string name, int rooms)
    {
        this.ValidateRoomCount(rooms);
        this.Name = name;
        this.rooms = new Pet[rooms];
    }

    private void ValidateRoomCount(int rooms)
    {
        if (rooms % 2 == 0)
        {
            throw new ArgumentException("Invalid Operation!");
        }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public bool Add(Pet currentPet)
    {
        int startIndex = rooms.Length / 2;

        for (int i = 0; i <= rooms.Length / 2; i++)
        {
            if (rooms[startIndex - i] == null)
            {
                rooms[startIndex - i] = currentPet;
                return true;
            }
            if (rooms[startIndex + i] == null)
            {
                rooms[startIndex + i] = currentPet;
                return true;
            }
        }
        return false;
    }

    public bool Release()
    {
        int startIndex = this.rooms.Length / 2;

        for (int i = 0; i < this.rooms.Length; i++)
        {
            int currentIndex = (startIndex + i) % rooms.Length;

            if (this.rooms[currentIndex] != null)
            {
                this.rooms[currentIndex] = null;
                return true;
            }
        }
        return false;
    }

    public IEnumerator<Pet> GetEnumerator()
    {
        for (int i = 0; i < this.rooms.Length; i++)
        {
            yield return rooms[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public bool HasEmptyRooms()
    {
        for (int i = 0; i < this.rooms.Length; i++)
        {
            if (rooms[i] == null)
            {
                return true;
            }
        }

        return false;
    }

    public string PrintRoom(int roomNumber)
    {
        return rooms[roomNumber - 1]?.ToString() ?? "Room empty";
    }

    public string PrintAllRooms()
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 1; i <= this.rooms.Length; i++)
        {
            sb.AppendLine(this.PrintRoom(i));
        }

        return sb.ToString().TrimEnd();
    }
}