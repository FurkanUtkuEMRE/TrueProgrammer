using TrueProgrammer.Core;
using TrueProgrammer.Interfaces;

namespace TrueProgrammer.Characters
{
    /// <summary>
    /// Defines the True Programmer character. Main character that is a master of the code and can punch.
    /// </summary>
    internal class TrueProgrammerCharacter : Character
    {
        /// <summary>
        /// Sets the name of the character.
        /// </summary>
        public override string Name { get; }

        /// <summary>
        /// Defines the standard attack for the True Programmer character.
        /// </summary>
        public override IAttack StandardAttack { get; } = new Punch();

        /// <summary>
        /// Sets the name of the character and initializes the character with 25 hit points.
        /// </summary>
        /// <param name="name">Name of the character.</param>
        public TrueProgrammerCharacter(string name) : base(25) => Name = name;
    }

    /// <summary>
    /// "PUNCH" attack for the True Programmer character. Reliably deals a single point of damage.
    /// </summary>
    internal class Punch : IAttack
    {
        /// <summary>
        /// Sets the name of the attack.
        /// </summary>
        public string Name => "PUNCH";

        /// <summary>
        /// Creates new attack data. Called when a character uses an attack. Stores the damage value.
        /// </summary>
        /// <returns>AttackData with Damage = 1</returns>
        public AttackData CreateAttackData() => new AttackData(1);
    }
}
