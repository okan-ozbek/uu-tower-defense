using UnityEngine;

public class AttackStat
{
    private TowerAttackConfig _attackConfig;

    public Stat<float> Value;
    public Stat<float> Cooldown;

    public AttackType AttackType => _attackConfig.attackType;

    public AttackStat(TowerAttackConfig attackConfig)
    {
        _attackConfig = attackConfig;

        Value = new Stat<float>(attackConfig.value);
        Cooldown = new Stat<float>(attackConfig.cooldown);
    }

    public bool CanAttack() => _attackConfig.CanAttack();
    public void ResetReloadTime() => _attackConfig.ResetReloadTime();
}