#nullable disable
using System.Runtime.InteropServices;
using JsonQuestions.Controls;
using JsonQuestions.Models;
using Serilog;

namespace JsonQuestions.Classes;

public static class ButtonOperations
{
    public static List<DataButton> ButtonsList { get; set; }
    public static List<Container> Containers { get; set; }
    public static int Top { get; set; }
    public static int Left { get; set; }
    public static int Width { get; set; }
    public static int HeightPadding { get; set; }
    public static string BaseName { get; set; } = "Button";
    public static EventHandler EventHandler { get; set; }
    public static Control ParentControl { get; set; }
    private static int _index = 1;
    private static int _questionCount;


    public static void Initialize(ButtonSetup sender)
    {

        ParentControl = sender.Control;
        Top = sender.Top;
        HeightPadding = sender.BaseHeightPadding;
        Left = sender.Left;
        Width = sender.Width;
        EventHandler = sender.ButtonClick;
        ButtonsList = [];
        _questionCount = sender.QuestionCount;

        var methodName = $"{nameof(ButtonOperations)}.{nameof(Initialize)}";

        // allows developer to see what was created for debug purposes
        Log.Information("{Caller} Top: {Top} Left: {Left}", methodName, sender.Top, sender.Left);
            
    }

    private static void CreateButton(Container container)
    {
        var button = new DataButton()
        {
            Name = $"{BaseName}{_index}",
            Text = container.QuestionIdentifier.ToString(),
            Width = Width,
            Height = 29,
            Location = new Point(Left, Top),
            Parent = ParentControl,
            Identifier = container.Id,
            Container = container,
            Visible = true
        };

        button.Click += EventHandler;

        var methodName = $"{nameof(ButtonOperations)}.{nameof(CreateButton)}";

        // allows developer to see what was created for debug purposes
        Log.Information("{Caller} Name: {Name} Id: {CategoryId} Location {Left},{Right}", 
            methodName, button.Name, container.Id, Left, Top);

        ButtonsList.Add(button);

        ParentControl.Controls.Add(button);
        Top += HeightPadding;
        _index += 1;

    }

    public static void BuildButtons()
    {
        Containers = Random.Shared
            .GetItems<Container>(CollectionsMarshal.AsSpan(JsonOperations.GetQuestions()), _questionCount)
            .ToList();

        for (int index = 0; index < Containers.Count; index++)
        {
            Containers[index].QuestionIdentifier = index + 1;
        }

        foreach (var container in Containers)
        {
            CreateButton(container);
        }
    }
}