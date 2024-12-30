using UnityEngine;
using UnityEngine.UI;

namespace DTOs
{
    public class ShopButtonDTO
    {
        public readonly float Cost;
        public readonly Button Button;
        public bool WasInteractable;
        
        public ShopButtonDTO(float cost, Button button)
        {
            Cost = cost;
            Button = button;
            WasInteractable = Button.interactable;
        }
        
        public ShopButtonDTO(float cost, GameObject button)
        {
            Cost = cost;
            Button = button.GetComponent<Button>();
            WasInteractable = Button.interactable;
        }
    }
}