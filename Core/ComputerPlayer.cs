using TrueProgrammer.Actions;
using TrueProgrammer.Interfaces;

namespace TrueProgrammer.Core
{
    /// <summary>
    /// Player that plays on its own. Simple AI for users to play against.
    /// </summary>
    internal class ComputerPlayer : IPlayer
    {
        /// <summary>
        /// Chooses and returns an action for the computer to take.
        /// </summary>
        /// <param name="battleData">Battle information.</param>
        /// <param name="actingCharacter">Currently acting character.</param>
        /// <returns>Either an AttackAction or DoNothingAction</returns>
        public IAction ChooseAction(Battle battleData, Character actingCharacter)
        {
            Thread.Sleep(500);

            List<Character> potentialTargets = battleData.GetEnemyParty(actingCharacter).Characters;
            if (potentialTargets.Count > 0) return new AttackAction(actingCharacter.StandardAttack, battleData.GetEnemyParty(actingCharacter).Characters[0]);

            return new DoNothingAction();
        }
    }
}
