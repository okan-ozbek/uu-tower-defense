using System.Collections.Generic;
using Programming.Abilities.Factories;
using Programming.Configs;
using Programming.Data;
using UnityEngine;

namespace Programming.Models
{
    public class AbilityModel : Model
    {
        [SerializeField] private List<AbstractAbilityConfig> configs;

        public List<AbstractAbilityData> Abilities { get; private set; }
        
        public override void Initialize()
        {
            Abilities = new List<AbstractAbilityData>();
            
            foreach (var config in configs)
            {
                Abilities.Add(AbilityDataFactory.Create(config));
            }
        }
    }
}