using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomControl : MonoBehaviour
{
    [SerializeField] private float YakinlestirmaSpeed = 0.1f;
    [SerializeField] private float UzaklastirmaSpeed = 0.1f;
    [SerializeField] private float maxZoom = 1f;
    [SerializeField] private float minZoom = 0f;
    public float currentZoom = 0f;
    private Coroutine zoomCoroutine = null;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (zoomCoroutine != null)
            {
                StopCoroutine(zoomCoroutine);
            }
            zoomCoroutine = StartCoroutine(ZoomIn());
        }

        if (Input.GetMouseButtonUp(1))
        {
            if (zoomCoroutine != null)
            {
                StopCoroutine(zoomCoroutine);
            }
            zoomCoroutine = StartCoroutine(ZoomOut());
        }
    }

    private IEnumerator ZoomIn()
    {
        while (currentZoom < maxZoom)
        {
            currentZoom += YakinlestirmaSpeed * Time.deltaTime;
            currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);


            Camera.main.fieldOfView = Mathf.Lerp(60, 20, currentZoom);

            yield return null;
        }
    }

    private IEnumerator ZoomOut()
    {
        while (currentZoom > minZoom)
        {
            currentZoom -= UzaklastirmaSpeed * Time.deltaTime;
            currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);


            Camera.main.fieldOfView = Mathf.Lerp(20, 60, 1 - currentZoom);

            yield return null;
        }
    }
}
