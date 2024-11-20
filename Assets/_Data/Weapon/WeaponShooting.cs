using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class WeaponShooting : WeaponAbs
{

    public string bulletName = "Bullet";

    public WFirePoint wFirePoint;

    private void LateUpdate()
    {
        this.OnFiring();
    }
    public virtual void PWeaponShooting(quaternion rot)
    {
        //if (this.timer < delay) this.timer += Time.deltaTime;
        //if (this.timer < this.delay) return;
        //this.timer = 0;
        {
            Effect newBullet = GameCtrlS.Instance.OPerentCtrl.EffectSpawner.Spawn(this.GetBullet(), this.wFirePoint.transform.position, rot);
            newBullet.gameObject.SetActive(true);
        }
    }
    protected virtual Effect GetBullet()
    {
        return GameCtrlS.Instance.OPerentCtrl.EffectPrefab.GetPrefabByName(this.bulletName);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWFirePoint();
    }

    private void LoadWFirePoint()
    {
        if (this.wFirePoint != null) return;
        this.wFirePoint = transform.parent.Find("Model").GetComponentInChildren<WFirePoint>();
        Debug.Log(transform.name + ": LoadWFirePoint", gameObject);
    }

    protected virtual void OnFiring()
    {

        if (InputManageS.Instance.FireDown1 || InputManageS.Instance.MouseButton0)
        {
            this.weapon.WeaponCtrl.RayCastWeapon.StartFiring();
        }

        if (InputManageS.Instance.FireUp1)
        {
            this.weapon.WeaponCtrl.RayCastWeapon.StopFiring();
        }
    }
}
