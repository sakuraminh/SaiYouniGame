using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairTarget : MMonoBehaviour
{
    public Camera mainCamera;

    public Transform target;

    public float defaultDistance = 100f;

    Ray ray;
    RaycastHit hit;

    public LayerMask enemyLayer;
    public LayerMask env;

    public bool enemyLayerB = true;
    public bool envB = true;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCamera();
    }
    protected void LoadCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = Camera.main;
        Debug.Log(transform.name + ": LoadCamera", gameObject);
    }

    private void Update()
    {


        this.ray.origin = this.mainCamera.transform.position;
        this.ray.direction = this.mainCamera.transform.forward;
        RaycastHit[] hits = Physics.RaycastAll(this.ray, defaultDistance);

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                transform.position = hit.point;

                this.target = hit.transform;

                Debug.DrawLine(this.ray.origin, hit.point, Color.red, 1.0f);

                //Debug.Log("Hit Enemy at: " + hit.point);

                break;
            }

            else
            {
                Vector3 fallbackPoint = ray.origin + ray.direction * defaultDistance;
                transform.position = fallbackPoint;
                Debug.DrawLine(this.ray.origin, fallbackPoint, Color.red, 1.0f);
            }
        }
    }
}
