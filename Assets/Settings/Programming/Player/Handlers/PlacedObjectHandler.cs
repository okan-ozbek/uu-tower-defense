using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Settings.Programming.Player
{
    public class PlacedObjectHandler
    {
        public int PlacedObjects => _placedObjects.Count;
        
        private readonly List<Transform> _placedObjects = new();
        
        public void Add(Transform placedObject)
        {
            _placedObjects.Add(placedObject);
        }
        
        public Transform GetClosestPlacedObject(Vector2 mousePosition)
        {
            return _placedObjects.OrderBy(placedObject => Vector2.Distance(placedObject.position, mousePosition)).First();
        }
    }
}