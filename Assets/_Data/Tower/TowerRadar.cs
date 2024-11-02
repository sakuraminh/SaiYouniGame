using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class TowerRadar : MMonoBehaviour
{
    [SerializeField] protected EnemyCtrl nearest;
    [SerializeField] protected SphereCollider _collider;
    [SerializeField] protected Rigidbody _rigibody;
    [SerializeField] protected List<EnemyCtrl> enemies;
    [SerializeField] protected List<EnemyCtrl> enemiesDelete;

    //============================================================================================================================================

    protected virtual void FixedUpdate()
    {
        this.FindDead();
    }
    protected virtual void OnTriggerEnter(Collider collider)
    {
        Targetable targetable = collider.GetComponent<Targetable>();
        if (targetable == null) return;

        EnemyCtrl enemyCtrl = targetable.GetComponentInParent<EnemyCtrl>();
        if (enemyCtrl == null) return;

        this.AddEnemy(enemyCtrl);
    }
    protected virtual void OnTriggerExit(Collider collider)
    {
        EnemyCtrl enemyCtrl = collider.GetComponentInParent<EnemyCtrl>();
        if (enemyCtrl == null) return;

        this.RemoveEnemy(enemyCtrl);
    }
    protected virtual void AddEnemy(EnemyCtrl enemyCtrl)
    {
        this.enemies.Add(enemyCtrl);
    }

    protected virtual void RemoveEnemy(EnemyCtrl enemyCtrl)
    {
        if (this.nearest == enemyCtrl) this.nearest = null;
        this.enemies.Remove(enemyCtrl);
    }

    protected virtual void FindDead()
    {
        if (this.enemies.Count == 0)
        {
            this.nearest = null;
            return;
        }

        foreach (EnemyCtrl enemyCtrl in this.enemies)
        {
            if (enemyCtrl.EnemyDameReceive.SetIsDead())
            {
                this.enemiesDelete.Add(enemyCtrl);
                continue;
            }
        }
        this.DeleteEnemyDie();

    }

    public virtual void FindNearest()
    {
        if (this.enemies == null)
        {
            this.nearest = null;
            return;
        }
        float nearestDistance = Mathf.Infinity;
        float enemyDistance;
        foreach (EnemyCtrl enemyCtrl in this.enemies)
        {
            enemyDistance = Vector3.Distance(transform.position, enemyCtrl.transform.position);
            if (enemyDistance < nearestDistance)
            {
                nearestDistance = enemyDistance;
                this.nearest = enemyCtrl;
            }
        }
    }

    public virtual EnemyCtrl GetTarget()
    {
        return this.nearest;
    }

    protected virtual void DeleteEnemyDie()
    {
        foreach (EnemyCtrl enemy in this.enemiesDelete)
        {
            this.enemies.Remove(enemy);
        }
        this.enemiesDelete.Clear();
        this.FindNearest();
    }

    //============================================================================================================================================

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadRigidbody();
    }

    protected virtual void LoadCollider()
    {
        if (this._collider != null) return;
        this._collider = GetComponent<SphereCollider>();
        this._collider.isTrigger = true;
        this._collider.radius = 12;
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }

    protected virtual void LoadRigidbody()
    {
        if (this._rigibody != null) return;
        this._rigibody = GetComponent<Rigidbody>();
        this._rigibody.useGravity = false;
        Debug.Log(transform.name + ": LoadRigidbody", gameObject);
    }
}

