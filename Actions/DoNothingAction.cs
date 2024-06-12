using TrueProgrammer.Core;
using TrueProgrammer.Interfaces;

namespace TrueProgrammer.Actions
{
    /// <summary>
    /// Represents an action that does nothing. Just shows a text saying that the character did nothing.
    /// </summary>
    internal class DoNothingAction : IAction
    {
        /// <summary>
        /// Runs the action, which shows a text.
        /// </summary>
        /// <param name="battleData">Information about the battle.</param>
        /// <param name="actingCharacter">Currently acting character.</param>
        void Run(Battle battleData, Character actingCharacter) => Console.WriteLine($"{actingCharacter.Name} did NOTHING.");
    }
}
