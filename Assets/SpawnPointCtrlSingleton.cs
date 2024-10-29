using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointCtrlSingleton : MSingleton<SpawnPointCtrlSingleton>
{
    [SerializeField] private SpawnPoint1 spawnPoint1;
    public SpawnPoint1 SpawnPoint1 => this.spawnPoint1;

    [SerializeField] private SpawnPoint2 spawnPoint2;
    public SpawnPoint2 SpawnPoint2 => this.spawnPoint2;

    [SerializeField] private List<SpawnPointCtrl> listSpawnPoint;
    public List<SpawnPointCtrl> ListSpawnPoint => this.listSpawnPoint;

    public virtual SpawnPointCtrl GetRandomPoint(int count, List<SpawnPointCtrl> spawnPoints)
    {
        int ran = Random.Range(0, spawnPoints.Count);
        return spawnPoints[ran];
    }


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPoint1();
        this.LoadSpawnPoint2();
    }

    protected void LoadSpawnPoint1()
    {
        if (this.spawnPoint1 != null) return;
        this.spawnPoint1 = GetComponentInChildren<SpawnPoint1>();
        this.listSpawnPoint.Add(this.spawnPoint1);
        Debug.Log("LoadSpawnPoint1", gameObject);
    }

    protected void LoadSpawnPoint2()
    {
        if (this.spawnPoint2 != null) return;
        this.spawnPoint2 = GetComponentInChildren<SpawnPoint2>();
        this.listSpawnPoint.Add(this.spawnPoint2);
        Debug.Log("LoadSpawnPoint2", gameObject);
    }
}
