using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Ultima45Monogame;
using static Ultima45Monogame.Game1;

[Serializable]
public class OverworldEntityManager
{
    public List<OverworldEntity> Entities { get; set; } = new List<OverworldEntity>();

    public void AddEntity(string entityType, int x, int y, int tileValue, bool visible, MoveDirection entityfacing = MoveDirection.None)
    {
        Entities.Add(new OverworldEntity(entityType, x, y, tileValue, visible, entityfacing));
    }

    public void RemoveEntityAt(int x, int y)
    {
        Entities.RemoveAll(e => e.X == x && e.Y == y);
    }

    public void RemoveEntityByEntityType(string entityType)
    {
        Entities.RemoveAll(e => e.EntityType == entityType);
    }

    public OverworldEntity? GetEntityAt(int x, int y)
    {
        return Entities.FirstOrDefault(e => e.X == x && e.Y == y);
    }

    public OverworldEntity? GetEntityByEntityType(string entityType)
    {
        return Entities.FirstOrDefault(e => e.EntityType == entityType);
    }

    public void SaveToFile(string filePath)
    {
        var serializer = new System.Xml.Serialization.XmlSerializer(typeof(OverworldEntityManager));
        using var writer = new StreamWriter(filePath);
        serializer.Serialize(writer, this);
    }

    public static OverworldEntityManager LoadFromFile(string filePath)
    {
        var serializer = new System.Xml.Serialization.XmlSerializer(typeof(OverworldEntityManager));
        using var reader = new StreamReader(filePath);
        return (OverworldEntityManager)serializer.Deserialize(reader);
    }
}
