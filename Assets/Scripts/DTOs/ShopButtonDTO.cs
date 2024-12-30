using UnityEngine;
using UnityEngine.UI;

namespace DTOs
{
    public class ShopButtonDTO
    {
        public readonly float Cost;
        public readonly Button Button;
        
        public ShopButtonDTO(float cost, Button button)
        {
            Cost = cost;
            Button = button;
        }
        
        public ShopButtonDTO(float cost, GameObject button)
        {
            Cost = cost;
            Button = button.GetComponent<Button>();
        }
    }
}