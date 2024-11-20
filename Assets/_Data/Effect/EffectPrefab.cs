using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPrefab : PoolPrefabs<Effect>
{
    public virtual Effect GetPrefabByName(string name)
    {
        Effect effectPrefab = null;
        foreach (Effect prefab in this.Prefabs)
        {
            if (prefab.GetName() == name)
            {
                effectPrefab = prefab;
            }
        }
        return effectPrefab;
    }
}
