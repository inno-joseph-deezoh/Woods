using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public GameObject spawns;
   private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            GameManager.Instance.IncreaseScore();
        }

        if(other.tag == "MainCamera")
        {
            GameManager.Instance.gameStarted = false;
            GameManager.Instance.gameStopped = true;
            SpawnManager.Instance.DisableOnCollision();
        }
    }
}
