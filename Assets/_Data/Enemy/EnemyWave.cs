using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MMonoBehaviour
{
    [SerializeField] protected float spawnSpeed = 5f;
    [SerializeField] protected int maxSpawn = 10;
    [SerializeField] protected List<Enemy> spawnedEnemies = new();
    [SerializeField] protected List<Enemy> enemiDead = new();

    protected override void Start()
    {
        base.Start();
        this.Spawning();
    }

    protected virtual void FixedUpdate()
    {
        this.CheckDead();
    }
    protected virtual void Spawning()
    {
        Invoke(nameof(this.Spawning), this.spawnSpeed);
        if (this.spawnedEnemies.Count >= this.maxSpawn) return;

        Enemy prefab = GameCtrlS.Instance.EParentCtrl.EPrefab.GetRandom();
        Enemy newEnemy = GameCtrlS.Instance.EParentCtrl.EnemySpawner.Spawn(prefab, GetPos().transform.position);
        newEnemy.gameObject.SetActive(true);
        this.spawnedEnemies.Add(newEnemy);
    }
    protected virtual SpawnPoint1 GetPos()
    {
        SpawnPoint1 newPoint = GameCtrlS.Instance.OPerentCtrl.SpawnPoint.GetRandomPoint();
        return newPoint;
    }
    public virtual void CheckDead()
    {
        if (this.spawnedEnemies == null) return;
        foreach (Enemy enemyCtrl in this.spawnedEnemies)
        {
            if (enemyCtrl.EnemyCtrl.EnemyDameReceive.SetIsDead())
            {
                this.enemiDead.Add(enemyCtrl);
            }
        }
        this.RemoveDead();
    }
    protected virtual void RemoveDead()
    {
        if (this.enemiDead == null) return;
        foreach (Enemy enemyCtrl in this.enemiDead)
        {
            this.spawnedEnemies.Remove(enemyCtrl);
        }
        this.enemiDead.Clear();
    }
}
