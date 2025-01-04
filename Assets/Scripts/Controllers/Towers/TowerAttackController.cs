using System.Collections.Generic;
using Configs;
using Controllers.Towers.Attacks;
using Controllers.UI;
using DTOs;
using Models;
using Unity.VisualScripting;
using UnityEngine;

namespace Controllers.Towers
{
    public class TowerAttackController : Controller<Tower>
    {
        [SerializeField] private List<AttackConfig> attacks;

        private AttackStrategy _attackStrategy;
        
        private GameObject _currentTarget;
        private bool _onCooldown;
        private int _attackIndex;

        protected override void Subscribe()
        {
            GameButtonController.OnTowerIncreaseRangeClicked += HandleUpgrade;
            GameButtonController.OnTowerIncreaseSpeedClicked += HandleUpgrade;
            GameButtonController.OnTowerUpgradeClicked += HandleTowerUpgrade;
            TowerDetectionController.OnTargetChanged += HandleTargetChanged;
        }
        
        protected override void Unsubscribe()
        {
            GameButtonController.OnTowerIncreaseRangeClicked -= HandleUpgrade;
            GameButtonController.OnTowerIncreaseSpeedClicked -= HandleUpgrade;
            GameButtonController.OnTowerUpgradeClicked += HandleTowerUpgrade;
            TowerDetectionController.OnTargetChanged -= HandleTargetChanged;
        }

        private void Start()
        {
            _attackStrategy = AttackFactory.Create(new TowerAttackDTO(Model, attacks[_attackIndex], gameObject));
        }

        private void Update()
        {
            _attackStrategy.Attack(_currentTarget, Time.deltaTime);
        }
        
        
        private void HandleUpgrade(TowerController controller)
        {
            if (Model == false || Model.Guid != controller.Model.Guid)
            {
                return;
            }
            
            _attackStrategy = AttackFactory.Create(new TowerAttackDTO(Model, attacks[_attackIndex], gameObject));
        }
        
        private void HandleTargetChanged(GameObject target)
        {
            _currentTarget = target;
        }
        
        private void HandleTowerUpgrade(TowerController controller)
        {
            if (Model == false || Model.Guid != controller.Model.Guid)
            {
                return;
            }
            
            if (_attackIndex + 1 >= attacks.Count)
            {
                return;
            }
            
            _attackIndex++;
            
            HandleUpgrade(controller);
        }
    }
}