using UnityEngine;

public class ProjectileAbilityConfig : AbilityConfig
{
    public readonly AbilityType abilityType = AbilityType.Projectile;

    public float projectileSpeed;
    public GameObject projectilePrefab;
}