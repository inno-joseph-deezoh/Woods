using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    private const float LANE_DISTANCE = 1.8f;

    private int posLeft = -1;
    private int posRight = 2;
    private int spawnPosY = 5;

    private float spawnInterval = 1.0f;

    //prefab objects, aid and ghost
    public GameObject[] objectPrefab;
    // Spawn random ball at random x position at top of play area
    private void Start()
    {
        SpawnObs();
    }
    public void SpawnObs()
    { 
        Vector3 Pos = new Vector3(Random.Range(posLeft, posRight), spawnPosY, 0);

        // This does the actual spawning of the balls
        Instantiate(objectPrefab[0], Pos * LANE_DISTANCE, objectPrefab[0].transform.rotation);

        // This makes the method be called after every frame
        Invoke("SpawnObs", spawnInterval);
    }
}
