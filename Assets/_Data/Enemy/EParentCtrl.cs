using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EParentCtrl : MMonoBehaviour
{
    [SerializeField] protected EPrefab ePrefab;
    public EPrefab EPrefab => this.ePrefab;

    [SerializeField] private EnemySpawner enemySpawner;
    public EnemySpawner EnemySpawner => this.enemySpawner;

    [SerializeField] private EnemyWave enemyWave;
    public EnemyWave EnemyWave => this.enemyWave;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEPrefab();
        this.LoadEnemySpawner();
        this.LoadEnemyWave();
    }

    protected virtual void LoadEPrefab()
    {
        if (this.ePrefab != null) return;
        this.ePrefab = GetComponentInChildren<EPrefab>();
        Debug.Log(transform.name + ": LoadEPrefab", gameObject);
    }
    protected void LoadEnemySpawner()
    {
        if (this.enemySpawner != null) return;
        this.enemySpawner = GetComponentInChildren<EnemySpawner>();
        Debug.Log("LoadEnemySpawner", gameObject);
    }
    protected void LoadEnemyWave()
    {
        if (this.enemyWave != null) return;
        this.enemyWave = GetComponentInChildren<EnemyWave>();
        Debug.Log("LoadEnemyWave", gameObject);
    }
}
