using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPerentCtrl : MMonoBehaviour
{
    [SerializeField] protected CharacterAiming characterAiming;
    public CharacterAiming CharacterAiming => this.characterAiming;

    [SerializeField] protected PMoving pMoving;
    public PMoving PMoving => this.pMoving;

    [SerializeField] protected PDameReceive pDameReceive;
    public PDameReceive PDameReceive => this.pDameReceive;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCharacterAiming();
        this.LoadPMoving();
        this.LoadPDameReceive();
    }

    protected void LoadCharacterAiming()
    {
        if (this.characterAiming != null) return;
        this.characterAiming = GetComponent<CharacterAiming>();
        Debug.Log(transform.name + ": LoadCharacterAiming", gameObject);
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
