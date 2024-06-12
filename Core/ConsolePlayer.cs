using TrueProgrammer.Actions;
using TrueProgrammer.Helpers;
using TrueProgrammer.Interfaces;

namespace TrueProgrammer.Core
{
    /// <summary>
    /// Player that interacts with the user through the console.
    /// </summary>
    internal class ConsolePlayer : IPlayer
    {
        /// <summary>
        /// Allows the player to choose an action for the character to take. Battle is provided as context,
        /// </summary>
        /// <param name="battleData">Battle information.</param>
        /// <param name="actingCharacter">Currently acting character.</param>
        /// <returns>Either a MenuChoice or DoNothingAction</returns>
        public IAction ChooseAction(Battle battleData, Character actingCharacter)
        {
            List<MenuChoice> menuChoices = CreateMenuOptions(battleData, actingCharacter);

            for (int index = 0; index < menuChoices.Count; index++)
                ColoredConsole.WriteLine($"{index + 1} - {menuChoices[index].Description}", menuChoices[index].Enabled ? ConsoleColor.Gray : ConsoleColor.DarkGray);

            string choice = ColoredConsole.Prompt("What do you want to do?");
            int menuIndex = Convert.ToInt32(choice) - 1;

            if (menuChoices[menuIndex].Enabled) return menuChoices[menuIndex].Action!;

            return new DoNothingAction();
        }

        /// <summary>
        /// Creates the menu options for the player to choose from.
        /// </summary>
        /// <param name="battleData">Battle information.</param>
        /// <param name="actingCharacter">Currently acting character.</param>
        /// <returns>MenuChoices List</returns>
        private List<MenuChoice> CreateMenuOptions(Battle battleData, Character actingCharacter)
        {
            Party playerParty = battleData.GetParty(actingCharacter);
            Party enemyParty = battleData.GetEnemyParty(actingCharacter);

            List<MenuChoice> menuChoices = new List<MenuChoice>();

            if (enemyParty.Characters.Count > 0)
                menuChoices.Add(new MenuChoice($"Standard Attack ({actingCharacter.StandardAttack.Name})", new AttackAction(actingCharacter.StandardAttack, enemyParty.Characters[0])));
            else
                menuChoices.Add(new MenuChoice($"Standard Attack ({actingCharacter.StandardAttack.Name})", null));

            menuChoices.Add(new MenuChoice("Do Nothing", new DoNothingAction()));

            return menuChoices;
        }
    }

    /// <summary>
    /// Represents a choice in the menu.
    /// </summary>
    /// <param name="Description">Choice description.</param>
    /// <param name="Action">Action.</param>
    record MenuChoice(string Description, IAction? Action)
    {
        public bool Enabled => Action != null;
    }
}
