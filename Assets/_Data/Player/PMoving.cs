using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;

public class PMoving : PlayerAbs
{
    [SerializeField] protected Rigidbody _rigidbody;
    [SerializeField] protected Camera mainCamera;
    [SerializeField] protected Animator animator;

    [SerializeField] protected float turnSpeet = 15;
    [SerializeField] protected float moveSpeed = 5f;

    [SerializeField] protected Vector2 input;

    [SerializeField] protected bool isMoving = true;

    protected Vector3 moveDirection;

    protected virtual void Update()
    {
        this.UpdateInput();
        this.CalculateMoveDirection();
        this.UpdateAnimator();
    }

    protected virtual void FixedUpdate()
    {
        this.CharacterAiming();
        this.MoveCharacter();
    }
    protected virtual void UpdateInput()
    {
        this.input.x = InputManageS.Instance.XHorizontal;
        this.input.y = InputManageS.Instance.YVertical;
    }

    protected virtual void CharacterAiming()
    {
        float yawCamera = this.mainCamera.transform.rotation.eulerAngles.y;

        transform.parent.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), this.turnSpeet * Time.fixedDeltaTime);
    }

    protected virtual void CalculateMoveDirection()
    {
        Vector3 forward = this.mainCamera.transform.forward;
        Vector3 right = this.mainCamera.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        this.moveDirection = (forward * this.input.y + right * this.input.x).normalized;
        this.isMoving = this.input != Vector2.zero;
    }

    protected virtual void MoveCharacter()
    {
        if (!this.isMoving) return;

        Vector3 velocity = this.moveDirection * this.moveSpeed;
        this._rigidbody.MovePosition(this._rigidbody.position + velocity * Time.fixedDeltaTime);
    }

    protected virtual void UpdateAnimator()
    {
        this.animator.SetFloat("InputX", this.input.x);
        this.animator.SetFloat("InputY", this.input.y);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigidbody();
        this.LoadMainCamera();
        this.LoadAnimator();
    }

    protected void LoadRigidbody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = GetComponentInParent<Rigidbody>();
        Debug.Log(transform.name + ": LoadRigidbody", gameObject);
    }

    protected virtual void LoadMainCamera()
    {
        if (mainCamera != null) return;
        this.mainCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log(transform.name + ": LoadMainCamera", gameObject);
    }

    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = transform.parent.Find("Model").GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }
}
