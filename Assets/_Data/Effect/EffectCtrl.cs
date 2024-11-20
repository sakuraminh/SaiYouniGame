using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCtrl : MMonoBehaviour
{
    [Header("EffectCtrl Parent Class Variables")]
    [SerializeField] protected EffectMoving effectMoving;
    public EffectMoving EffectMoving => this.effectMoving;

    [SerializeField] protected DameSender effectDameSender;
    public DameSender EffectDameSender => this.effectDameSender;

    [SerializeField] protected EffectDespawner effectDespawner;
    public EffectDespawner EffectDespawner => this.effectDespawner;

    [SerializeField] protected ModelCtrl modelCtrl;
    public ModelCtrl ModelCtrl => this.modelCtrl;



    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEffectMoving();
        this.LoadEffectDameSender();
        this.LoadEffectDespawner();
        this.LoadModelCtrl();
    }

    protected virtual void LoadModelCtrl()
    {
        if (this.modelCtrl != null) return;
        this.modelCtrl = GetComponentInChildren<ModelCtrl>();
        //Debug.Log(transform.name + " LoadModelCtrl", gameObject);
    }

    protected virtual void LoadEffectDespawner()
    {
        if (effectDespawner != null) return;
        this.effectDespawner = GetComponentInChildren<EffectDespawner>();
        Debug.Log(transform.name + " LoadEffectDespawner", gameObject);
    }

    protected virtual void LoadEffectDameSender()
    {
        if (effectDameSender != null) return;
        this.effectDameSender = GetComponentInChildren<DameSender>();
        Debug.Log(transform.name + " LoadEffectDameSender", gameObject);
    }

    protected virtual void LoadEffectMoving()
    {
        if (effectMoving != null) return;
        this.effectMoving = GetComponentInChildren<EffectMoving>();
        Debug.Log(transform.name + " LoadEffectMoving", gameObject);
    }
}

