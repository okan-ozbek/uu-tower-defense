using UnityEngine;

public class HitscanAbilityData : AbilityData
{ 
    public HitscanAbilityData(HitscanAbilityConfig config) : base(config)
    {
        abilityType = AbilityType.Hitscan;
    }
}