using TrueProgrammer.Core;
using TrueProgrammer.Interfaces;

namespace TrueProgrammer.Characters
{
    /// <summary>
    /// Defines the The Uncoded One character. Big bad boss that can unravel the code.
    /// </summary>
    internal class TheUncodedOne : Character
    {
        /// <summary>
        /// Sets the name of the character.
        /// </summary>
        public override string Name => "THE UNCODED ONE";

        /// <summary>
        /// Defines the standard attack for the The Uncoded One character.
        /// </summary>
        public override IAttack StandardAttack { get; } = new Unraveling();

        /// <summary>
        /// Initializes the character with 15 hit points.
        /// </summary>
        public TheUncodedOne() : base(15) { }
    }

    /// <summary>
    /// "UNRAVELING" attack for the The Uncoded One character. Deals between 0 to 2 points of damage.
    /// </summary>
    internal class Unraveling : IAttack
    {
        /// <summary>
        /// Creates new random number generator.
        /// </summary>
        private static readonly Random random = new Random();

        /// <summary>
        /// Sets the name of the attack.
        /// </summary>
        public string Name => "UNRAVELING";

        /// <summary>
        /// Creates new attack data. Called when a character uses an attack. Stores the damage value.
        /// </summary>
        /// <returns>AttackData with Damage = 0, 1, 2</returns>
        public AttackData CreateAttackData() => new AttackData(random.Next(3));
    }
}
