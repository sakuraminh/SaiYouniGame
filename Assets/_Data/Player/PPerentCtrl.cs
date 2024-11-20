using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPerentCtrl : MMonoBehaviour
{
    [SerializeField] protected PMoving pMoving;
    public PMoving PMoving => this.pMoving;

    [SerializeField] protected PDameReceive pDameReceive;
    public PDameReceive PDameReceive => this.pDameReceive;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPMoving();
        this.LoadPDameReceive();
    }
    protected void LoadPMoving()
    {
        if (this.pMoving != null) return;
        this.pMoving = GetComponentInChildren<PMoving>();
        Debug.Log(transform.name + ": LoadPMoving", gameObject);
    }
    protected void LoadPDameReceive()
    {
        if (this.pDameReceive != null) return;
        this.pDameReceive = GetComponentInChildren<PDameReceive>();
        Debug.Log(transform.name + ": LoadPDameReceive", gameObject);
    }
}
