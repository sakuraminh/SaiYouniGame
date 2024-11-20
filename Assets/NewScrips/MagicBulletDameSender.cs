using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
public class MagicBulletDameSender : DameSender
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected EffectDespawner effectDespawner;

    //============================================================================================================================================
    protected override void OnTriggerEnter(Collider collider)
    {
        base.OnTriggerEnter(collider);
        this.CollisionWithEnv(collider);
    }

    protected override DameReceive SendDamage(Collider collider)
    {
        DameReceive damageReceiver = base.SendDamage(collider);
        if (damageReceiver == null) return null;
        this.effectDespawner.DoDespawn();
        return damageReceiver;
    }

    protected virtual void CollisionWithEnv(Collider collider)
    {

        EnvCtrl groud = collider.GetComponent<EnvCtrl>();

        if (groud == null) return;
        this.effectDespawner.DoDespawn();
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
        sphereCollider.radius = 2.5f;
        Debug.Log(transform.name + ": LoadTriggerCollider", gameObject);
    }

}
