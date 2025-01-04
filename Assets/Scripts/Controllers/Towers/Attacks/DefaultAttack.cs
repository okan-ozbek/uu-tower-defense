using System.Collections;
using DTOs;
using UnityEngine;

namespace Controllers.Towers.Attacks
{
    public class DefaultAttack : AttackStrategy
    {
        public DefaultAttack(TowerAttackDTO towerAttackDTO) : base(towerAttackDTO)
        {
        }

        protected override bool Action(GameObject target, float deltaTime)
        {
            if (target == false)
            {
                return false;
            }

            TowerAttackDTO.Tower.GetComponent<TowerAttackController>().StartCoroutine(BurstShot());
            return true;
        }

        private IEnumerator BurstShot()
        {
            Vector3 towerStaticPosition = TowerAttackDTO.Tower.transform.position;
            Quaternion towerStaticRotation = TowerAttackDTO.Tower.transform.rotation;
            
            for (int i = 0; i < TowerAttackDTO.Count; i++)
            {
                Object.Instantiate(
                    TowerAttackDTO.ProjectilePrefab, 
                    towerStaticPosition,
                    towerStaticRotation
                );
                
                InvokeOnAttack();
                
                yield return new WaitForSeconds(TowerAttackDTO.BurstCooldown);
            }
        }
    }
}