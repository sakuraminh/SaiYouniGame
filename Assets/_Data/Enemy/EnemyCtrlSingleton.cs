using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCtrlSingleton : MSingleton<EnemyCtrlSingleton>
{
    [SerializeField] private EnemyCtrl mutantCtrl;
    public EnemyCtrl MutantCtrl => this.mutantCtrl;

    [SerializeField] private EnemyCtrl mutant1Ctrl;
    public EnemyCtrl Mutant1Ctrl => this.mutant1Ctrl;

    [SerializeField] private EnemyCtrl mutant2Ctrl;
    public EnemyCtrl Mutant2Ctrl => this.mutant2Ctrl;

    [SerializeField] private EnemyCtrl mutant3Ctrl;
    public EnemyCtrl Mutant3Ctrl => this.mutant3Ctrl;

    [SerializeField] private EnemyCtrl mutant4Ctrl;
    public EnemyCtrl Mutant4Ctrl => this.mutant4Ctrl;

    [SerializeField] private EnemyPrefab enemyPrefab;
    public EnemyPrefab EnemyPrefab => this.enemyPrefab;

    [SerializeField] private EnemySpawner enemySpawner;
    public EnemySpawner EnemySpawner => this.enemySpawner;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadmutantCtrl();
        this.Loadmutant1Ctrl();
        this.Loadmutant2Ctrl();
        this.Loadmutant3Ctrl();
        this.Loadmutant4Ctrl();
        this.LoadEnemyPrefab();
        this.LoadEnemySpawner();
    }

    protected void LoadEnemySpawner()
    {
        if (this.enemySpawner != null) return;
        this.enemySpawner = GetComponentInChildren<EnemySpawner>();
        Debug.Log("LoadEnemySpawner", gameObject);
    }

    protected void LoadEnemyPrefab()
    {
        if (this.enemyPrefab != null) return;
        this.enemyPrefab = GetComponentInChildren<EnemyPrefab>();
        Debug.Log("LoadEnemyPrefab", gameObject);
    }

    protected void LoadmutantCtrl()
    {
        if (this.mutantCtrl != null) return;
        this.mutantCtrl = GetComponentInChildren<MutantCtrl>();
        Debug.Log("LoadEnemyDameReceive", gameObject);
    }
    protected void Loadmutant1Ctrl()
    {
        if (this.mutant1Ctrl != null) return;
        this.mutant1Ctrl = GetComponentInChildren<Mutant1Ctrl>();
        Debug.Log("LoadEnemyDameReceive", gameObject);
    }
    protected void Loadmutant2Ctrl()
    {
        if (this.mutant2Ctrl != null) return;
        this.mutant2Ctrl = GetComponentInChildren<Mutant2Ctrl>();
        Debug.Log("LoadEnemyDameReceive", gameObject);
    }
    protected void Loadmutant3Ctrl()
    {
        if (this.mutant3Ctrl != null) return;
        this.mutant3Ctrl = GetComponentInChildren<Mutant3Ctrl>();
        Debug.Log("LoadEnemyDameReceive", gameObject);
    }
    protected void Loadmutant4Ctrl()
    {
        if (this.mutant4Ctrl != null) return;
        this.mutant4Ctrl = GetComponentInChildren<Mutant4Ctrl>();
        Debug.Log("LoadEnemyDameReceive", gameObject);
    }
}
