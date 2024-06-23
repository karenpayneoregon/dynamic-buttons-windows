namespace BasicExample.Classes;
public static class Extensions
{
    public static Image BytesToImage(this byte[] bytes)
    {
        var imageData = bytes;
        using var ms = new MemoryStream(imageData, 0, imageData.Length);
        ms.Write(imageData, 0, imageData.Length);
        return Image.FromStream(ms, true); 
    }
}
