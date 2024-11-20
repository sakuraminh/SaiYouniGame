using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OPerentCtrl : MMonoBehaviour
{
    [SerializeField] protected SpawnPoint spawnPoint;
    public SpawnPoint SpawnPoint => this.spawnPoint;

    [SerializeField] protected TargetPoint targetPoint;
    public TargetPoint TargetPoint => this.targetPoint;

    [SerializeField] protected EffectSpawner effectSpawner;
    public EffectSpawner EffectSpawner => this.effectSpawner;

    [SerializeField] protected EffectPrefab effectPrefab;
    public EffectPrefab EffectPrefab => this.effectPrefab;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPoint();
        this.LoadTargetPoint();
        this.LoadEffectSpawner();
        this.LoadEffectPrefab();
    }
    protected virtual void LoadSpawnPoint()
    {
        if (this.spawnPoint != null) return;
        this.spawnPoint = GetComponentInChildren<SpawnPoint>();
        Debug.Log(transform.name + ": LoadSpawnPoint", gameObject);
    }

    protected virtual void LoadTargetPoint()
    {
        if (this.targetPoint != null) return;
        this.targetPoint = GetComponentInChildren<TargetPoint>();
        Debug.Log(transform.name + ": LoadTargetPoint", gameObject);
    }
    protected virtual void LoadEffectSpawner()
    {
        if (effectSpawner != null) return;
        this.effectSpawner = GetComponentInChildren<EffectSpawner>();
        Debug.Log(transform.name + " LoadEffectSpawner", gameObject);
    }

    protected virtual void LoadEffectPrefab()
    {
        if (this.effectPrefab != null) return;
        this.effectPrefab = GetComponentInChildren<EffectPrefab>();
        Debug.Log(transform.name + " LoadModelCtrl", gameObject);
    }
}
