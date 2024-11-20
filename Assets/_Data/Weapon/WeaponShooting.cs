using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class WeaponShooting : WeaponAbs
{
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float delay = 0.5f;
    [SerializeField] protected float delayHeavy = 5f;

    public string bulletName = "Bullet";
    public string bulletHeavyName = "MagicBullet";

    public WFirePoint wFirePoint;

    private void LateUpdate()
    {
        this.OnFiring();
    }
    public virtual void PWeaponShooting(float delay, string PrefabName, quaternion rot)
    {
        if (this.timer < delay) this.timer += Time.deltaTime;
        if (this.timer < delay) return;
        this.timer = delay;
        {
            Effect newBullet = GameCtrlS.Instance.OPerentCtrl.EffectSpawner.Spawn(this.GetBullet(PrefabName), this.wFirePoint.transform.position, rot);
            newBullet.gameObject.SetActive(true);
        }
        this.timer = 0;
    }
    protected virtual Effect GetBullet(string prefabName)
    {
        return GameCtrlS.Instance.OPerentCtrl.EffectPrefab.GetPrefabByName(prefabName);
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
        if (InputManageS.Instance.MouseButton1 || InputManageS.Instance.MouseButtonDown1)
        {
            this.weapon.WeaponCtrl.RayCastWeapon.StartFiring(this.delayHeavy, this.bulletHeavyName);
            return;
        }
        if (InputManageS.Instance.FireDown1 || InputManageS.Instance.MouseButton0)
        {
            this.weapon.WeaponCtrl.RayCastWeapon.StartFiring(this.delay, this.bulletName);
        }

        if (InputManageS.Instance.FireUp1)
        {
            this.weapon.WeaponCtrl.RayCastWeapon.StopFiring();
        }
    }
}
