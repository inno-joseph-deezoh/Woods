using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileScript : MonoBehaviour
{
    private const float DEADZONE = 100.0f;
    public static MobileScript Instance { set; get; }

    private bool tap, swipeLeft, swipeRight;
    private Vector2 swipeDelta, startTouch;

    public bool Tap { get { return tap; } }
    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }

    private void Awake()
    {
        Instance = this;
    }

    private void LateUpdate()
    {
      //  if (GameManager.Instance.gameStarted == false)
         //   return;
        //Reseting all the boleans
        tap = swipeLeft = swipeRight = false;

        //let's check for input
        #region Standalone Inputs

        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            startTouch = swipeDelta = Vector2.zero;
        }

        #endregion

        #region Mobile Inputs

        if (Input.touches.Length != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                startTouch = Input.mousePosition;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                startTouch = swipeDelta = Vector2.zero;
            }
        }
        #endregion

        // calculate the distances
        swipeDelta = Vector2.zero;
        if (startTouch != Vector2.zero)
        {
            //let's check with mobile
            if (Input.touches.Length != 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            //check with standalone
            else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        //check if swipe is beyond the deadzone
        if (swipeDelta.magnitude > DEADZONE)
        {
            //It's a swipe
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y)) // Mathf.Abs turns the negative values to positive
            {
                //left or right
                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }
            startTouch = swipeDelta = Vector2.zero;
        }
    }
}
