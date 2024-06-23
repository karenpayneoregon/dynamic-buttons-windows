using System.Data;
using BasicExample.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using static ConfigurationLibrary.Classes.ConfigurationHelper;
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.

namespace BasicExample.Classes;

internal class PhotoOperations
{
 
    /// <summary>
    /// Read image from database table by primary key
    /// </summary>
    /// <param name="identifier">Primary key</param>
    public static (bool success, PhotoContainer) ReadImage(int identifier)
    {
        using var cn = new SqlConnection(ConnectionString());
        var container =  cn.QueryFirstOrDefault<PhotoContainer>(SqlStatements.SelectImageByIdentifier, new {id = identifier});
        if (container is not null)
        {
            container.Picture = container.Photo.BytesToImage();

            return (true, container);
        }

        return (false, null);
    }
            
    /// <summary>
    /// Read all records for images
    /// </summary>
    public static List<PhotoContainer> Read()
    {
        using var cn = new SqlConnection(ConnectionString());
        return  cn.Query<PhotoContainer>(SqlStatements.ReadAllImages).AsList();
    }
}