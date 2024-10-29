using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAbs : MMonoBehaviour
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    public EnemyCtrl EnemyCtrl => this.enemyCtrl;

    protected override void LoadComponents()
    {
        this.GetEnemyCtrl();
    }

    protected void GetEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        Debug.Log("LoadComponent", gameObject);
        this.enemyCtrl = transform.parent.GetComponentInParent<EnemyCtrl>();
    }
}
