using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointCtrl : MMonoBehaviour
{
    [Header("SpawnPointCtrl Parent Class Variables")]

    [SerializeField] protected List<SpawnPoint1> listSpawnPoint = new();
    public List<SpawnPoint1> ListSpawnPoint => this.listSpawnPoint;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadListPoint();
    }

    protected virtual void LoadListPoint()
    {
        foreach (Transform point in transform)
        {
            SpawnPoint1 point1 = point.GetComponent<SpawnPoint1>();
            this.listSpawnPoint.Add(point1);
        }
    }
}
