using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePrefabs : MonoBehaviour
{
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 4.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isSpawning == true) {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }
}
