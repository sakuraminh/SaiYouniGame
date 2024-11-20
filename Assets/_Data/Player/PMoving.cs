using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;

public class PMoving : PlayerAbs
{
    [SerializeField] protected Rigidbody _rigidbody;
    public Rigidbody Rigidbody => this._rigidbody;

    [SerializeField] protected Transform _camera;

    [SerializeField] protected Animator animator;

    [SerializeField] protected Vector3 movement;
    [SerializeField] protected Vector3 forward;
    [SerializeField] protected Vector3 right;
    [SerializeField] protected Vector3 moveDirection;

    [SerializeField] protected float moveSpeed = 5f;
    [SerializeField] protected float rotationSpeed = 720f;

    [SerializeField] protected bool isMoving = true;


    [SerializeField] protected Vector2 input;

    protected virtual void Update()
    {
        this.SetInput();
        this.RedirectionOnCamera();
        this.CalculateDirection();
        this.RotateInDirection();
        this.PlayerMoving();
    }
    protected virtual void SetInput()
    {
        this.input.x = InputManageS.Instance.XHorizontal;
        this.input.y = InputManageS.Instance.YVertical;
        this.SetAnimation();
    }
    protected virtual void SetAnimation()
    {
        this.animator.SetFloat("InputX", this.input.x);
        this.animator.SetFloat("InputY", this.input.y);


    }
    protected virtual void PlayerMoving()
    {

        if (this.isMoving == false) return;

        Vector3 moveVelocity = moveDirection * moveSpeed;
        this._rigidbody.MovePosition(this._rigidbody.position + moveVelocity * Time.fixedDeltaTime);


    }
    protected virtual void RedirectionOnCamera()
    {
        this.forward = this._camera.forward;
        this.right = this._camera.right;

        this.forward.y = 0;
        this.right.y = 0;

        this.forward.Normalize();
        this.right.Normalize();
    }

    protected virtual void CalculateDirection()
    {
        this.moveDirection = (forward * InputManageS.Instance.YVertical + right * InputManageS.Instance.XHorizontal).normalized;
        if (this.input == Vector2.zero)
        {
            this.isMoving = false;
            return;
        }

        this.isMoving = true;
    }

    protected virtual void RotateInDirection()
    {
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            this._rigidbody.rotation = Quaternion.Slerp(this._rigidbody.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigidbody();
        this.LoadAnimator();
        this.LoadCamera();
    }
    protected void LoadRigidbody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = transform.parent.GetComponent<Rigidbody>();
        Debug.Log(transform.name + ": LoadRigidbody", gameObject);
    }
    protected void LoadCamera()
    {
        if (this._camera != null) return;
        this._camera = GameObject.Find("Camera").transform;
        Debug.Log(transform.name + ": LoadCamera", gameObject);
    }

    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = transform.parent.GetComponentInChildren<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }


}
