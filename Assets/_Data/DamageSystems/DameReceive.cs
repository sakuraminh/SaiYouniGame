using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class DameReceive : MMonoBehaviour
{
    [SerializeField] int currenHp = 10;
    [SerializeField] int maxHp = 10;
    [SerializeField] bool isImmortal = false;

    [SerializeField] protected Collider _collider;

    [SerializeField] protected Animator animator;

    [SerializeField] bool isDead = false;
    public bool IsDead => this.isDead;
    [SerializeField] protected bool isHit = false;
    [SerializeField] protected Moving moving;


    private void OnTriggerEnter(Collider collider)
    {
        this.OnAnimation(collider);
    }

    private void OnAnimation(Collider collider)
    {
        this.SetHit(collider);
        this.animator.SetBool("isHit", this.isHit);
        this.moving.EnemyCtrl.Agent.speed /= 4;
        Invoke(nameof(SetHitFalse), 0.3f);
    }

    private void SetHitFalse()
    {
        this.isHit = false;
        animator.SetBool("isHit", this.isHit);
        this.moving.EnemyCtrl.Agent.speed = 2;
    }

    protected virtual void SetHit(Collider collider)
    {
        DameSender sender = collider.GetComponent<DameSender>();
        this.isHit = sender != null;
    }
    public virtual void Receive(int dame, DameSender dameSender)
    {
        if (!isImmortal) this.currenHp -= dame;
        if (currenHp < 0) currenHp = 0;

        if (this.SetIsDead()) this.OnDead();
        else this.OnHurt();
    }

    protected abstract void OnHurt();

    protected abstract void OnDead();

    public virtual bool SetIsDead()
    {
        return this.isDead = this.currenHp <= 0;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
        this.LoadMoving();
    }

    private void LoadAnimator()
    {
        this.animator = transform.parent.GetComponentInChildren<Animator>();
    }
    private void LoadMoving()
    {
        this.moving = transform.parent.GetComponentInChildren<Moving>();
    }

    public virtual void ResetCurrenHp()
    {
        this.currenHp = this.maxHp;
    }
}
