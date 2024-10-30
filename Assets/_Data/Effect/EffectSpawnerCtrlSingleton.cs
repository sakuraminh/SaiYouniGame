using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSpawnerCtrlSingleton : MSingleton<EffectSpawnerCtrlSingleton>
{
    [SerializeField] protected EffectSpawner effectSpawner;
    public EffectSpawner EffectSpawner => this.effectSpawner;

    [SerializeField] protected BulletCtrl bulletCtrl;
    public BulletCtrl BulletCtrl => this.bulletCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEffectSpawner();
        this.LoadBulletCtrl();
    }

    protected virtual void LoadEffectSpawner()
    {
        if (effectSpawner != null) return;
        this.effectSpawner = GetComponent<EffectSpawner>();
        Debug.Log(transform.name + " LoadEffectSpawner", gameObject);
    }

    protected virtual void LoadBulletCtrl()
    {
        if (bulletCtrl != null) return;
        this.bulletCtrl = GetComponentInChildren<BulletCtrl>();
        Debug.Log(transform.name + " LoadBulletCtrl", gameObject);
    }


}
