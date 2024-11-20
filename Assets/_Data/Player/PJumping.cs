using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PJumping : PMoving
{
    [Header("Jumping")]
    public float jumpForce = 5f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public float maxDistance = 10;
    public float distanceToGround;

    public int jumpCount = 0;
    public int maxJumpCount = 1;
    public Transform originPoint;

    [SerializeField] protected bool isGrounded;
    [SerializeField] protected bool isLanding;
    [SerializeField] protected bool isJumping;
    [SerializeField] protected bool isFalling;

    protected override void Start()
    {
        base.Start();
        if (this._rigidbody == null)
        {
            this._rigidbody = GetComponent<Rigidbody>();
        }
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.CheckIsGrounded();
        this.GetDistanceToGround();
    }

    protected override void Update()
    {
        base.Update();
        this.UpdateStates();
        this.HandleJump();
    }

    protected virtual void UpdateStates()
    {
        if (distanceToGround > 1f)
        {
            isFalling = true;
            isLanding = false;
        }
        else if (distanceToGround <= 1f && !isGrounded)
        {
            isFalling = false;
            isLanding = true;
        }

        if (isGrounded)
        {
            isJumping = false;
            isFalling = false;
            isLanding = false;
        }

        animator.SetBool("isFalling", isFalling);
        animator.SetBool("isLanding", isLanding);
        animator.SetBool("isJumping", isJumping);
        this.animator.SetBool("isGrounded", this.isGrounded);
    }

    protected virtual void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount)
        {
            isJumping = true;
            isLanding = false;
            animator.SetBool("isJumping", isJumping);
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, jumpForce, _rigidbody.velocity.z);
            jumpCount++;
        }
    }

    protected virtual void CheckIsGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
        if (isGrounded)
        {
            jumpCount = 0;
        }
    }

    protected void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }

    protected virtual void GetDistanceToGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(this.originPoint.position, Vector3.down, out hit, maxDistance, groundLayer))
        {
            Debug.DrawLine(this.originPoint.position, hit.point);
            this.distanceToGround = hit.distance;
            return;
        }

        this.distanceToGround = -1f;
    }

    protected virtual void CheckFalling()
    {
        if (this.distanceToGround > 1)
        {
            this.isFalling = true;
            this.animator.SetBool("isFalling", this.isFalling);
            return;
        }
        if (this.distanceToGround <= 1)
        {
            this.isFalling = false;
            this.isLanding = true;
            this.animator.SetBool("isLanding", this.isLanding);
        }

        if (this.isGrounded)
        {
            this.isLanding = false;
        }
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGroundCheck();
        this.LoadLayerMask();
    }

    protected virtual void LoadGroundCheck()
    {
        if (this.groundCheck != null) return;
        this.groundCheck = transform.parent.Find("GroundCheck");
        Debug.Log(transform.name + ": LoadGroundCheck", gameObject);
    }

    protected virtual void LoadLayerMask()
    {
        if (this.groundLayer != LayerMask.GetMask("Nothing")) return;
        this.groundLayer = LayerMask.GetMask("Env");
        Debug.Log(transform.name + ": LoadLayerMask", gameObject);
    }
}
