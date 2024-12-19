using UnityEngine;
using System.Collections;

public class AbilityStrategyFactory
{
    public static IAbilityStrategy Create(AbstractAbilityData data)
    {
        return data.targetType switch
        {
            TargetType.SingleTarget => new SingleTargetStrategy(data),
            TargetType.MultiTarget => new MultiTargetStrategy(data),
            TargetType.NoTarget => new NoTargetStrategy(data),
            _ => null
        }
    }
}