using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MMonoBehaviour
{
    [SerializeField] protected float spawnSpeed = 5f;
    [SerializeField] protected int maxSpawn = 10;
    [SerializeField] protected List<EnemyCtrl> spawnedEnemies = new();

    protected override void Start()
    {
        base.Start();
        this.Spawning();
    }

    protected virtual void FixedUpdate()
    {
        this.RemoveDeadOne();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
    }

    protected virtual void Spawning()
    {
        Invoke(nameof(this.Spawning), this.spawnSpeed);
        if (this.spawnedEnemies.Count >= this.maxSpawn - 1) return;

        EnemyCtrl prefab = EnemyCtrlSingleton.Instance.EnemyPrefab.GetRandom();
        EnemyCtrl newEnemy = EnemyCtrlSingleton.Instance.EnemySpawner.Spawn(prefab, GetPos().transform.position);
        newEnemy.gameObject.SetActive(true);
        this.spawnedEnemies.Add(newEnemy);


    }

    protected virtual SpawnPointCtrl GetPos()
    {
        SpawnPointCtrl newPoint = SpawnPointCtrlSingleton.Instance.GetRandomPoint(SpawnPointCtrlSingleton.Instance.ListSpawnPoint.Count, SpawnPointCtrlSingleton.Instance.ListSpawnPoint);
        return newPoint;
    }

    protected virtual void RemoveDeadOne()
    {
        foreach (EnemyCtrl enemyCtrl in this.spawnedEnemies)
        {
            if (enemyCtrl.EnemyDameReceive.IsDead())
            {
                this.spawnedEnemies.Remove(enemyCtrl);
                return;
            }
        }
    }
}
