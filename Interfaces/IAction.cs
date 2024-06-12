using TrueProgrammer.Core;

namespace TrueProgrammer.Interfaces
{
    /// <summary>
    /// Defines what all action possibilities in the system must look like.
    /// </summary>
    internal interface IAction
    {
        /// <summary>
        /// Runs the action, giving the action the full context of the battle and the character who is running the action.
        /// If an action needs additional information, then they should typically "request" those by having parameters
        /// for them in their constructors, and save them to fields for use when `Run` is called.
        /// </summary>
        /// <param name="battleData">Information about the battle.</param>
        /// <param name="actingCharacter">Currently acting character.</param>
        void Run(Battle battleData, Character actingCharacter) { }
    }
}
