﻿using System.Diagnostics.CodeAnalysis;

namespace CSharpEleven.MinorChanges;

internal class Person
{
    public string Name => $"{FirstName} {LastName}";

    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public string Phone { get; set; }
}

internal class Parent : Person
{
    [SetsRequiredMembers]
    public Parent() { }
}

internal class Room
{
    public required string Name { get; set; }
    public required string Subject { get; set; }

    public List<Person> Members { get; init; }

    [SetsRequiredMembers]
    public Room()
    {
        Subject = "Default";
        Members = new List<Person>();
    }
}

internal class ContactService
{
    public void AddPerson(string firstName, string lastName, string email)
    {
        var person = new Person
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email
        };

        var parent = new Parent();

        var room = new Room
        {
            Name = "Room"
        };

        room.Members.Add(person);
        room.Members.Add(parent);
    }
}

/*
 * required is only valid in class, struct, and record types. It is not valid in interface types. required cannot be combined with the following modifiers:
fixed
ref readonly
ref
const
static
 */