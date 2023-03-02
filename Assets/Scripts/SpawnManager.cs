using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SpawnManager : MonoBehaviour
{
    private const float LANE_DISTANCE = 1.8f;

    private int posLeft = -1;
    private int posRight = 2;
    private float spawnPosZ = 7.0f;

    private float spawnInterval = 1.5f;

    //an instance of the script
    public static SpawnManager Instance { set; get; }

    //prefab objects, aid and ghost
    public GameObject[] objectPrefab;
    public GameObject hunter;

    public int countSpawn;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        countSpawn = 0;
    }
    // Spawn random ball at random x position at top of play area
    public void SpawnObs() {

        if (countSpawn <= 10)
        {
            if (GameManager.Instance.gameStarted == true)
            {
                Vector3 Pos = new Vector3(Random.Range(posLeft, posRight), 0, spawnPosZ);

                // Instantiate ball at random spawn location
                int randomObs = Random.Range(0, objectPrefab.Length);

                // This does the actual spawning of the balls
                Instantiate(objectPrefab[randomObs], Pos * LANE_DISTANCE, objectPrefab[randomObs].transform.rotation);

                // This makes the method be called after every frame
                Invoke("SpawnObs", spawnInterval);
                countSpawn++;
                if (countSpawn == 5)
                {
                    AudioManager.Instance.soundEffects.PlayOneShot(AudioManager.Instance.laughing, 1.0f);
                }
            }
        }
        else
        {
            if (GameManager.Instance.gameStarted == true) {
                Vector3 hunterPos = new Vector3(Random.Range(posLeft, posRight), 0, spawnPosZ);
                Instantiate(hunter, hunterPos * LANE_DISTANCE, hunter.transform.rotation);
                countSpawn = 0;
            }
        }
    }

    public void DisableOnCollision()
    {
        AudioManager.Instance.soundEffects.PlayOneShot(AudioManager.Instance.scream, 1.0f);
        objectPrefab = GameObject.FindGameObjectsWithTag("Ghost");
        foreach (GameObject objectP in objectPrefab)
        {
            objectP.SetActive(false);
        }
    }
}
