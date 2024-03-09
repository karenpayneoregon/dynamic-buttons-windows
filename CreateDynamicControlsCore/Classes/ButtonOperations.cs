using CreateDynamicControlsCore.Classes.Containers;
using CreateDynamicControlsCore.Classes.Controls;
using Serilog;

namespace CreateDynamicControlsCore.Classes;

public static class ButtonOperations
{
    public static List<DataButton> ButtonsList { get; set; }
    public static int Top { get; set; }
    public static int Left { get; set; }
    public static int Width { get; set; }
    public static int HeightPadding { get; set; }
    public static string BaseName { get; set; } = "Button";
    public static EventHandler EventHandler { get; set; }
    public static Control ParentControl { get; set; }
    private static int _index = 1;


    public static void Initialize(ButtonSetup sender)
    {

        ParentControl = sender.Control;
        Top = sender.Top;
        HeightPadding = sender.BaseHeightPadding;
        Left = sender.Left;
        Width = sender.Width;
        EventHandler = sender.ButtonClick;
        ButtonsList = new List<DataButton>();

        var methodName = $"{nameof(ButtonOperations)}.{nameof(Initialize)}";
        Log.Information("{Caller} Top: {Top} Left: {Left}", methodName, sender.Top, sender.Left);
            
    }

    private static void CreateCategoryButton(string text, int categoryIdentifier)
    {

        var button = new DataButton()
        {
            Name = $"{BaseName}{_index}",
            Text = text,
            Width = Width,
            Height = 29,
            Location = new Point(Left, Top),
            Parent = ParentControl,
            Identifier = categoryIdentifier,
            Visible = true,
            ImageAlign = ContentAlignment.MiddleLeft,
            TextAlign = ContentAlignment.MiddleRight
        };

        button.Click += EventHandler;

        var methodName = $"{nameof(ButtonOperations)}.{nameof(CreateCategoryButton)}";
        Log.Information("{Caller} Name: {Name} CategoryId: {CategoryId} Location {Left},{Right}", 
            methodName, button.Name, categoryIdentifier, Left, Top);

        ButtonsList.Add(button);

        ParentControl.Controls.Add(button);
        Top += HeightPadding;
        _index += 1;

    }

    public static void BuildButtons()
    {
        foreach (var category in DataOperations.ReadCategories())
        {
            CreateCategoryButton(category.Name, category.Id);
        }
    }
}