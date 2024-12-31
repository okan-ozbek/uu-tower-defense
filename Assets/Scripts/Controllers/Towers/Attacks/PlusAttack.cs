using DTOs;
using UnityEngine;

namespace Controllers.Towers.Attacks
{
    public class PlusAttack : AttackStrategy
    {
        public PlusAttack(TowerAttackDTO towerAttackDTO) : base(towerAttackDTO)
        {
        }

        protected override bool Action(GameObject target, float deltaTime)
        {
            if (target == false)
            {
                return false;
            }
            

            for (int i = 0; i < TowerAttackDTO.Count; i++)
            {
                Object.Instantiate(
                    TowerAttackDTO.ProjectilePrefab, 
                    TowerAttackDTO.Tower.transform.position, 
                    Quaternion.Euler(Vector3.forward * i * (360f / TowerAttackDTO.Count))
                );
                
                InvokeOnAttack();
            }

            return true;
        }
    }
}