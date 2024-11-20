using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManageS : MMonoBehaviour
{
    public CinemachineFreeLook freeLookCamera;
    public Transform player;

    protected virtual void Update()
    {
        if (Input.GetMouseButton(1))
        {
            freeLookCamera.m_XAxis.m_InputAxisName = "Mouse X";
            freeLookCamera.m_YAxis.m_InputAxisName = "Mouse Y";

            freeLookCamera.m_XAxis.m_InputAxisValue = Input.GetAxis("Mouse X");
            freeLookCamera.m_YAxis.m_InputAxisValue = Input.GetAxis("Mouse Y");
        }
        else
        {
            freeLookCamera.m_XAxis.m_InputAxisName = null;
            freeLookCamera.m_YAxis.m_InputAxisName = null;
        }
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCinemachineFreeLook();
    }
    protected virtual void LoadCinemachineFreeLook()
    {
        if (this.freeLookCamera != null) return;
        this.freeLookCamera = GetComponent<CinemachineFreeLook>();
        Debug.Log(transform.name + ": LoadCinemachineFreeLook", gameObject);
    }
}
