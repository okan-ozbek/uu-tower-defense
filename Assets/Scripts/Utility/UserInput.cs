using UnityEngine;

namespace Utility
{
    public static class UserInput
    {
        public static bool OnLeftMouseClick()
        {
            return Input.GetMouseButtonDown(0);
        }
        
        public static bool OnRightMouseClick()
        {
            return Input.GetMouseButtonDown(1);
        }

        public static Vector3 MousePosition()
        {
            return Camera.main!.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}