using System.Diagnostics;
using BasicExample.Classes;
using BasicExample.Controls;
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.

#pragma warning disable CS8602 // Dereference of a possibly null reference.
namespace BasicExample;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        ButtonOperations.BaseName = "TheButton";


        var buttonSetup = new ButtonSetup
        {
            Control = this,
            Top = 20,
            BaseHeightPadding = 42,
            Left = 10,
            Width = 150,
            ButtonClick = ButtonClick
        };

        ButtonOperations.Initialize(buttonSetup);
        ButtonOperations.BuildButtons();
        var buttons = ButtonOperations.ButtonsList;

        foreach (var button in ButtonOperations.ButtonsList)
        {
            flowLayoutPanel1.Controls.Add(button);
        }

        var carButton = flowLayoutPanel1.Controls.OfType<DataButton>().FirstOrDefault(x => x.Text == "Miata");
        if (carButton.Picture is not null)
        {
            pictureBox1.Image = carButton?.Picture;
            ActiveControl = carButton;
        }
        
    }

    /// <summary>
    /// Assign image to PictureBox from Picture property of <see cref="DataButton"/>
    /// </summary>
    /// <param name="sender"><see cref="DataButton"/></param>
    private void ButtonClick(object? sender, EventArgs e)
    {
        var button = (DataButton)sender;
        var item = button.Picture;
        pictureBox1.Image = button.Picture;
    }
}
