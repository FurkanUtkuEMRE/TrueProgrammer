using TrueProgrammer.Interfaces;

namespace TrueProgrammer.Core
{
    /// <summary>
    /// Core class which represents a party of characters. It can include heroes or monsters.
    /// Contains the characters in the party and the player that is running the show for the party.
    /// </summary>
    internal class Party
    {
        /// <summary>
        /// Player that is making the decisions for the party.
        /// </summary>
        public IPlayer Player { get; }

        /// <summary>
        /// List of characters that are still alive in the party.
        /// </summary>
        public List<Character> Characters { get; } = new List<Character>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Party"/> class with the specified player.
        /// </summary>
        /// <param name="player">Player who will control the party.</param>
        public Party(IPlayer player) => Player = player;
    }
}
