using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PFirePoint : MMonoBehaviour
{
    [SerializeField] protected PFirePointGun pFirePointGun;
    public PFirePointGun PFirePointGun => this.pFirePointGun;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPFirePointGun();
    }
    protected virtual void LoadPFirePointGun()
    {
        if (this.pFirePointGun != null) return;
        this.pFirePointGun = GetComponentInChildren<PFirePointGun>();
        Debug.Log(transform.name + ": LoadPFirePointGun", gameObject);
    }
}
