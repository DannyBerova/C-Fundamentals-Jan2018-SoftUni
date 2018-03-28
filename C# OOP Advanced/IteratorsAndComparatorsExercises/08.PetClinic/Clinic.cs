using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Clinic : IEnumerable<Pet>
{
    private int numOfRooms;
    private readonly int startRoom;
    private int fullRooms;
    private Pet[] pets;

    public Clinic(string name, int numOfRooms)
    {
        this.Name = name;
        this.NumOfRooms = numOfRooms;
        this.startRoom = numOfRooms / 2;
        this.fullRooms = 0;
        this.pets = new Pet[this.numOfRooms];
    }

    public string Name { get; set; }

    public int NumOfRooms
    {
        get
        {
            return this.numOfRooms;
        }
        set
        {
            if (value % 2 == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            this.numOfRooms = value;
        }
    }

    public bool Add(Pet pet)
    {
        if (!HasEmptyRooms())
        {
            return false;
        }

        int currentRoom = this.startRoom;
        bool searchToTheLeft = true;
        int move = 0;
        int movesCount = 0;

        while (this.pets[currentRoom] != null && move <= this.pets.Length / 2)
        {
            if (searchToTheLeft)
            {
                currentRoom = this.startRoom - move;
            }
            else
            {
                currentRoom = this.startRoom + move;
            }

            searchToTheLeft = !searchToTheLeft;
            movesCount++;

            if (movesCount == 2)
            {
                move++;
                movesCount = 0;
            }
        }

        if (this.pets[currentRoom] == null)
        {
            this.fullRooms++;
            this.pets[currentRoom] = pet;
            return true;
        }

        return false;
    }

    public bool Release()
    {
        for (int i = this.startRoom; i < this.pets.Length; i++)
        {
            if (pets[i] != null)
            {
                var indexOfPet = Array.IndexOf(this.pets, pets[i]);
                this.pets[indexOfPet] = null;
                this.fullRooms--;
                return true;
            }
        }

        for (int i = 0; i < this.startRoom; i++)
        {
            if (pets[i] != null)
            {
                var indexOfPet = Array.IndexOf(this.pets, pets[i]);
                this.pets[indexOfPet] = null;
                this.fullRooms--;
                return true;
            }
        }

        return false;
    }

    public bool HasEmptyRooms()
    {
        if (this.fullRooms < this.numOfRooms)
        {
            return true;
        }

        return false;
    }

    public string Print()
    {
        var sb = new StringBuilder();

        foreach (var pet in this.pets)
        {
            if (pet == null)
            {
                sb.AppendLine("Room empty");
            }
            else
            {
                sb.AppendLine(pet.ToString());
            }
        }

        return sb.ToString().Trim();
    }

    public string Print(int roomNumber)
    {
        var sb = new StringBuilder();
        var pet = this.pets[roomNumber - 1];

        if (pet == null)
        {
            sb.AppendLine("Room empty");
        }
        else
        {
            sb.AppendLine(pet.ToString());
        }

        return sb.ToString().Trim();
    }

    public IEnumerator<Pet> GetEnumerator()
    {
        for (int i = 0; i < this.pets.Length; i++)
        {
            yield return this.pets[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

