using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyCtrl : PoolObj
{
    [SerializeField] protected NavMeshAgent agent;
    public NavMeshAgent Agent => this.agent;

    [SerializeField] protected Animator animator;
    public Animator Animator => this.animator;

    [SerializeField] protected Moving moving;
    public Moving Moving => this.moving;

    [SerializeField] protected Targetable targetable;
    public Targetable Targetable => this.targetable;

    [SerializeField] protected EnemyDameReceive enemyDameReceive;
    public EnemyDameReceive EnemyDameReceive => this.enemyDameReceive;


    //============================================================================================================================================

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEgent();
        this.LoadAnimator();
        this.LoadMoving();
        this.LoadTargetable();
        this.LoadEnemyDameReceive();
    }
    protected void LoadEnemyDameReceive()
    {
        if (this.enemyDameReceive != null) return;
        this.enemyDameReceive = GetComponentInChildren<EnemyDameReceive>();
        Debug.Log("LoadEnemyDameReceive", gameObject);
    }
    protected void LoadTargetable()
    {
        if (this.targetable != null) return;
        this.targetable = GetComponentInChildren<Targetable>();
        Debug.Log("LoadTargetable", gameObject);
    }

    protected void LoadMoving()
    {
        if (this.moving != null) return;
        this.moving = GetComponentInChildren<Moving>();
        Debug.Log("LoadMoving", gameObject);
    }

    protected void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = GetComponentInChildren<Animator>();
        Debug.Log("LoadAnimator", gameObject);
    }
    protected void LoadEgent()
    {
        if (this.agent != null) return;
        this.agent = GetComponent<NavMeshAgent>();
        Debug.Log("LoadEgent", gameObject);
    }
}
