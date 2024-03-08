namespace CreateDynamicControlsCore.Classes.Containers;
public class ButtonSetup
{
    public Control Control { get; set; }
    public int Top { get; set; }
    public int BaseHeightPadding { get; set; }
    public int Left { get; set; }
    public int Width { get; set; }
    public EventHandler ButtonClick { get; set; }

}
