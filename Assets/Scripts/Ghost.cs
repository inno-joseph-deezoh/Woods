using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            GameManager.Instance.IncreaseScore();
        }

        if(other.tag == "Player")
        {
            GameManager.Instance.gameStopped = true;
            GameManager.Instance.gameStarted = false;
        }
    }
}
