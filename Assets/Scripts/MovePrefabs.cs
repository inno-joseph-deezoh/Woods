using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePrefabs : MonoBehaviour
{
    private float speed;
    private void Start()
    {
        speed = 4.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }
    public float TimeIncrease()
    {
        if(GameManager.Instance.score >= 10)
        {
            speed = speed + 0.02f;
        }
        return speed;
    }
}
