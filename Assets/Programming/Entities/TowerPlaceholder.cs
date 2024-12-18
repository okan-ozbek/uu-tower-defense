using Programming.Models;
using UnityEngine;

namespace Programming.Entities
{
    public class TowerPlaceholder
    {
		private readonly GameObject _placeholder;
		private readonly GameObject _radius;

        public TowerPlaceholder(GameObject placeholder)
        {
            _placeholder = placeholder;
			_radius = placeholder.transform.GetChild(0).gameObject;
        }

        public void Move(Vector2 position)
        {
            _placeholder.transform.position = position;    
        }
        
        public void Hover(bool canPlace)
        {
            Color color = (canPlace)
                ? Color.green
                : Color.red;
            
            SetColor(color);
        }

        public void Set(GameObject tower)
        {
            _placeholder.SetActive(tower);
            
            if (tower)
            {
                _radius.transform.localScale = new Vector2(
                    tower.GetComponent<TowerModel>().Range * 2.0f,
                    tower.GetComponent<TowerModel>().Range * 2.0f
                );
            }
            else
            {
                _radius.transform.localScale = Vector2.one;
            }
        }

        private void SetColor(Color color)
        {
            _placeholder.GetComponent<SpriteRenderer>().color = color;

            var radiusColor = new Color(color.r, color.g, color.b, 0.2f);
            _radius.GetComponent<SpriteRenderer>().color = radiusColor;
        }
    }
}