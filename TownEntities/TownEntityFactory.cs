using System.Collections.Generic;
using static Ultima45Monogame.RPGEnums;

namespace Ultima45Monogame
{
    public static class TownEntityFactory
    {
        /// <summary>
        /// Returns a list of all default TownEntities for a given map.
        /// </summary>
        public static List<TownEntity> GetDefaultTownEntities(Maps townMap)
        {
            var entities = new List<TownEntity>();

            if (townMap == Maps.U4MapBritain)
            {
                entities.Add(new TownEntity(
                    townMap: Maps.U4MapBritain,
                    entityName: "Iolo",
                    entityType: "NPC",
                    entityId: 1,
                    startY: 10,
                    startX: 12,
                    tileValue: 83,
                    visible: true,
                    movement: 0,
                    schedule: 0,
                    dialogindex: 1
                ));
                // Add more entities as needed...
            }
            // Add other towns and their default entities here as needed

            return entities;
        }

    }
}