using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MMonoBehaviour
{
    [SerializeField] protected Animator animator;
    public Animator Animator => this.animator;

    [SerializeField] protected PFirePoint pFirePoint;
    public PFirePoint PFirePoint => this.pFirePoint;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
        this.LoadPFirePoint();
    }
    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = GetComponentInChildren<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }

    protected virtual void LoadPFirePoint()
    {
        if (this.pFirePoint != null) return;
        this.pFirePoint = GetComponentInChildren<PFirePoint>();
        Debug.Log(transform.name + ": LoadPFirePoint", gameObject);
    }
}
