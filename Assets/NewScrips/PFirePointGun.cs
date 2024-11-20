using UnityEngine;

public class PFirePointGun : MMonoBehaviour
{
    public LayerMask enemyLayer;
    public LayerMask env;

    private void Update()
    {
        this.Shoot();
    }
    void Shoot()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Vector3 cameraDirection = ray.direction;

        Vector3 originPoint = transform.position;
        Ray newRay = new(originPoint, cameraDirection);


        RaycastHit hit;

        Vector3 targetPoint;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, enemyLayer) || Physics.Raycast(ray, out hit, Mathf.Infinity, env))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(10);
        }
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red, 2f);

        Vector3 direction = (targetPoint - transform.position).normalized;

        transform.LookAt(targetPoint);
    }
}
