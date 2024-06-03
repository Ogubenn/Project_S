using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastActions : MonoBehaviour
{
    private Ray ray;
    private Camera cam;
    private RaycastHit hit;

    void Start()
    {
        cam = Camera.main; //main kamera olmas� gerekli ondan b�yle yapt�k
    }

   
    void Update()
    {
        ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if(Physics.Raycast(ray,out hit, 100))
        {
            if(hit.collider.TryGetComponent(out Targetable targetable))
            {
                targetable.ToggleHighlight(true);
            }
        }
    }
}
