using UnityEngine;

namespace Settings.Programming.Gizmos
{
    public class PathManagerGizmos : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            UnityEngine.Gizmos.color = Color.red;
            for (int index = 0; index < transform.childCount; index++)
            {
                UnityEngine.Gizmos.DrawSphere(transform.GetChild(index).position, 0.1f);
                
                if (index != 0)
                {
                    UnityEngine.Gizmos.DrawLine(transform.GetChild(index - 1).position, transform.GetChild(index).position);
                }
            }
        } 
    }
}
