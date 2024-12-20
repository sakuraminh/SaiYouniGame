using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public class BulletDameSender : DameSender
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected EffectDespawner effectDespawner;

    //============================================================================================================================================

    protected override DameReceive SendDamage(Collider collider)
    {
        DameReceive damageReceiver = base.SendDamage(collider);
        if (damageReceiver == null) return null;
        this.effectDespawner.DoDespawn();
        return damageReceiver;
    }

    //============================================================================================================================================

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDespawn();
    }

    protected virtual void LoadDespawn()
    {
        if (this.effectDespawner != null) return;
        this.effectDespawner = transform.parent.GetComponentInChildren<EffectDespawner>();
        Debug.Log(transform.name + ": LoadDespawn", gameObject);
    }
    protected override void LoadTriggerCollider()
    {
        if (this._collider != null) return;
        this._collider = GetComponent<Collider>();
        this._collider.isTrigger = true;
        this.sphereCollider = (SphereCollider)this._collider;
        sphereCollider.radius = 0.5f;
        Debug.Log(transform.name + ": LoadTriggerCollider", gameObject);
    }

}
