using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    private float bottomLimit = -5;
  
    public int score;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (transform.position.y < bottomLimit)
        {
            Destroy(gameObject);
        }
    }
}
