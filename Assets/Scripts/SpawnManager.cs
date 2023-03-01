using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private const float LANE_DISTANCE = 1.8f;

    private int posLeft = -1;
    private int posRight = 2;
    private float spawnPosZ = 7.0f;

    private float spawnInterval = 1.0f;

    //an instance of the script
    public static SpawnManager Instance { set; get; }

    //prefab objects, aid and ghost
    public GameObject[] objectPrefab;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SpawnObs();
    }
    // Spawn random ball at random x position at top of play area
    public void SpawnObs()
    {
       // if (GameManager.Instance.gameStarted == true) {
            Vector3 Pos = new Vector3(Random.Range(posLeft, posRight), 0, spawnPosZ);

            // Instantiate ball at random spawn location
            int randomObs = Random.Range(0, objectPrefab.Length);

            // This does the actual spawning of the balls
            Instantiate(objectPrefab[randomObs], Pos * LANE_DISTANCE, objectPrefab[randomObs].transform.rotation);

            // This makes the method be called after every frame
            Invoke("SpawnObs", spawnInterval); 
      //  }
    }

    public void DisableOnCollision()
    {
        objectPrefab = GameObject.FindGameObjectsWithTag("Ghost");
        foreach (GameObject objectP in objectPrefab)
        {
            objectP.SetActive(false);
        }
    }

    public void DisableOnPause()
    {
        objectPrefab = GameObject.FindGameObjectsWithTag("Ghost");
        foreach (GameObject objectP in objectPrefab)
        {
            objectP.SetActive(false);
        }
    }
}
