using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Ultima45Monogame.Player
{
    [Serializable]
    public class FantasyPlayerManager
    {
        private readonly List<FantasyPlayer> _players = new();

        // Default constructor
        public FantasyPlayerManager()
        {
        }

        // New constructor that accepts a list of FantasyPlayer
        public FantasyPlayerManager(List<FantasyPlayer> players)
        {
            if (players != null)
                _players = new List<FantasyPlayer>(players);
            else
                _players = new List<FantasyPlayer>();
        }

        public void AddPlayer(FantasyPlayer player)
        {
            if (player == null) throw new ArgumentNullException(nameof(player));
            _players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            var player = _players.Find(p => p.Name == name);
            if (player != null)
                _players.Remove(player);
        }

        public void RemovePlayer(int partyPlayerPosition)
        {
            var player = _players.Find(p => p.PartyPosition == partyPlayerPosition);
            if (player != null)
                _players.Remove(player);
        }

        public FantasyPlayer? GetPlayer(string name)
        {
            return _players.Find(p => p.Name == name);
        }

        public FantasyPlayer? GetPlayer(int partyPlayerPosition)
        {
            return _players.Find(p => p.PartyPosition == partyPlayerPosition);
        }

        public List<FantasyPlayer> GetAllPlayers()
        {
            return new List<FantasyPlayer>(_players);
        }

        public void SaveToFile(string filePath)
        {
            var serializer = new XmlSerializer(typeof(List<FantasyPlayer>));
            using var stream = new FileStream(filePath, FileMode.Create);
            serializer.Serialize(stream, _players);
        }

        public static FantasyPlayerManager LoadFromFile(string filePath)
        {
            var serializer = new XmlSerializer(typeof(List<FantasyPlayer>));
            using var stream = new FileStream(filePath, FileMode.Open);
            var players = (List<FantasyPlayer>)serializer.Deserialize(stream)!;
            return new FantasyPlayerManager(players);
        }

        public void HealAllPlayers()
        {
            foreach (var player in _players)
            {
                player.HP = player.MaxHP;
            }
        }
    }
}