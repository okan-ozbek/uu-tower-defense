using Programming.Entities.Enums;
using UnityEngine;

namespace Programming.Configs
{
    [CreateAssetMenu(fileName = "HitscanAbilityConfig", menuName = "Settings/Abilities/HitscanAbilityConfig")]
    public class HitscanAbilityConfig : AbstractAbilityConfig
    {
        public readonly AbilityType AbilityType = AbilityType.Hitscan;
    }
}