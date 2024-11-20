using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Weapons : MMonoBehaviour
{
    [SerializeField] public Weapon[] weaponCtrlList;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWeaponCtrls();
    }

    protected virtual void LoadWeaponCtrls()
    {
        if (weaponCtrlList.Length != 0) return;
        this.weaponCtrlList = GetComponentsInChildren<Weapon>();
        Debug.Log(transform.name + ": LoadWeaponCtrls", gameObject);
    }
}
