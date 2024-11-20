using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCtrl : MMonoBehaviour
{
    [Header("TowerCtrl Parent Class Variables")]

    [SerializeField] protected TowerRadar towerRadar;
    public TowerRadar TowerRadar => towerRadar;

    [SerializeField] protected Transform rotator;
    public Transform Rotator => rotator;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRadar();
        this.LoadRotator();
    }

    protected virtual void LoadRadar()
    {
        if (this.towerRadar != null) return;
        this.towerRadar = GetComponentInChildren<TowerRadar>();
        Debug.Log(transform.name + ": LoadRadar", gameObject);
    }

    protected virtual void LoadRotator()
    {
        if (this.rotator != null) return;
        this.rotator = transform.Find("Model").Find("TowerRotator");
        Debug.Log(transform.name + ": LoadRotator", gameObject);
    }
}
