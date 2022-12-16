using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CoralApplication.Models;

public class CoralModel
{
    public CoralModel(string name, double price, string primaryColor, string secondaryColor, string vendor, string website)
    {
        Name = name;
        Price = price;
        PrimaryColor = primaryColor;
        SecondaryColor = secondaryColor;
        Vendor = vendor;
        Website = website;
    }

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string Name { get; set; }
    public double Price { get; set; }
    public string PrimaryColor { get; set; }
    public string SecondaryColor { get; set; }
    public string Vendor { get; set; }
    public string Website { get; set; }
}