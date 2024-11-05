using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCtrlSingleton : MSingleton<TowerCtrlSingleton>
{
    [SerializeField] protected TowerPrefab towerPrefab;
    public TowerPrefab TowerPrefab => this.towerPrefab;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTowerPrefab();
    }

    protected virtual void LoadTowerPrefab()
    {
        if (this.towerPrefab != null) return;
        this.towerPrefab = GetComponentInChildren<TowerPrefab>();
        Debug.Log(transform.name + ": LoadTowerPrefab", gameObject);

    }
}
