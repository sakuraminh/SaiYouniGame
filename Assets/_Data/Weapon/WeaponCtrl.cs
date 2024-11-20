using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCtrl : MMonoBehaviour
{
    [SerializeField] protected WeaponShooting weaponShooting;
    public WeaponShooting WeaponShooting => this.weaponShooting;

    [SerializeField] protected RayCastWeapon rayCastWeapon;
    public RayCastWeapon RayCastWeapon => this.rayCastWeapon;

    [SerializeField] protected Transform transformTarrget;
    public Transform TransformTarrget => this.transformTarrget;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWeaponShooting();
        this.LoadRayCastWeapon();
        this.LoadTarget();
    }

    private void LoadWeaponShooting()
    {
        if (this.weaponShooting != null) return;
        this.weaponShooting = GetComponentInChildren<WeaponShooting>();
        Debug.Log(transform.name + ": LoadWeaponShooting", gameObject);
    }

    private void LoadRayCastWeapon()
    {
        if (this.rayCastWeapon != null) return;
        this.rayCastWeapon = GetComponentInChildren<RayCastWeapon>();
        Debug.Log(transform.name + ": LoadRayCastWeapon", gameObject);
    }
    private void LoadTarget()
    {
        if (this.transformTarrget != null) return;
        this.transformTarrget = GameObject.FindAnyObjectByType<Camera>().transform.Find("CrosshairTarget");
        Debug.Log(transform.name + ": LoadRayCastWeapon", gameObject);
    }
}
