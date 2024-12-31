using DTOs;
using Unity.VisualScripting;
using UnityEngine;

namespace Controllers.Towers.Attacks
{
    public class ConeAttack : AttackStrategy
    {
        private const float ConeAngle = 45.0f;
        
        private float _distanceBetweenProjectiles;
        
        public ConeAttack(TowerAttackDTO towerAttackDTO) : base(towerAttackDTO)
        {
            
        }

        protected override bool Action(GameObject target, float deltaTime)
        {
            if (target == false)
            {
                return false;
            }
            
            _distanceBetweenProjectiles = ConeAngle / TowerAttackDTO.Count;
            
            for (int i = 0; i < TowerAttackDTO.Count; i++)
            {
                float angle = -ConeAngle / 2 + i * _distanceBetweenProjectiles;
                
                Object.Instantiate(
                    TowerAttackDTO.ProjectilePrefab, 
                    TowerAttackDTO.Tower.transform.position, 
                    TowerAttackDTO.Tower.transform.rotation * Quaternion.Euler(Vector3.forward * angle)
                );

                InvokeOnAttack();
            }

            return true;
        }
    }
}