using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerAbstract : MMonoBehaviour
{

    [SerializeField] protected TowerCtrl towerCtrl;

    [SerializeField] protected BulletCtrl bulletCtrl;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTowerCtrl();
    }

    protected virtual void LoadTowerCtrl()
    {
        if (this.towerCtrl != null) return;
        this.towerCtrl = transform.parent.GetComponent<TowerCtrl>();
        Debug.Log(transform.name + ": LoadTowerCtrl", gameObject);
    }
}
