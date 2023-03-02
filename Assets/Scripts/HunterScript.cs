using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterScript : MonoBehaviour {
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 4.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newHuntPos = Vector3.MoveTowards(transform.position, PlayerScript.Instance.player.transform.position, speed * Time.deltaTime);
        transform.position = newHuntPos;
    }
}
