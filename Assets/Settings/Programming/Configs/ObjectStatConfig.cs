using Settings.Programming.Enums;
using UnityEngine;

namespace Settings.Programming.Configs
{
    public class ObjectStatConfig : ScriptableObject
    {
        public float range;
        public float attack;
        public float reloadTime;
        public AttackType attackType;
        
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