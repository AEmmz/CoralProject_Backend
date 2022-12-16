using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CoralApplication.Models;

public class UserModel
{
    public UserModel(string firstName, string lastName, string email, string username)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Username = username;
    }

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
}