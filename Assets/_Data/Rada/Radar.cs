using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Radar : MMonoBehaviour
{
    [SerializeField] protected Enemy nearest;
    [SerializeField] protected SphereCollider _collider;
    [SerializeField] protected Rigidbody _rigibody;
    [SerializeField] protected List<Enemy> enemies;
    [SerializeField] protected List<Enemy> enemiesDelete;


    protected virtual void FixedUpdate()
    {
        this.FindDead();
    }
    protected virtual void OnTriggerEnter(Collider collider)
    {
        Targetable targetable = collider.GetComponent<Targetable>();
        if (targetable == null) return;

        Enemy enemyCtrl = targetable.GetComponentInParent<Enemy>();
        if (enemyCtrl == null) return;

        this.AddEnemy(enemyCtrl);
    }
    protected virtual void OnTriggerExit(Collider collider)
    {
        Enemy enemyCtrl = collider.GetComponentInParent<Enemy>();
        if (enemyCtrl == null) return;

        this.RemoveEnemy(enemyCtrl);
    }
    protected virtual void AddEnemy(Enemy enemyCtrl)
    {
        this.enemies.Add(enemyCtrl);
    }

    protected virtual void RemoveEnemy(Enemy enemyCtrl)
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

        foreach (Enemy enemyCtrl in this.enemies)
        {
            if (enemyCtrl.EnemyCtrl.EnemyDameReceive.SetIsDead())
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
        foreach (Enemy enemyCtrl in this.enemies)
        {
            enemyDistance = Vector3.Distance(transform.position, enemyCtrl.transform.position);
            if (enemyDistance < nearestDistance)
            {
                nearestDistance = enemyDistance;
                this.nearest = enemyCtrl;
            }
        }
    }

    public virtual Enemy GetTarget()
    {
        return this.nearest;
    }

    protected virtual void DeleteEnemyDie()
    {
        foreach (Enemy enemy in this.enemiesDelete)
        {
            this.enemies.Remove(enemy);
        }
        this.enemiesDelete.Clear();
        this.FindNearest();
    }

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
        this._rigibody = GetComponentInParent<Rigidbody>();
        this._rigibody.useGravity = false;
        Debug.Log(transform.name + ": LoadRigidbody", gameObject);
    }
}
