using Programming.Configs;
using Programming.Stats;
using UnityEngine;

namespace Programming.Models
{
    public class GameModel : Model
    {
        [SerializeField] private PlayerStatConfig statConfig;
        
        public Stat<float> Health;
        public Stat<float> Money;
        
        public override void Initialize()
        {
            Health = new Stat<float>(statConfig.health);
            Money = new Stat<float>(statConfig.money);
        }
    }
}