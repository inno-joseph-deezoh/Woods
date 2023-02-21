using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //Constants
    private const float LANE_DISTANCE = 1.8f;

    //player char variable
    private CharacterController charController;

    // floats variables
    private float speed = 50.0f;

    //lane formulae
    private int lane = 1; //0 = left, 1 = middle, 2 = right.

    //setting player transform position
    public GameObject player;

    //script references
    public static PlayerScript Instance { set; get; }

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        //Gather inputs on which lane we should be
        if (MobileScript.Instance.SwipeLeft)
            SwitchLane(false);
        if (MobileScript.Instance.SwipeRight)
            SwitchLane(true);

        // gather input where we should be
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SwitchLane(false);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SwitchLane(true);
        }

        // calculate where we should be
        Vector3 movePosition = transform.position.z * Vector3.zero;
        if (lane == 0)
        {
            movePosition += Vector3.left * LANE_DISTANCE;
        }
        else if (lane == 2)
        {
            movePosition += Vector3.right * LANE_DISTANCE;
        }

        // calculate movement
        Vector3 moveVector = Vector3.zero;
        moveVector.x = (movePosition - transform.position).normalized.x * speed;

        //move the pet
        charController.Move(moveVector * Time.deltaTime);
    }

    private void SwitchLane(bool goingRight)
    {
        //switch lanes
        lane += (goingRight) ? 1 : -1;
        lane = Mathf.Clamp(lane, 0, 2);
    }
}
