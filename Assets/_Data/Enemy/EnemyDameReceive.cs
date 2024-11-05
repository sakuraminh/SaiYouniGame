using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDameReceive : DameReceive
{
    [SerializeField] protected EnemyCtrl enemyCtrl;

    //============================================================================================================================================

    protected override void OnDead()
    {
        this.capsuleCollider.enabled = false;
        enemyCtrl.Animator.SetBool("isDead", enemyCtrl.EnemyDameReceive.IsDead);
        Invoke(nameof(CallDespawn), 4f);

        InventoriesManager.Instance.AddItem(ItemCode.Gold, 1);
        InventoriesManager.Instance.AddItem(ItemCode.PlayerExp, 1);
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
        //this.SetHit(collider);
        this.enemyCtrl.Animator.SetBool("isHit", this.SetHit(collider));
        this.enemyCtrl.Agent.speed = 0.1f;
        Invoke(nameof(SetHitFalse), 0.2f);
    }

    protected void SetHitFalse()
    {
        this.isHit = false;
        this.enemyCtrl.Animator.SetBool("isHit", this.isHit);
        this.enemyCtrl.Agent.speed = 2;
    }
    protected virtual bool SetHit(Collider collider)
    {
        DameSender sender = collider.GetComponent<DameSender>();
        return this.isHit = sender != null;
    }
    protected virtual void CallDespawn()
    {
        this.enemyCtrl.Despawn.DoDespawn();
    }

    protected override void Reborn()
    {
        base.Reborn();
        this.capsuleCollider.enabled = true;
    }


    //============================================================================================================================================


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
        this.LoadCapsuleCollider();
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }
    protected virtual void LoadCapsuleCollider()
    {
        if (this.capsuleCollider != null) return;
        this.capsuleCollider = GetComponent<CapsuleCollider>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }


}
