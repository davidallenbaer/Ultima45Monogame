using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Ultima45Monogame;
using static Ultima45Monogame.Game1;
using static Ultima45Monogame.RPGEnums;

[Serializable]
public class TownEntityManager
{
    public List<TownEntity> Entities { get; set; } = new List<TownEntity>();

    public void AddEntity(Maps townMap, string entityName, string entityType, int entityid, int startY, int startX, int tileValue, bool visible, int movement, int schedule, int dialogindex)
    {
        Entities.Add(new TownEntity(townMap, entityName, entityType, entityid, startY, startX, tileValue, visible, movement, schedule, dialogindex));
    }

    public void RemoveEntityAt(int currentY, int currentX)
    {
        Entities.RemoveAll(e => e.CurrentX == currentX && e.CurrentY == currentY);
    }

    public void RemoveEntityByEntityID(int entityID)
    {
        Entities.RemoveAll(e => e.EntityID == entityID);
    }

    public TownEntity? GetEntityAt(int currentY, int currentX)
    {
        return Entities.FirstOrDefault(e => e.CurrentX == currentX && e.CurrentY == currentY);
    }

    public TownEntity? GetEntityByEntityID(int entityID)
    {
        return Entities.FirstOrDefault(e => e.EntityID == entityID);
    }

    public void SaveToFile(string filePath)
    {
        var serializer = new System.Xml.Serialization.XmlSerializer(typeof(TownEntityManager));
        using var writer = new StreamWriter(filePath);
        serializer.Serialize(writer, this);
    }

    public static TownEntityManager LoadFromFile(string filePath)
    {
        var serializer = new System.Xml.Serialization.XmlSerializer(typeof(TownEntityManager));
        using var reader = new StreamReader(filePath);
        return (TownEntityManager)serializer.Deserialize(reader);
    }

}