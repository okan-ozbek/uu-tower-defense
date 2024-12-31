using System;
using DTOs;
using Models;
using UnityEngine;

namespace Controllers.Towers.Attacks
{
    public abstract class AttackStrategy
    {
        public static event Action OnAttack;
        
        private bool _onCooldown;
        private float _timePassed;

        protected TowerAttackDTO TowerAttackDTO;
        
        protected AttackStrategy(TowerAttackDTO towerAttackDTO)
        {
            TowerAttackDTO = towerAttackDTO;
        }

        public void Attack(GameObject target, float deltaTime)
        {
            if (_onCooldown)
            {
                CalculateCooldown(deltaTime);
                return;
            }
            
            if (Action(target, deltaTime))
            {
                _onCooldown = true;   
            }    
        }

        protected abstract bool Action(GameObject target, float deltaTime);
        
        protected void InvokeOnAttack()
        {
            OnAttack?.Invoke();
        }
        
        private void CalculateCooldown(float deltaTime)
        {
            if (_onCooldown)
            {
                _timePassed += deltaTime;
                if (_timePassed >= TowerAttackDTO.Cooldown)
                {
                    _onCooldown = false;
                    _timePassed = 0.0f;
                }
            }
        }
    }
}