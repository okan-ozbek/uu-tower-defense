using Controllers.Towers.Attacks;
using DTOs;
using Models;
using UnityEngine;

namespace Controllers.Towers
{
    public class TowerAttackController : Controller<Tower>
    {
        [SerializeField] private GameObject projectilePrefab;

        private AttackStrategy _attackStrategy;
        
        private GameObject _currentTarget;
        private bool _onCooldown;

        protected override void Subscribe()
        {
            TowerDetectionController.OnTargetChanged += HandleTargetChanged;
        }
        
        protected override void Unsubscribe()
        {
            TowerDetectionController.OnTargetChanged -= HandleTargetChanged;
        }

        private void Start()
        {
            _attackStrategy = AttackFactory.Create(new TowerAttackDTO(Model, projectilePrefab, gameObject));
        }

        private void Update()
        {
            _attackStrategy.Attack(_currentTarget, Time.deltaTime);
        }
        
        private void HandleTargetChanged(GameObject target)
        {
            _currentTarget = target;
        }
    }
}