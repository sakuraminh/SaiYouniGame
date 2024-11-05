using System;
using UnityEngine;
using UnityEngine.AI;

public class Moving : EnemyAbs
{
    [SerializeField] protected TargetPoint targetPoint;
    [SerializeField] protected int targetIndex = 0;
    public int TargetIndex => this.targetIndex;
    [SerializeField] protected float distance = Mathf.Infinity;
    [SerializeField] protected float distanceLimit = 2;
    [SerializeField] protected bool isFinish = false;
    [SerializeField] protected bool isMoving = false;


    private void FixedUpdate()
    {
        this.MovingToTarget();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTargetPoint();
    }

    private void LoadTargetPoint()
    {
        if (this.targetPoint != null) return;
        this.targetPoint = PointCtrlS.Instance.TargetPoint;
        Debug.Log(transform.name + ": LoadComponent", gameObject);
    }

    protected virtual void MovingToTarget()
    {
        this.SetMoving();
        if (this.isFinish)
        {
            this.enemyCtrl.Agent.isStopped = this.isFinish;
            Debug.Log("Finish", gameObject);
            return;
        }

        if (!isMoving)
        {
            this.enemyCtrl.Agent.isStopped = !isMoving;
            return;
        }


        this.enemyCtrl.Agent.SetDestination(this.targetPoint.Targets[this.targetIndex].transform.position);
        this.GetNextPoint();
    }

    protected void GetNextPoint()
    {
        this.GetDistance();
        if (this.distance < this.distanceLimit) this.targetIndex++;
        if (this.targetIndex > this.targetPoint.Targets.Count - 1) this.isFinish = true;
    }

    protected void GetDistance()
    {
        this.distance = Vector3.Distance(this.transform.position, this.targetPoint.Targets[this.targetIndex].transform.position);
    }

    protected virtual void SetMoving()
    {
        if (enemyCtrl.EnemyDameReceive.SetIsDead())
        {
            this.isMoving = !enemyCtrl.EnemyDameReceive.SetIsDead();
            this.EnemyCtrl.Animator.SetBool("isMoving", this.isMoving);
            return;
        }
        this.isMoving = !EnemyCtrl.Agent.isStopped;
        this.EnemyCtrl.Animator.SetBool("isMoving", this.isMoving);
    }
}
