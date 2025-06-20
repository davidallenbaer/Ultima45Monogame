using System;
using System.Collections.Generic;

namespace Ultima45Monogame
{
    public static class FantasySpellFactory
    {
        public static List<FantasySpell> GetAllSpells()
        {
            var spells = new List<FantasySpell>();

            // Example spell entry
            spells.Add(new FantasySpell(
                id: 1,
                name: "Fireball",
                level: 3,
                school: "Evocation",
                castingTime: "1 action",
                range: "150 feet",
                components: "V, S, M (a tiny ball of bat guano and sulfur)",
                duration: "Instantaneous",
                description: "A bright streak flashes from your pointing finger to a point you choose within range and then blossoms with a low roar into an explosion of flame.",
                cost: 0
            ));

            // Add more spells here...

            return spells;
        }
    }
}
