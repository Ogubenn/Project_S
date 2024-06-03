using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmFollowCamera : MonoBehaviour
{
    public Transform cameraTransform;
    public GameObject arm;

    private void Update()
    {
        FollowCamera();
    }

    private void FollowCamera()
    {
        if (cameraTransform != null && arm != null)
        {
            // Sadece kolun rotasyonunu kameran�n rotasyonuna e�itle
            arm.transform.rotation = cameraTransform.rotation;
        }
    }
}
