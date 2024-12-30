using Utility;

namespace Models.Projectiles
{
    public abstract class Projectile : Model
    {
        public Stat<float> Speed;
        public Stat<float> Damage;

        protected abstract override void Start();
    }
}