using TrueProgrammer.Interfaces;

namespace TrueProgrammer.Core
{
    /// <summary>
    /// Core class for all characters in the game.
    /// </summary>
    internal abstract class Character
    {
        /// <summary>
        /// Character name.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Standart attack for the character.
        /// </summary>
        public abstract IAttack StandardAttack { get; }

        /// <summary>
        /// Remaining HP of the character. Used to store the current hit point of the character.
        /// </summary>
        private int RemainingHP { get; set; }

        /// <summary>
        /// Gets or sets the current hit points for the character, ensuring it always stays at or above zero and at or below MaxHP.
        /// </summary>
        public int HP
        {
            get => RemainingHP;
            set => RemainingHP = Math.Clamp(value, 0, MaxHP);
        }

        /// <summary>
        /// Maximum hit points for the character.
        /// </summary>
        public int MaxHP { get; }

        /// <summary>
        /// Returns true if the character is alive.
        /// </summary>
        public bool IsAlive => HP > 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Character"/> class with the specified initial hit points.
        /// Character will start with both HP and MaxHP initialized.
        /// </summary>
        /// <param name="initialHP">Specified initial hit points.</param>
        public Character(int initialHP)
        {
            MaxHP = initialHP;
            HP = initialHP;
        }
    }
}
