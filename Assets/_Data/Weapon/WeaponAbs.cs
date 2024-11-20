using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAbs : MMonoBehaviour
{
    [SerializeField] protected Weapon weapon;
    public Weapon Weapon => this.weapon;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWeapon();
    }
    protected virtual void LoadWeapon()
    {
        if (this.weapon != null) return;
        this.weapon = GetComponentInParent<Weapon>();
        Debug.Log(transform.name + ": LoadWeapon", gameObject);
    }
}
