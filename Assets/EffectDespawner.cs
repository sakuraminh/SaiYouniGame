using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDespawner : Despawner<EffectCtrl>
{
    protected override void Update()
    {
        base.Update();
        this.DespawnByTime();
    }
}
