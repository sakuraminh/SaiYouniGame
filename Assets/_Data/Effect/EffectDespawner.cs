using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDespawner : Despawner<Effect>
{
    public EnvCtrl groudshow;
    protected override void Update()
    {
        base.Update();
        this.DespawnByTime();
    }
    protected virtual void OnTriggerEnter(Collider collider)
    {
        Debug.Log("vc");
        EnvCtrl groud = collider.GetComponent<EnvCtrl>();
        this.groudshow = groud;

        if (groud == null) return;
        DoDespawn();
    }
}
