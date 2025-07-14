//    internal class 
using System.Collections.Generic;
using Ultima45Monogame;
using Ultima45Monogame.Player;
using static Ultima45Monogame.RPGEnums;

namespace Ultima45Monogame
{
    public static class FantasyReagentFactory
    {
        public static List<FantasyReagent> GetAllFantasyReagents()
        {
            return new List<FantasyReagent>
            {
                new FantasyReagent(0,"None","None",0),
                new FantasyReagent(1,"Black Pearl", "A rare and valuable reagent used in powerful spells.",0),
                new FantasyReagent(2,"Blood Moss", "A common reagent used in healing and necromantic magic.",0),
                new FantasyReagent(3,"Garlic","Often used in protective spells against undead creatures.",0),
                new FantasyReagent(4,"Ginseng", "A versatile reagent used in various restorative spells.",0),
                new FantasyReagent(5,"Mandrake Root", "A potent reagent known for its magical properties.",0),
                new FantasyReagent(6,"Nightshade","A dangerous reagent used in dark magic and poisons.",0),
                new FantasyReagent(7,"Spider Silk","A delicate reagent used in enchantments and crafting.",0),
                new FantasyReagent(8,"Sulfurous Ash","A reagent associated with fire magic and alchemy.",0)
            };
        }

        internal static FantasyReagent GetFantasyReagent(int reagentID)
        {
            foreach (var reagent in GetAllFantasyReagents())
            {
                if (reagent.ID == reagentID)
                    return reagent;
            }
            return null;
        }

        internal static FantasyReagent GetFantasyReagent(string reagentName)
        {
            foreach (var reagent in GetAllFantasyReagents())
            {
                if (reagent.Name == reagentName)
                    return reagent;
            }
            return null;
        }

        internal static List<FantasyReagent> GetFantasyReagentsByTownMerchant(Maps map, int townEntityIndex)
        {
            List<FantasyReagent> merchantReagents = new List<FantasyReagent>();

            if (map == Maps.U4MapNone)
            {
                return null;
            }
            else if (map == Maps.U4MapBritain && townEntityIndex == -1005)
            {
                //TODO
                //Britain Merchant Reagents
                merchantReagents.Add(GetFantasyReagent("None"));
            }

            return merchantReagents;
        }
    }
}