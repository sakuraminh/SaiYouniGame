using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDameReceive : DameReceive
{
    [SerializeField] protected EnemyCtrl enemyCtrl;

    //============================================================================================================================================

    protected override void OnDead()
    {
        enemyCtrl.Animator.SetBool("isDead", enemyCtrl.EnemyDameReceive.IsDead);
        this.CallDespawn();
    }
    protected override void OnHurt()
    {
        //
    }
    protected override void OnTriggerEnter(Collider collider)
    {
        this.OnAnimation(collider);
    }
    protected void OnAnimation(Collider collider)
    {
        this.SetHit(collider);
        this.enemyCtrl.Animator.SetBool("isHit", this.isHit);
        this.enemyCtrl.Agent.speed = 0.5f;
        Invoke(nameof(SetHitFalse), 1f);
    }
    protected void SetHitFalse()
    {
        this.isHit = false;
        this.enemyCtrl.Animator.SetBool("isHit", this.isHit);
        this.enemyCtrl.Agent.speed = 2;
    }
    protected virtual void SetHit(Collider collider)
    {
        DameSender sender = collider.GetComponent<DameSender>();
        this.isHit = sender != null;
    }
    protected virtual void CallDespawn()
    {
        this.enemyCtrl.Despawn.DoDespawn();
        //if (enemyCtrl.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && !enemyCtrl.Animator.IsInTransition(0))
        //{
        //    this.enemyCtrl.Despawn.DoDespawn();
        //}
    }


    //============================================================================================================================================


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }
}
