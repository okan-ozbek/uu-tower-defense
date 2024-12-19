using Programming.Models;
using UnityEngine;

namespace Programming.Controllers
{
    [RequireComponent(
        requiredComponent:  typeof(TowerController),
        requiredComponent2: typeof(AbilityModel)
    )]
    public class AbilityController : Controller<AbilityModel>
    {
        private Entities.Ability _currentAbility;
        private int _currentIndex;
        
        private void Start()
        {
            _currentIndex = 0;
            _currentAbility = new Entities.Ability(model.Abilities[_currentIndex]);
        }

        private void Update()
        {
            model.Abilities[0].Update(Time.deltaTime);
            _currentAbility.Use(gameObject);

            if (Input.GetKeyDown(KeyCode.Tab) && _currentIndex < model.Abilities.Count - 1)
            {
                _currentIndex++;
                _currentAbility.Upgrade(model.Abilities[_currentIndex]);
            }
        }
    }
}