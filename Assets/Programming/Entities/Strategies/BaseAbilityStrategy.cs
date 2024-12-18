﻿using Programming.Entities.Stats;
using UnityEngine;

namespace Programming.Entities.Strategies
{
    public abstract class BaseAbilityStrategy : IAbilityStrategy
    {
        public abstract void Use(GameObject target, AbilityStat abilityStat);

        public bool Validated(GameObject target, AbilityStat abilityStat)
        {
            return (target && abilityStat.OnCooldown() == false);
        }
    }
}