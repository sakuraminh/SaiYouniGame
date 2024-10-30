using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDameReceive : DameReceive
{

    [SerializeField] protected EnemyCtrl enemyCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.GetComponentInParent<EnemyCtrl>();
        Debug.Log(transform.name + ": LoadDespawn", gameObject);
    }

    protected override void OnDead()
    {
        enemyCtrl.Animator.SetBool("isDead", enemyCtrl.EnemyDameReceive.IsDead);
        Invoke(nameof(GetDespawn), 4f);
    }

    protected virtual void GetDespawn()
    {
        this.enemyCtrl.Despawn.DoDespawn();
    }

    protected override void OnHurt()
    {
        //
    }
}
