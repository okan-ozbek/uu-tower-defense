using UnityEngine;
using System.Collections;

public abstract class AbstractAbilityData
{
    private AbilityConfig _config;

    public float range;
    public float damage;
    public float cooldown;
    public float count;
    public TargetType targetType;
    public AbilityType abilityType;

    private float _timeSinceLastUse;

    public AbilityData(AbilityConfig config)
    {
        _config = config;

        range = config.range;
        damage = config.damage;
        cooldown = config.cooldown;
        count = config.count;
        targetType = config.targetType;
    }

    public bool OnCooldown()
    {
        return _timeSinceLastUse < cooldown;
    }

    public void ResetCooldown()
    {
        _timeSinceLastUse = 0.0f;
    }

    public void Update(float deltaTime)
    {
        _timeSinceLastUse += deltaTime;
    }
}