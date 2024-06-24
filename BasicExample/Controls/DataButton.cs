using System.ComponentModel;
#nullable disable
namespace BasicExample.Controls;

/// <summary>
/// Adds a property for storing category primary key and image to display
/// </summary>
public class DataButton : Button
{
    [Category("Behavior"), Description("Identifier")]
    public int Identifier { get; set; }
    [Category("Behavior"), Description("Stash")]
    public string Stash { get; set; }

    public Image Picture { get; set; }
}