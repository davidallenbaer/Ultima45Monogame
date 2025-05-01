using System;
using System.Text.RegularExpressions;

namespace Ultima45Monogame
{
    public class DiceRoller
    {
        private static Random rng = new Random();

        /// <summary>
        /// Rolls the specified number of dice of a given type and applies a modifier.
        /// </summary>
        /// <param name="diceType">The dice type as an integer (4, 6, 8, 10, 12, 20, 100).</param>
        /// <param name="numberOfDice">How many dice to roll.</param>
        /// <param name="modifier">A modifier to add (or subtract) from the total roll.</param>
        /// <returns>The total roll result with modifier applied.</returns>
        public static int RollDice(int numberOfDice, int diceType, int modifier = 0)
        {
            /*
                Example usage:
                int result = DiceRoller.RollDice(1, 20, 3); // Equivalent to 1d20+3
            */

            int total = 0;
            for (int i = 0; i < numberOfDice; i++)
            {
                int roll = rng.Next(1, diceType + 1);
                total += roll;
                Console.WriteLine($"Rolled a d{diceType}: {roll}");
            }

            total += modifier;
            Console.WriteLine($"Modifier: {modifier}");
            Console.WriteLine($"Total: {total}");
            return total;
        }

        /// <summary>
        /// Parses a dice notation string (e.g., "2d6+1") and rolls the dice.
        /// </summary>
        /// <param name="notation">A dice roll notation string.</param>
        /// <returns>The total roll result.</returns>
        public static int RollFromString(string notation)
        {
            /*
                Example Usage:
                int result1 = DiceRoller.RollFromString("1d20+5"); // Rolls one d20 plus 5
                int result2 = DiceRoller.RollFromString("2d6-1");  // Rolls two d6 minus 1
                int result3 = DiceRoller.RollFromString("d100");   // Rolls one d100 (defaults to 1 die)
            */
            var match = Regex.Match(notation.Trim().ToLower(), @"^(\d*)d(\d+)([+-]\d+)?$");

            if (!match.Success)
            {
                throw new ArgumentException("Invalid dice notation. Example: '2d6+1'");
            }

            int numberOfDice = string.IsNullOrEmpty(match.Groups[1].Value) ? 1 : int.Parse(match.Groups[1].Value);
            int diceType = int.Parse(match.Groups[2].Value);
            int modifier = 0;

            if (!string.IsNullOrEmpty(match.Groups[3].Value))
            {
                modifier = int.Parse(match.Groups[3].Value);
            }

            return RollDice(diceType, numberOfDice, modifier);
        }
    }
}