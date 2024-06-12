namespace TrueProgrammer.Interfaces
{
    /// <summary>
    /// Represents an attack that a character might have. Each attack has a name and the ability
    /// to produce attack data by request, for when somebody uses the attack.
    /// </summary>
    internal interface IAttack
    {
        /// <summary>
        /// Name of the attack.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Creates new attack data. Called when a character uses an attack.
        /// </summary>
        /// <returns>AttackData</returns>
        AttackData CreateAttackData();
    }

    /// <summary>
    /// The collection of information that defines a specific usage or occurence of an attack.
    /// </summary>
    /// <param name="Damage">Damage value.</param>
    public record AttackData(int Damage);
}
