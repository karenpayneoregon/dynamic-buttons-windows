using BasicExample.Controls;
using Serilog;
#nullable disable
namespace BasicExample.Classes;

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
        ButtonsList = [];

        var methodName = $"{nameof(ButtonOperations)}.{nameof(Initialize)}";

        // allows developer to see what was created for debug purposes
        Log.Information("{Caller} Top: {Top} Left: {Left}", methodName, sender.Top, sender.Left);
            
    }
    /// <summary>
    /// Create new <see cref="DataButton"/> and add to <see cref="ButtonsList"/>"/> and set Click event
    /// </summary>
    /// <param name="description">Description of image</param>
    /// <param name="identifier">Primary key of row for image</param>
    private static void CreateButton(string description, int identifier)
    {

        var ( _, photoContainer) = PhotoOperations.ReadImage(identifier);
        var button = new DataButton()
        {
            Name = $"{BaseName}{_index}",
            Text = description,
            Width = Width,
            Height = 29,
            Location = new Point(Left, Top),
            Parent = ParentControl,
            Identifier = identifier,
            Visible = true, 
            Picture = photoContainer.Picture
        };

        button.Click += EventHandler;

        var methodName = $"{nameof(ButtonOperations)}.{nameof(CreateButton)}";

        // allows developer to see what was created for debug purposes
        Log.Information("{Caller} Name: {Name} CategoryId: {CategoryId} Location {Left},{Right}", 
            methodName, button.Name, identifier, Left, Top);

        ButtonsList.Add(button);

        ParentControl.Controls.Add(button);
        Top += HeightPadding;
        _index += 1;

    }

    public static void BuildButtons()
    {
        foreach (var container in PhotoOperations.Read())
        {
            CreateButton(container.Description, container.Id);
        }
    }
}