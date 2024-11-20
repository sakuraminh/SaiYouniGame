using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAiming : MMonoBehaviour
{
    [SerializeField] protected float turnSpeet = 15;

    [SerializeField] protected Camera mainCamera;

    [SerializeField] protected RayCastWeapon rayCastWeapon;



    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMainCamera();
        this.LoadRayCastWeapon();
    }

    protected virtual void FixedUpdate()
    {
        float yawCamera = this.mainCamera.transform.rotation.eulerAngles.y;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), this.turnSpeet * Time.fixedDeltaTime);
    }

    protected void LoadRayCastWeapon()
    {
        if (this.rayCastWeapon != null) return;
        this.rayCastWeapon = GetComponentInChildren<RayCastWeapon>();
        Debug.Log(transform.name + ": LoadRayCastWeapon", gameObject);
    }

    protected virtual void LoadMainCamera()
    {
        this.mainCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }


}
