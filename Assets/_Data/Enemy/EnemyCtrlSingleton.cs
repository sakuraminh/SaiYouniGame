using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCtrlSingleton : MSingleton<EnemyCtrlSingleton>
{
    [SerializeField] private EnemyPrefab enemyPrefab;
    public EnemyPrefab EnemyPrefab => this.enemyPrefab;

    [SerializeField] private EnemySpawner enemySpawner;
    public EnemySpawner EnemySpawner => this.enemySpawner;

    [SerializeField] private EnemyWave enemyWave;
    public EnemyWave EnemyWave => this.enemyWave;

    //============================================================================================================================================

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyPrefab();
        this.LoadEnemySpawner();
        this.LoadEnemyWave();
    }
    protected void LoadEnemySpawner()
    {
        if (this.enemySpawner != null) return;
        this.enemySpawner = GetComponent<EnemySpawner>();
        Debug.Log("LoadEnemySpawner", gameObject);
    }
    protected void LoadEnemyPrefab()
    {
        if (this.enemyPrefab != null) return;
        this.enemyPrefab = GetComponentInChildren<EnemyPrefab>();
        Debug.Log("LoadEnemyPrefab", gameObject);
    }
    protected void LoadEnemyWave()
    {
        if (this.enemyWave != null) return;
        this.enemyWave = GetComponent<EnemyWave>();
        Debug.Log("LoadEnemyWave", gameObject);
    }
}
