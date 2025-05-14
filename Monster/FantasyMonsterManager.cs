using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Ultima45Monogame
{
    [Serializable]
    public class FantasyMonsterManager
    {
        private List<FantasyMonster> _monsters = new();

        // Default constructor
        public FantasyMonsterManager()
        {
        }

        // Constructor that accepts a list of FantasyMonster
        public FantasyMonsterManager(List<FantasyMonster> monsters)
        {
            if (monsters != null)
                _monsters = new List<FantasyMonster>(monsters);
            else
                _monsters = new List<FantasyMonster>();
        }

        public void AddMonster(FantasyMonster monster)
        {
            if (monster == null) throw new ArgumentNullException(nameof(monster));
            _monsters.Add(monster);
        }

        public void RemoveMonster(int id)
        {
            var monster = _monsters.Find(m => m.ID == id);
            if (monster != null)
                _monsters.Remove(monster);
        }

        public FantasyMonster? GetMonster(int id)
        {
            return _monsters.Find(m => m.ID == id);
        }

        public FantasyMonster? GetMonster(string name)
        {
            return _monsters.Find(m => m.Name == name);
        }

        public List<FantasyMonster> GetAllMonsters()
        {
            return new List<FantasyMonster>(_monsters);
        }

        public void SaveToFile(string filePath)
        {
            var serializer = new XmlSerializer(typeof(List<FantasyMonster>));
            using var stream = new FileStream(filePath, FileMode.Create);
            serializer.Serialize(stream, _monsters);
        }

        public static FantasyMonsterManager LoadFromFile(string filePath)
        {
            var serializer = new XmlSerializer(typeof(List<FantasyMonster>));
            using var stream = new FileStream(filePath, FileMode.Open);
            var monsters = (List<FantasyMonster>)serializer.Deserialize(stream)!;
            return new FantasyMonsterManager(monsters);
        }
    }
}
