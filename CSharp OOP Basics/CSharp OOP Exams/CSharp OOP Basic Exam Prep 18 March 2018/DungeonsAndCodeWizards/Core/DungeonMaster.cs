using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class DungeonMaster
{
    private Stack<Item> itemPool = new Stack<Item>();
    private List<Character> party = new List<Character>();
    private int lastSurvivorRounds;

    public string JoinParty(string[] args)
    {
        string faction = args[0];
        string characterType = args[1];
        string name = args[2];

        CharacterFactory charactersFactory = new CharacterFactory();
        Character character = charactersFactory.CreateCharacter(faction, characterType, name);

        party.Add(character);
        return $"{name} joined the party!";
    }

    public string AddItemToPool(string[] args)
    {
        string itemName = args[0];
        ItemFactory itemsFactory = new ItemFactory();
        Item item = itemsFactory.CreateItem(itemName);

        if (item == null)
        {
            throw new ArgumentException("Invalid item \"{name}\"!");
        }

        itemPool.Push(item);
        return $"{itemName} added to pool.";
    }

    public string PickUpItem(string[] args)
    {
        string characterName = args[0];
        string itemName = "";

        Character character = FindCharacter(characterName);
        if (itemPool.Any() == false)
        {
            throw new InvalidOperationException("No items left in pool!");
        }

        Item item = itemPool.Pop();
        itemName = item.GetType().Name;
        character.Bag.AddItem(item);

        return $"{characterName} picked up {itemName}!";
    }

    public string UseItem(string[] args)
    {
        string characterName = args[0];
        string itemName = args[1];

        Character character = FindCharacter(characterName);
        Item item = character.Bag.GetItem(itemName);
        character.UseItem(item);

        return $"{characterName} used {itemName}.";
    }

    public string UseItemOn(string[] args)
    {
        string giverName = args[0];
        string receiverName = args[1];
        string itemName = args[2];

        Character characterGiver = FindCharacter(giverName);   // party.FirstOrDefault(x => x.Name == giverName);
        Character characterReceiver = FindCharacter(receiverName);   // party.FirstOrDefault(x => x.Name == receiverName);

        Item item = characterGiver.Bag.GetItem(itemName);
        characterGiver.UseItemOn(item, characterReceiver);


        return $"{giverName} used {itemName} on {receiverName}.";

    }

    public string GiveCharacterItem(string[] args)
    {
        string giverName = args[0];
        string receiverName = args[1];
        string itemName = args[2];

        Character characterGiver = FindCharacter(giverName);
        Character characterReceiver = FindCharacter(receiverName);

        Item item = characterGiver.Bag.GetItem(itemName);
        characterGiver.GiveCharacterItem(item, characterReceiver);

        return $"{giverName} gave {receiverName} {itemName}.";
    }

    public string GetStats()
    {
        var sortedCharacters = party.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health);
        var result = string.Join(Environment.NewLine, sortedCharacters);
        return result;
    }

    public string Attack(string[] args)
    {
        string attackerName = args[0];
        string receiverName = args[1];

        var attacker = FindCharacter(attackerName);
        var receiver = FindCharacter(receiverName);

        if (!(attacker is IAttackable attackerAsWarrior))
        {
            throw new ArgumentException($"{attackerName} cannot attack!");
        }
        attackerAsWarrior.Attack(receiver);

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

        if (receiver.IsAlive == false)
        {
            sb.AppendLine($"{receiver.Name} is dead!");
        }

        return sb.ToString().TrimEnd();
    }

    public string Heal(string[] args)
    {
        string healerName = args[0];
        string healingReceiverName = args[1];

        var healer = this.FindCharacter(healerName);
        var receiver = this.FindCharacter(healingReceiverName);

        if (!(healer is IHealable healingCharacter))
        {
            throw new ArgumentException($"{healer.Name} cannot heal!");
        }

        healingCharacter.Heal(receiver);

        string result = $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
        return result;
    }

    public string EndTurn(string[] args)
    {
        StringBuilder sb = new StringBuilder();

        foreach (var character in party.Where(x => x.IsAlive))
        {
            double healthBeforeRest = character.Health;
            character.Rest();
            sb.AppendLine($"{character.Name} rests ({healthBeforeRest} => {character.Health})");
        }

        int coutSurvived = party.Where(x => x.IsAlive).Count();

        if (coutSurvived <= 1)
        {
            lastSurvivorRounds++;
        }

        return sb.ToString().TrimEnd();
    }

    public bool IsGameOver()
    {
        if (lastSurvivorRounds >= 2)
        {
            return true;
        }
        return false;
    }

    private Character FindCharacter(string name)
    {
        var character = this.party.FirstOrDefault(e => e.Name == name);

        if (character == null)
        {
            throw new ArgumentException($"Character {name} not found!");
        }

        return character;
    }
}