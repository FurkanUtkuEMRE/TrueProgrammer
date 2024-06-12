using TrueProgrammer.Core;

namespace TrueProgrammer.Interfaces
{
    /// <summary>
    /// Represents a player, one of entities that control characters and pick actions for them when it is the character's turn.
    /// </summary>
    internal interface IPlayer
    {
        /// <summary>
        /// Allows the player to choose an action for the character to take. Battle is provided as context,
        /// so that it has the information it needs to make good decisions.
        /// </summary>
        /// <param name="battleData">Information about the battle.</param>
        /// <param name="actingCharacter">Currently acting character.</param>
        /// <returns></returns>
        IAction ChooseAction(Battle battleData, Character actingCharacter);
    }
}
