using Programming.Configs;
using Programming.Object.Enums;
using Programming.Stats;
using Programming.Towers.Enums;
using UnityEngine;

namespace Programming.Models
{
    public class TowerModel : Model
    {
        [SerializeField] private TowerStatConfig statConfig;
        
        public Stat<float> Range;
        public Stat<float> Damage;
        public Stat<float> ReloadTime;

        public float Cost => statConfig.cost;
        public AttackType AttackType => statConfig.attackType;
        public TowerType TowerType => statConfig.towerType;
        
        public override void Initialize()
        {
            Range = new Stat<float>(statConfig.range);
            Damage = new Stat<float>(statConfig.damage);
            ReloadTime = new Stat<float>(statConfig.reloadTime);
        }
        
        public bool HasReloaded() => statConfig.HasReloaded();
        public void ResetReloadTime() => statConfig.ResetReloadTime();
    }
}