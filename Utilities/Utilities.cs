using System.IO;
using System.Xml.Serialization;
using Ultima45Monogame.Player;

namespace Ultima45Monogame
{
    public static class Utilities
    {

        public static void SerializeFantasyPlayers(FantasyPlayerManager manager, string filePath)
        {
            manager.SaveToFile(filePath);
        }

        public static FantasyPlayerManager DeserializeFantasyPlayers(string filePath)
        {
            return FantasyPlayerManager.LoadFromFile(filePath);
        }

        public static void SerializeOverworldEntities(OverworldEntityManager manager, string filePath)
        {
            manager.SaveToFile(filePath);
        }

        public static OverworldEntityManager DeserializeOverworldEntities(string filePath)
        {
            return OverworldEntityManager.LoadFromFile(filePath);
        }

        public static void SerializeSaveGameVariables(Ultima4SaveGameVariables saveGame, string filePath)
        {
            string directory = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var serializer = new XmlSerializer(typeof(Ultima4SaveGameVariables));
            using (var writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, saveGame);
            }
        }

        public static Ultima4SaveGameVariables DeserializeSaveGameVariables(string filePath)
        {
            var serializer = new XmlSerializer(typeof(Ultima4SaveGameVariables));
            using (var reader = new StreamReader(filePath))
            {
                return (Ultima4SaveGameVariables)serializer.Deserialize(reader);
            }
        }

        public static void SerializeFantasyPlayer(FantasyPlayer player, string filePath)
        {
            string directory = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var serializer = new XmlSerializer(typeof(FantasyPlayer));
            using (var writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, player);
            }
        }

        public static FantasyPlayer DeserializeFantasyPlayer(string filePath)
        {
            var serializer = new XmlSerializer(typeof(FantasyPlayer));
            using (var reader = new StreamReader(filePath))
            {
                return (FantasyPlayer)serializer.Deserialize(reader);
            }
        }
    }
}