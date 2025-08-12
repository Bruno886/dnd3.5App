using dnd3._5App.Models;
using dnd3._5App.Services;
using Xunit;

namespace dnd3._5App.Tests;

public class RulesServiceTests
{
    private readonly RulesService _rules = new();

    private Character CreateBaseCharacter()
    {
        return new Character
        {
            Abilities = new AbilityScores { Str = 10, Dex = 10, Con = 10, Int = 10, Wis = 10, Cha = 10 },
            AbilityTempMods = new AbilityScores { Str = 0, Dex = 0, Con = 0, Int = 0, Wis = 0, Cha = 0 },
            ClassLevels = new List<ClassLevel> { new() { ClassName = "Fighter", Level = 3, BabProgression = BabProgression.Full, SaveProgression = new SaveProgressionSet { Fort = SaveProgression.Good, Ref = SaveProgression.Poor, Will = SaveProgression.Poor } } },
            Skills = new List<Skill>(),
            Equipment = new List<EquipmentItem>(),
            Inventory = new List<InventoryItem>(),
            Ac = new AcInfo()
        };
    }

    [Fact]
    public void AbilityMod_ComputesCorrectly()
    {
        Assert.Equal(4, _rules.AbilityMod(18));
        Assert.Equal(0, _rules.AbilityMod(10));
    }

    [Fact]
    public void Saves_GoodAndPoorProgression()
    {
        var c = CreateBaseCharacter();
        var saves = _rules.Saves(c);
        Assert.Equal(3 + _rules.AbilityMod(10), saves.Fort); // Base save 3 for level3 good
        Assert.Equal(1 + _rules.AbilityMod(10), saves.Ref);  // Base save 1 for level3 poor
        Assert.Equal(1 + _rules.AbilityMod(10), saves.Will); // same as reflex
    }

    [Fact]
    public void SkillTotal_IncludesArmorCheckPenalty()
    {
        var c = CreateBaseCharacter();
        c.Abilities.Dex = 12;
        c.Ac.ArmorCheckPenalty = -1;
        var skill = new Skill { Name = "Balance", Ability = Ability.Dex, Ranks = 2, ArmorCheckApplies = true, IsClassSkill = true };
        Assert.Equal(2, _rules.SkillTotal(c, skill)); // 2 ranks +1 dex -1 acp
    }

    [Fact]
    public void Encumbrance_HeavyWhenOverMedium()
    {
        var c = CreateBaseCharacter();
        c.Abilities.Str = 10; // light 33 medium 66 heavy100
        c.Inventory.Add(new InventoryItem { Name = "Rocks", Qty = 1, Weight = 70 });
        var enc = _rules.Encumbrance(c);
        Assert.Equal(LoadCategory.Heavy, enc.Category);
    }
}
