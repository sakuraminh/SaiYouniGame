using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectCtrl : PoolObj
{
    [SerializeField] protected BulletMoving bulletMoving;
    public BulletMoving BulletMoving => this.bulletMoving;

    [SerializeField] protected BulletDameSender bulletDameSender;
    public BulletDameSender BulletDameSender => this.bulletDameSender;

    [SerializeField] protected EffectDespawner effectDespawner;
    public EffectDespawner EffectDespawner => this.effectDespawner;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletMoving();
        this.LoadBulletDameSender();
        this.LoadEffectDespawner();
    }

    protected virtual void LoadEffectDespawner()
    {
        if (effectDespawner != null) return;
        this.effectDespawner = GetComponentInChildren<EffectDespawner>();
        Debug.Log(transform.name + " LoadEffectDespawner", gameObject);
    }

    protected virtual void LoadBulletDameSender()
    {
        if (bulletDameSender != null) return;
        this.bulletDameSender = GetComponentInChildren<BulletDameSender>();
        Debug.Log(transform.name + " LoadBulletDameSender", gameObject);
    }

    protected virtual void LoadBulletMoving()
    {
        if (bulletMoving != null) return;
        this.bulletMoving = GetComponentInChildren<BulletMoving>();
        Debug.Log(transform.name + " LoadBulletMoving", gameObject);
    }
}

