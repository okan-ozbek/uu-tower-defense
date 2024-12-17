using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Programming.Entities.Handlers
{
    public class TowerLocationHandler
    {
        public int PlacedTowers => _placedTowers.Count;
        
        private readonly List<Transform> _placedTowers = new();
        
        public void Add(Transform placedTower)
        {
            _placedTowers.Add(placedTower);
        }
        
        public Transform GetClosestPlacedTower(Vector2 mousePosition)
        {
            return _placedTowers.OrderBy(placedTower => Vector2.Distance(placedTower.position, mousePosition)).First();
        }
    }
}