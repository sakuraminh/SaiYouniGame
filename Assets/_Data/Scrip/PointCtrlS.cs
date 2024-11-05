using UnityEngine;

public class PointCtrlS : MSingleton<PointCtrlS>
{
    [SerializeField] protected SpawnPoint spawnPoint;
    public SpawnPoint SpawnPoint => this.spawnPoint;

    [SerializeField] protected TargetPoint targetPoint;
    public TargetPoint TargetPoint => this.targetPoint;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPoint();
        this.LoadTargetPoint();
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
}
