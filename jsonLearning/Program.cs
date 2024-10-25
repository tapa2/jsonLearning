using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;



public class PublishingHouse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
}

public class Book
{

    [JsonPropertyName("Title")]
    public string Name { get; set; }
    public PublishingHouse PublishingHouse { get; set; }
}

class Program
{

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string jsonContent = File.ReadAllText("books.json");
        List<Book> books = JsonSerializer.Deserialize<List<Book>>(jsonContent);

        Console.WriteLine("Books deserialized:");
        foreach (var book in books)
        {
            Console.WriteLine($"Title: {book.Name}, Publishing House: {book.PublishingHouse.Name}");
        }

        var options = new JsonSerializerOptions
        {
            WriteIndented = true 
        };

        string serializedJson = JsonSerializer.Serialize(books, options);
        File.WriteAllText("output.json", serializedJson);
        Console.WriteLine("\nBooks serialized and saved to output.json");
    }
}
