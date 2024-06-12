using TrueProgrammer.Characters;
using TrueProgrammer.Core;
using TrueProgrammer.Helpers;
using TrueProgrammer.Interfaces;

ColoredConsole.WriteLine("You walk into the depths of the dungeon knowing full well you will encounter evil here.", ConsoleColor.Yellow);
ColoredConsole.WriteLine("THE UNCODED ONE tortured these circuits long enough you think. You will face any evil you encounter and end his tyranny.", ConsoleColor.Yellow);
ColoredConsole.Continue();

// Let the user pick a name for their character. Uppercase for consistency.
string playerName = ColoredConsole.Prompt("What is your name?").ToUpper();
Console.Clear();
ColoredConsole.WriteLine($"Welcome {ColoredConsole.UppercaseFirstLetter(playerName)}.", ConsoleColor.Cyan);
ColoredConsole.Continue();

// Let the user pick a gameplay mode and then create players based on the choice they made.
ColoredConsole.WriteLine("Game Mode Selection:", ConsoleColor.Cyan);
Console.WriteLine("1 - Player vs Computer");
Console.WriteLine("2 - Computer vs. Computer");
Console.WriteLine("3 - Player vs. Player");
string gameModeSelection = ColoredConsole.Prompt("What mode do you want to use?");
ColoredConsole.Continue();

// Create the players based on the game mode selection.
IPlayer firstPlayer, secondPlayer;

if (gameModeSelection == "1") { firstPlayer = new ConsolePlayer(); secondPlayer = new ComputerPlayer(); }
else if (gameModeSelection == "2") { firstPlayer = new ComputerPlayer(); secondPlayer = new ComputerPlayer(); }
else { firstPlayer = new ConsolePlayer(); secondPlayer = new ConsolePlayer(); }

// Construct the hero party. Put first player in charge of this party.
Party heroParty = new Party(firstPlayer);
heroParty.Characters.Add(new TrueProgrammerCharacter(playerName));

// Construct all the monster parties now.
List<Party> monsterParties = new List<Party> { CreateWeakMonsterParty(secondPlayer), CreateStrongMonsterParty(secondPlayer), CreateBossMonsterParty(secondPlayer) };

// Loop through all the battles, assuming the hero is going to win them all...
for (int battleNumber = 0; battleNumber < monsterParties.Count; battleNumber++)
{
    // Create the battle between the two and run it to completion.
    Party monsterParty = monsterParties[battleNumber];

    switch (battleNumber)
    {
        // Display the appropriate message based on the battle number.
        case 0:
            ColoredConsole.WriteLine("Your walk is cut short.", ConsoleColor.Yellow);
            ColoredConsole.WriteLine("You have encountered a weak monster party! There is a single SKELETON unsheating its sword...", ConsoleColor.Yellow);
            break;
        case 1:
            ColoredConsole.WriteLine("As the first SKELETON falls, TWO MORE rise from the ground!", ConsoleColor.Yellow);
            ColoredConsole.WriteLine("Prepare yourself!", ConsoleColor.Yellow);
            ColoredConsole.Continue();
            ColoredConsole.WriteLine("You rush into battle with determination.", ConsoleColor.Yellow);
            break;
        case 2:
            ColoredConsole.WriteLine("Two more SKELETONs shatter into bone splinters.", ConsoleColor.Yellow);
            ColoredConsole.WriteLine("You feel the air getting heavier.", ConsoleColor.Yellow);
            ColoredConsole.WriteLine("It's getting harder and harder to keep your eyes open...", ConsoleColor.DarkYellow);
            ColoredConsole.WriteLine("Ground shakes and the air is filled with a dark mist.", ConsoleColor.DarkYellow);
            ColoredConsole.Continue();
            ColoredConsole.WriteLine("THE UNCODED ONE appears right before your eyes!", ConsoleColor.Red);
            break;
    }

    Battle battle = new Battle(heroParty, monsterParty);
    battle.Run();

    // If our assumption was wrong and the heroes all died off, then end the game.
    if (heroParty.Characters.Count == 0) break;
}

// Display who won.
if (heroParty.Characters.Count > 0) ColoredConsole.WriteLine("You have defeated The Uncoded One's forces! You have won the battle!", ConsoleColor.Cyan);
else ColoredConsole.WriteLine("You have been defeated. The Uncoded One has won.", ConsoleColor.Red);


// Create the monster party for the first battle.
Party CreateWeakMonsterParty(IPlayer controllingPlayer)
{
    Party monsters = new Party(controllingPlayer);
    monsters.Characters.Add(new Skeleton());
    return monsters;
}

// Create the monster party for the second battle.
Party CreateStrongMonsterParty(IPlayer controllingPlayer)
{
    Party monsters = new Party(controllingPlayer);
    monsters.Characters.Add(new Skeleton());
    monsters.Characters.Add(new Skeleton());
    return monsters;
}

// Create the monster party for the third and final battle, boss battle.
Party CreateBossMonsterParty(IPlayer controllingPlayer)
{
    Party monsters = new Party(controllingPlayer);
    monsters.Characters.Add(new TheUncodedOne());
    return monsters;
}
