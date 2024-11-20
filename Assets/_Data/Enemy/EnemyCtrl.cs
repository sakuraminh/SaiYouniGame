using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCtrl : MMonoBehaviour
{
    [Header("EnemyCtrl Parent Class Variables")]

    [SerializeField] protected Enemy enemy;
    public Enemy Enemy => this.enemy;

    [SerializeField] protected NavMeshAgent agent;
    public NavMeshAgent Agent => this.agent;

    [SerializeField] protected Animator animator;
    public Animator Animator => this.animator;

    [SerializeField] protected BaseEMoving moving;
    public BaseEMoving Moving => this.moving;

    [SerializeField] protected Targetable targetable;
    public Targetable Targetable => this.targetable;

    [SerializeField] protected EnemyDameReceive enemyDameReceive;
    public EnemyDameReceive EnemyDameReceive => this.enemyDameReceive;

    //[SerializeField] protected EnemyDameReceive enemyDameReceive;
    //public EnemyDameReceive EnemyDameReceive => this.enemyDameReceive;



    //============================================================================================================================================

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEgent();
        this.LoadAnimator();
        this.LoadMoving();
        this.LoadTargetable();
        this.LoadEnemyDameReceive();
        this.LoadEnemy();
    }

    protected void LoadEnemy()
    {
        if (this.enemy != null) return;
        this.enemy = GetComponent<Enemy>();
        Debug.Log("LoadEnemy", gameObject);
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
        this.moving = GetComponentInChildren<BaseEMoving>();
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
