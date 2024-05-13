using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraAspect : MonoBehaviour
{
    private Camera _cam;
    private float targetAspect = 16f / 9f;
    public CanvasScaler canvasScaler;
    // Start is called before the first frame update
    void Start()
    {
        _cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((float)Screen.width / (float)Screen.height < targetAspect)
        {
            _cam.orthographicSize = 4 + Mathf.Pow(5f, (targetAspect - (float)Screen.width / (float)Screen.height) * 1.25f);
            canvasScaler.matchWidthOrHeight = 0;
        }
        else
        {
            _cam.orthographicSize = 5;
            canvasScaler.matchWidthOrHeight = 1;
            if ((float)Screen.width / (float)Screen.height > targetAspect)
            {
                //_cam.orthographicSize = 5 + ((float)Screen.width / (float)Screen.height - targetAspect) * 5f;
            }
            else
            {

            }

        }
    }
}
 