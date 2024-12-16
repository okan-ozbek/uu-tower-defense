using Programming.Enums;
using Programming.Object.Enums;
using Programming.Towers.Enums;
using UnityEngine;

namespace Programming.Configs
{
    [CreateAssetMenu(fileName = "TowerStatConfig", menuName = "Settings/Configs/TowerStatConfig")]
    public class TowerStatConfig : ScriptableObject
    {
        public float cost;
        public float range;
        public float damage;
        public float reloadTime;
        public AttackType attackType;
        public TowerType towerType;
        
        private float _elapsedTime;
        
        public bool HasReloaded()
        {
            if (_elapsedTime > reloadTime)
            {
                return true;
            }

            _elapsedTime += Time.deltaTime;
            return false;
        }

        public void ResetReloadTime()
        {
            _elapsedTime = 0.0f;
        }
    }
}