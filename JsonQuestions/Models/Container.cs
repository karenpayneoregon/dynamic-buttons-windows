#nullable disable
namespace JsonQuestions.Models;

public class Container
{
    public int Id { get; set; }
    public int QuestionIdentifier { get; set; }
    public string Question { get; set; }
    public string A { get; set; }
    public string B { get; set; }
    public string C { get; set; }
    public string D { get; set; }
    public string Answer { get; set; }
    public override string ToString() => Question;
}