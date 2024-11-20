using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrlS : MSingleton<GameCtrlS>
{
    [SerializeField] protected EParentCtrl eParentCtrl;
    public EParentCtrl EParentCtrl => this.eParentCtrl;

    [SerializeField] protected TParentCtrl tParentCtrl;
    public TParentCtrl TParentCtrl => this.tParentCtrl;

    [SerializeField] protected OPerentCtrl oPerentCtrl;
    public OPerentCtrl OPerentCtrl => this.oPerentCtrl;

    //============================================================================================================================================

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEParentCtrl();
        this.LoadTParentCtrl();
        this.LoadOPerentCtrl();
    }
    protected void LoadEParentCtrl()
    {
        if (this.eParentCtrl != null) return;
        this.eParentCtrl = GetComponentInChildren<EParentCtrl>();
        Debug.Log("LoadEParentCtrl", gameObject);
    }
    protected void LoadTParentCtrl()
    {
        if (this.tParentCtrl != null) return;
        this.tParentCtrl = GetComponentInChildren<TParentCtrl>();
        Debug.Log("LoadTParentCtrl", gameObject);
    }
    protected void LoadOPerentCtrl()
    {
        if (this.oPerentCtrl != null) return;
        this.oPerentCtrl = GetComponentInChildren<OPerentCtrl>();
        Debug.Log("LoadOPerentCtrl", gameObject);
    }

}
