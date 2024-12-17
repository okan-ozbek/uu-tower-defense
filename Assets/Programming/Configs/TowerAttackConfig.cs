using UnityEngine;

namespace Programming.Configs
{
    [CreateAssetMenu(fileName = "TowerAttackConfig", menuName = "Settings/Configs/TowerAttackConfig")]
    public class TowerAttackConfig : ScriptableObject
    {
        public float value;
        public float cooldown;
        public AttackType attackType;
        public StatType statType;

        private float _timePassed = cooldown;
    
        public bool CanAttack()
        {
            if (_timePassed >= cooldown)
            {
                return true;
            }

            _timePassed += Time.deltaTime;
            return false;
        }

        public void ResetReloadTime()
        {
            _timePassed = 0.0f;
        }
    }
}