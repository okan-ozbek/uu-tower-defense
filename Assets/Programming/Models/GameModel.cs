using Programming.Configs;
using Programming.Stats;
using UnityEngine;

namespace Programming.Models
{
    public class GameModel : Model
    {
        [SerializeField] private PlayerStatConfig statConfig;
        
        public GenericStat<float> Health;
        public GenericStat<float> Money;
        
        public override void Initialize()
        {
            Health = new GenericStat<float>(statConfig.health);
            Money = new GenericStat<float>(statConfig.money);
        }
    }
}