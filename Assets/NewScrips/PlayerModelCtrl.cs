using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelCtrl : MMonoBehaviour
{

    [SerializeField] protected int indexArr = 0;

    [SerializeField] protected Weapons weaponS;

    [SerializeField] protected Weapon newWeapon;
    public Weapon NewWeapon => this.newWeapon;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWeapons();
    }

    private void LoadWeapons()
    {
        this.weaponS = GetComponentInChildren<Weapons>();
    }

    public virtual void OnButton()
    {
        this.ChangeWeapon();
    }

    public virtual Weapon ChangeWeapon()
    {
        //WeaponCtrl newWeapon;
        this.newWeapon = this.weaponS.weaponCtrlList[this.indexArr];
        this.newWeapon.gameObject.SetActive(true);
        this.indexArr++;
        if (this.indexArr > this.weaponS.weaponCtrlList.Length - 1) this.indexArr = 0;
        return this.newWeapon;
    }
}
