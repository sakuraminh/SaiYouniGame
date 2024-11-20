using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public abstract class Weapon : MMonoBehaviour
{
    [SerializeField] protected WeaponCtrl weaponCtrl;
    public WeaponCtrl WeaponCtrl => this.weaponCtrl;

    protected override void OnEnable()
    {
        this.CheckActiveSelf();
    }

    protected virtual void Update()
    {
        this.LookAtTarrget();
    }

    public abstract string GetName();

    protected virtual void CheckActiveSelf()
    {
        foreach (Transform sibling in transform.parent)
        {
            if (sibling.gameObject.name == gameObject.name) continue;
            if (!sibling.gameObject.activeSelf) continue;
            sibling.gameObject.SetActive(false);
        }
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWeaponCtrl();
    }

    private void LoadWeaponCtrl()
    {
        if (this.weaponCtrl != null) return;
        this.weaponCtrl = GetComponent<WeaponCtrl>();
        Debug.Log(transform.name + ": LoadWeapon", gameObject);
    }



    protected virtual void LookAtTarrget()
    {
        transform.LookAt(this.weaponCtrl.TransformTarrget);
    }
}
