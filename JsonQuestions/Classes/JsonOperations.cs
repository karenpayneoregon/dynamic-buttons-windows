#nullable disable
using System.Text.Json;
using JsonQuestions.Models;

namespace JsonQuestions.Classes;

public class JsonOperations
{
    public static string FileName => "questions.json";

    public static List<Container> GetQuestions() 
        => JsonSerializer.Deserialize<List<Container>>(File.ReadAllText(FileName));
}