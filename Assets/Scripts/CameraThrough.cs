using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraThrough : MonoBehaviour
{
    public GameObject mainCam;
    public Vector3 left;
    public Vector3 right;
    public Vector3 middle;

    private void Update()
    {
        if(MobileScript.Instance.SwipeLeft == true)
        {
            transform.position = left;
        }else if (MobileScript.Instance.SwipeRight == true)
        {
            transform.position = right;
        }else
        {
            transform.position = middle;
        }
    }
}
