using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : SpawnPointCtrl
{
    public virtual SpawnPoint GetRandomPoint(int count, List<SpawnPoint> spawnPoints)
    {
        int ran = Random.Range(0, spawnPoints.Count);
        return spawnPoints[ran];
    }

}
