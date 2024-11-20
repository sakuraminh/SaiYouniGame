using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WPrefab : MMonoBehaviour
{
    [SerializeField] protected List<Weapon> weapons;
    public List<Weapon> Weapons => this.weapons;

    [SerializeField] protected int weaponIndex = 0;

    protected virtual void Update()
    {
        this.OnChange();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWPrefab();
    }

    protected virtual void LoadWPrefab()
    {
        if (this.weapons.Count > 0) return;
        Weapon[] weaponss = GetComponentsInChildren<Weapon>();
        this.weapons = weaponss.ToList();
    }

    protected virtual void OnChange()
    {
        if (InputManageS.Instance.Tab)
        {
            this.ChangeWeapon();
        }
    }

    protected virtual void ChangeWeapon()
    {
        this.weapons[this.weaponIndex].gameObject.SetActive(true);
        this.weaponIndex++;
        if (this.weaponIndex >= this.weapons.Count)
        {
            this.weaponIndex = 0;
        }
    }
}
