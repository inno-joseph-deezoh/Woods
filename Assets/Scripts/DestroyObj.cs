using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    private float backLimit = -2;
  
    private void Update()
    {
        if (transform.position.z < backLimit)
        {
            Destroy(gameObject);
        }
    }
}
