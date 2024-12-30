using Controllers.Enemies;
using Enums;
using Models.Projectiles;
using UnityEngine;
using Utility;

namespace Controllers.Projectiles
{
    [RequireComponent(typeof(Projectile))]
    public abstract class ProjectileController<TModel> : Controller<TModel> where TModel : Projectile
    {
        private readonly Vector2 _bounds = new(10.0f, 6.0f);

        protected override void Subscribe()
        {
            WaveSystem.OnWaveFinished += HandleWaveFinished;
        }
        
        protected override void Unsubscribe()
        {
            WaveSystem.OnWaveFinished -= HandleWaveFinished;
        }
        
        private void Update()
        {
            Move();
            OutboundDetection();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Tags.Enemy.ToString()))
            {
                OnImpact(other.gameObject);
            }
        }
        
        private void OutboundDetection()
        {
            Vector2 absolutePosition = new Vector2(Mathf.Abs(transform.position.x), Mathf.Abs(transform.position.y));
            if (absolutePosition.x > _bounds.x || absolutePosition.y > _bounds.y)
            {
                OnOutbound();
            }
        }

        private void HandleWaveFinished()
        {
            Destroy(gameObject);
        }
        
        protected abstract void Move();
        protected abstract void OnImpact(GameObject enemy);
        protected abstract void OnOutbound();        
    }
}