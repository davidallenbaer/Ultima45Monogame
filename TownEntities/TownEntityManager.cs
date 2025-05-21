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
    private List<TownEntity> _townEntities = new();

    public void AddEntity(Maps townMap, string entityName, string entityType, int entityid, int startY, int startX, int tileValue, bool visible, int movement, int schedule, int dialogindex)
    {
        _townEntities.Add(new TownEntity(townMap, entityName, entityType, entityid, startY, startX, tileValue, visible, movement, schedule, dialogindex));
    }

    public void RemoveEntityAt(Maps townMap, int currentY, int currentX)
    {
        _townEntities.RemoveAll(e => e.TownMap == townMap && e.CurrentX == currentX && e.CurrentY == currentY);
    }

    public void RemoveEntityByEntityID(Maps townMap, int entityID)
    {
        _townEntities.RemoveAll(e => e.TownMap == townMap && e.EntityID == entityID);
    }

    public TownEntity? GetEntityAt(Maps townMap, int currentY, int currentX)
    {
        return _townEntities.FirstOrDefault(e => e.TownMap == townMap && e.CurrentX == currentX && e.CurrentY == currentY);
    }

    public TownEntity? GetEntityByEntityID(Maps townMap, int entityID)
    {
        return _townEntities.FirstOrDefault(e => e.TownMap == townMap && e.EntityID == entityID);
    }

    // Default constructor
    public TownEntityManager()
    {
    }

    // Constructor that accepts a list of TownEntity
    public TownEntityManager(List<TownEntity> townEntities)
    {
        if (townEntities != null)
            _townEntities = new List<TownEntity>(townEntities);
        else
            _townEntities = new List<TownEntity>();
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