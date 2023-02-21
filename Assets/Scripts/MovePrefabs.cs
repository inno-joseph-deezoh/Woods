using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePrefabs : MonoBehaviour
{
    private float speed;
    public Vector3 ghostPos;
    public Vector3 playerPos;

    private float middleLimit = 4.0f;
    private float towardsSpeed;
    // Start is called before the first frame update
    void Start()
    {
       speed = 4.0f;
        towardsSpeed = 4.0f;
        ghostPos = gameObject.transform.position;
        playerPos = PlayerScript.Instance.player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        TowardsPlayer();
    }
    public void ChangeSpeed()
    {
        if (GameManager.Instance.score >= 0)
        {
            speed++;
        }
    }

   public void TowardsPlayer()
    {
        if (transform.position.y < middleLimit && GameManager.Instance.score >=10)
        {
           transform.position = Vector3.MoveTowards(transform.position, playerPos, Time.deltaTime * towardsSpeed);
        }
    }
}
