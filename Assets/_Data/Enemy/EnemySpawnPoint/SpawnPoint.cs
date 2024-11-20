using UnityEngine;

public class SpawnPoint : SpawnPointCtrl
{
    public virtual SpawnPoint1 GetRandomPoint()
    {
        int ran = Random.Range(0, this.listSpawnPoint.Count);
        return this.listSpawnPoint[ran];
    }

}
