using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastWeapon : WeaponAbs
{

    [SerializeField] protected WFirePoint rayCastOrigin;
    public WFirePoint RayCastOrigin => this.rayCastOrigin;

    [SerializeField] protected bool isFiring = false;

    //public TrailRenderer trailRenderer;   

    [SerializeField] protected Ray ray;

    [SerializeField] protected RaycastHit hit;
    public virtual void StartFiring(float delay, string prefabName)
    {
        this.isFiring = true;
        this.ray.origin = rayCastOrigin.transform.position;

        this.ray.direction = this.weapon.WeaponCtrl.TransformTarrget.position - this.rayCastOrigin.transform.position;

        Quaternion rotation = Quaternion.LookRotation(this.ray.direction);

        if (Physics.Raycast(this.ray, out this.hit))
        {
            Debug.DrawLine(this.ray.origin, this.hit.point, Color.red, 1.0f);
        }

        this.weapon.WeaponCtrl.WeaponShooting.PWeaponShooting(delay, prefabName, rotation);
    }

    public virtual void StopFiring()
    {
        this.isFiring = false;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWFirePoint();
    }

    protected virtual void LoadWFirePoint()
    {
        if (this.rayCastOrigin != null) return;
        this.rayCastOrigin = transform.parent.Find("Model").GetComponentInChildren<WFirePoint>();
        Debug.Log(transform.name + ": LoadWFirePoint", gameObject);
    }
}
