using System.Collections.Generic;
using static Ultima45Monogame.RPGEnums;

namespace Ultima45Monogame
{
    public static class TownEntityFactory
    {
        /// <summary>
        /// Returns a list of all default TownEntities.
        /// </summary>
        public static List<TownEntity> GetAllTownEntities()
        {
            var entities = new List<TownEntity>();

                entities.Add(new TownEntity(
                    townMap: Maps.U4MapLordBritishCastle2,
                    entityName: "Lord British",
                    entityType: "NPC",
                    entityId: 1,
                    startY: 7,
                    startX: 19,
                    tileValue: (int)TileType.LordBritish1,
                    visible: true,
                    movement: 0,
                    schedule: 0,
                    dialogindex: 1
                ));

            return entities;
        }

    }
}