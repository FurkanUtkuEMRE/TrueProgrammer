using TrueProgrammer.Core;
using TrueProgrammer.Interfaces;

namespace TrueProgrammer.Characters
{
    /// <summary>
    /// Defines the Skeleton character. A basic enemy that can crunch bones.
    /// </summary>
    internal class Skeleton : Character
    {
        /// <summary>
        /// Sets the name of the character.
        /// </summary>
        public override string Name => "SKELETON";

        /// <summary>
        /// Defines the standard attack for the Skeleton character.
        /// </summary>
        public override IAttack StandardAttack { get; } = new BoneCrunch();

        /// <summary>
        /// Initializes the character with 5 hit points.
        /// </summary>
        public Skeleton() : base(5) { }
    }

    /// <summary>
    /// "BONE CRUNCH" attack for the Skeleton character. Deals either 0 or 1 points of damage.
    /// </summary>
    internal class BoneCrunch : IAttack
    {
        /// <summary>
        /// Creates new random number generator.
        /// </summary>
        private static readonly Random random = new Random();

        /// <summary>
        /// Sets the name of the attack.
        /// </summary>
        public string Name => "BONE CRUNCH";

        /// <summary>
        /// Creates new attack data. Called when a character uses an attack. Stores the damage value.
        /// </summary>
        /// <returns>AttackData with Damage = 0, 1</returns>
        public AttackData CreateAttackData() => new AttackData(random.Next(2));
    }
}
