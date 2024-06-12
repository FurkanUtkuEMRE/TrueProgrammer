using TrueProgrammer.Core;
using TrueProgrammer.Helpers;
using TrueProgrammer.Interfaces;

namespace TrueProgrammer.Actions
{
    /// <summary>
    /// An action type that executes an attack on a target.
    /// </summary>
    internal class AttackAction : IAction
    {
        /// <summary>
        /// Attack type to execute.
        /// </summary>
        private IAttack Attack { get; }

        /// <summary>
        /// Target of the attack.
        /// </summary>
        private Character Target { get; }

        /// <summary>
        /// Executes the attack on the target.
        /// </summary>
        /// <param name="attack">Attack type.</param>
        /// <param name="target">Target character.</param>
        public AttackAction(IAttack attack, Character target)
        {
            Attack = attack;
            Target = target;
        }

        /// <summary>
        /// Runs the action, which executes the attack on the target.
        /// </summary>
        /// <param name="battleData">Information on the battle.</param>
        /// <param name="actingCharacter">Character who is attacking.</param>
        public void Run(Battle battleData, Character actingCharacter)
        {
            Console.WriteLine();
            Console.WriteLine($"{actingCharacter.Name} used {Attack.Name} on {Target.Name}.");

            AttackData attackData = Attack.CreateAttackData();
            Target.HP -= attackData.Damage;

            Console.WriteLine($"{Attack.Name} dealt {attackData.Damage} damage to {Target.Name}.");
            Console.WriteLine($"{Target.Name} is now at {Target.HP}/{Target.MaxHP} HP.");

            if (!Target.IsAlive)
            {
                battleData.GetParty(Target).Characters.Remove(Target);
                Console.WriteLine($"{Target.Name} was defeated!");
            }

            ColoredConsole.Continue();
        }
    }
}
