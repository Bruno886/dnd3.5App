using dnd3._5App.Models;

namespace dnd3._5App.Services;

/// <summary>
/// Pure calculation helpers for D&D 3.5 rules.
/// </summary>
public class RulesService
{
    private static readonly Dictionary<SizeCategory, int> SizeGrappleMods = new()
    {
        [SizeCategory.Fine] = -16,
        [SizeCategory.Diminutive] = -12,
        [SizeCategory.Tiny] = -8,
        [SizeCategory.Small] = -4,
        [SizeCategory.Medium] = 0,
        [SizeCategory.Large] = 4,
        [SizeCategory.Huge] = 8,
        [SizeCategory.Gargantuan] = 12,
        [SizeCategory.Colossal] = 16
    };

    public int AbilityMod(int score) => (int)Math.Floor((score - 10) / 2.0);

    public int AbilityScore(Character c, Ability ability) =>
        c.Abilities[ability] + c.AbilityTempMods[ability];

    public int BaseAttackBonus(Character c)
    {
        int total = 0;
        foreach (var cl in c.ClassLevels)
        {
            total += cl.BabProgression switch
            {
                BabProgression.Full => cl.Level,
                BabProgression.ThreeQuarter => (int)Math.Floor(cl.Level * 0.75),
                BabProgression.Half => cl.Level / 2,
                _ => 0
            };
        }
        return total;
    }

    private int BaseSave(int level, SaveProgression prog) => prog switch
    {
        SaveProgression.Good => 2 + (level - 1) / 2,
        SaveProgression.Poor => level / 3,
        _ => 0
    };

    public (int Fort, int Ref, int Will) Saves(Character c)
    {
        int bFort = 0, bRef = 0, bWill = 0;
        foreach (var cl in c.ClassLevels)
        {
            bFort += BaseSave(cl.Level, cl.SaveProgression.Fort);
            bRef += BaseSave(cl.Level, cl.SaveProgression.Ref);
            bWill += BaseSave(cl.Level, cl.SaveProgression.Will);
        }
        int fort = bFort + AbilityMod(AbilityScore(c, Ability.Con)) + c.SavesMisc.Fort;
        int reflex = bRef + AbilityMod(AbilityScore(c, Ability.Dex)) + c.SavesMisc.Ref;
        int will = bWill + AbilityMod(AbilityScore(c, Ability.Wis)) + c.SavesMisc.Will;
        return (fort, reflex, will);
    }

    public int Grapple(Character c)
    {
        var sizeMod = SizeGrappleMods[c.Size];
        return BaseAttackBonus(c) + AbilityMod(AbilityScore(c, Ability.Str)) + sizeMod + c.GrappleMisc;
    }

    public int Initiative(Character c) => AbilityMod(AbilityScore(c, Ability.Dex)) + c.InitiativeMisc;

    public (int Total, int Touch, int FlatFooted, int DexUsed) ArmorClass(Character c)
    {
        int dexMod = AbilityMod(AbilityScore(c, Ability.Dex));
        if (c.Ac.MaxDex.HasValue && dexMod > c.Ac.MaxDex.Value)
            dexMod = c.Ac.MaxDex.Value;
        int ac = 10 + dexMod + c.Ac.ArmorBonus + c.Ac.ShieldBonus + c.Ac.NaturalArmor + c.Ac.Deflection + c.Ac.Dodge + c.Ac.Misc;
        int touch = 10 + dexMod + c.Ac.Deflection + c.Ac.Dodge + c.Ac.Misc;
        int flat = 10 + c.Ac.ArmorBonus + c.Ac.ShieldBonus + c.Ac.NaturalArmor + c.Ac.Deflection + c.Ac.Misc;
        return (ac, touch, flat, dexMod);
    }

    public int MaxHp(Character c)
    {
        int conMod = AbilityMod(AbilityScore(c, Ability.Con));
        return c.Hp.Rolled.Sum() + conMod * c.Level + c.Hp.BonusPerLevel * c.Level + c.Hp.Misc;
    }

    public int SkillTotal(Character c, Skill skill)
    {
        double ranks = Math.Min(skill.Ranks, MaxRanks(c.Level, skill.IsClassSkill));
        int total = (int)Math.Floor(ranks) + AbilityMod(AbilityScore(c, skill.Ability)) + skill.Misc;
        if (skill.ArmorCheckApplies)
            total += c.Ac.ArmorCheckPenalty;
        return total;
    }

    public double MaxRanks(int level, bool isClassSkill) => isClassSkill ? level + 3 : (level + 3) / 2.0;

    private static readonly int[] LightLoads =
    {
        0,3,6,10,13,16,20,23,26,30,33,38,43,50,58,66,76,86,100,116,133,153,173,200,233,266,306,346,400,466
    };

    public (double Light, double Medium, double Heavy) CarryCapacities(int str)
    {
        if (str < 1) str = 1;
        if (str > 29) str = 29;
        double light = LightLoads[str];
        return (light, light * 2, light * 3);
    }

    public (LoadCategory Category, double Total, double Light, double Medium, double Heavy) Encumbrance(Character c)
    {
        double weight = c.Equipment.Sum(e => e.Weight * e.Qty) + c.Inventory.Sum(i => i.Weight * i.Qty);
        var (light, medium, heavy) = CarryCapacities(AbilityScore(c, Ability.Str));
        if (c.Encumbrance.CarryCapacityOverride.HasValue)
            heavy = c.Encumbrance.CarryCapacityOverride.Value;
        LoadCategory cat = weight <= light ? LoadCategory.Light : weight <= medium ? LoadCategory.Medium : weight <= heavy ? LoadCategory.Heavy : LoadCategory.Overloaded;
        return (cat, weight, light, medium, heavy);
    }
}
