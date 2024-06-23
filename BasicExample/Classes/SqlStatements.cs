namespace BasicExample.Classes;
public class SqlStatements
{
    public static string InsertImage => 
        """
        INSERT INTO [dbo].[Pictures1] 
            (
                [Photo], 
                Description
            ) 
        VALUES 
        (
            @ByteArray, 
            @Description
        )
        """;

    public static string SelectImageByIdentifier => 
        """
        SELECT 
            id, 
            Photo,
            Description
        FROM 
            dbo.Pictures1 
        WHERE 
            dbo.Pictures1.id = @id;
        """;

    public static string ReadAllImages => 
        """
        SELECT 
            Id,
            Photo,
            [Description] 
        FROM 
            dbo.Pictures1
        """;
}
