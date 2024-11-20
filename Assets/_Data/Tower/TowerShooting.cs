using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : TowerAbstract
{
    [SerializeField] protected Enemy target;
    [SerializeField] protected float timer = 0;
    [SerializeField] protected float delay = 1f;
    [SerializeField] protected int firePointIndex = 0;
    [SerializeField] protected List<FirePoint> firePoints = new();
    [SerializeField] protected string prefabName = "Bullet";

    protected virtual void FixedUpdate()
    {
        this.GetTarget();
        this.LookAtTarget();
        this.Shooting();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFirePoints();
    }

    protected virtual void GetTarget()
    {
        this.target = this.towerCtrl.TowerRadar.GetTarget();
    }

    protected virtual void LookAtTarget()
    {
        if (this.target == null) return;
        this.towerCtrl.Rotator.LookAt(this.target.EnemyCtrl.Targetable.transform.position);
    }

    protected virtual void Shooting()
    {
        this.timer += Time.deltaTime;
        if (this.target == null) return;
        if (this.timer < this.delay) return;
        this.timer = 0;

        FirePoint firePoint = this.GetFirePoint();

        Effect newBullet = GameCtrlS.Instance.OPerentCtrl.EffectSpawner.Spawn(GameCtrlS.Instance.OPerentCtrl.EffectPrefab.GetPrefabByName(this.prefabName), firePoint.transform.position, firePoint.transform.rotation);
        newBullet.gameObject.SetActive(true);
    }



    protected virtual FirePoint GetFirePoint()
    {
        //int pointIndex = Random.Range(0, this.firePoints.Count);
        this.firePointIndex++;
        if (this.firePointIndex >= this.firePoints.Count) this.firePointIndex = 0;
        return this.firePoints[this.firePointIndex];
    }

    protected virtual void LoadFirePoints()
    {
        if (this.firePoints.Count != 0) return;
        FirePoint[] points = this.towerCtrl.GetComponentsInChildren<FirePoint>();
        this.firePoints = new List<FirePoint>(points);
        Debug.Log(transform.name + ": LoadFirePoints", gameObject);
    }
}
