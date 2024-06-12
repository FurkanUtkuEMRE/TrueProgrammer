namespace TrueProgrammer.Core
{
    /// <summary>
    /// Core class which represents a single instance of battle.
    /// Includes heroes and monsters.
    /// </summary>
    internal class Battle
    {
        /// <summary>
        /// Party of heroes that are fighting in the battle.
        /// </summary>
        public Party Heroes { get; }

        /// <summary>
        /// Party of monsters that are fighting in the battle.
        /// </summary>
        public Party Monsters { get; }

        /// <summary>
        /// Sets the heroes and monsters for the battle.
        /// </summary>
        /// <param name="heroes">Heroes.</param>
        /// <param name="monsters">Monsters.</param>
        public Battle(Party heroes, Party monsters)
        {
            Heroes = heroes;
            Monsters = monsters;
        }

        /// <summary>
        /// Indicates whether the game is over or not. This is based on whether a party has no characters left to fight.
        /// </summary>
        public bool IsOver => Heroes.Characters.Count == 0 || Monsters.Characters.Count == 0;

        /// <summary>
        /// Gives you the party that the character is in.
        /// </summary>
        /// <param name="character">Character the method runs for.</param>
        /// <returns></returns>
        public Party GetParty(Character character) => Heroes.Characters.Contains(character) ? Heroes : Monsters;

        /// <summary>
        /// Gives you the enemy party for the character.
        /// </summary>
        /// <param name="character">Character the method runs for.</param>
        /// <returns></returns>
        public Party GetEnemyParty(Character character) => Heroes.Characters.Contains(character) ? Monsters : Heroes;

        /// <summary>
        /// Runs the battle until it is over.
        /// </summary>
        public void Run()
        {
            while (!IsOver)
            {
                foreach (Party party in new[] { Heroes, Monsters })
                {
                    foreach (Character character in party.Characters)
                    {
                        Console.WriteLine($"{character.Name} is taking a turn...");
                        party.Player.ChooseAction(this, character).Run(this, character);
                        if (IsOver) break;
                    }
                    if (IsOver) break;
                }
            }
        }
    }
}
