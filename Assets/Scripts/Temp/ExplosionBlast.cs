using UnityEngine;

namespace Temp
{
    public class ExplosionBlast : MonoBehaviour
    {
        private void Start()
        {
            Destroy(gameObject, 0.5f);
        }
    }
}