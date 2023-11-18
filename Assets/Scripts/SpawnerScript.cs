using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject tubePrefab;

     public float spawnTime = 3f;
    // Use this for initialization
    void Start () {
        InvokeRepeating ("SpawnTube", 0, spawnTime);
    }

    // Update is called once per frame
    void Update () {

    }    

    void SpawnTube()
    {
        Instantiate(tubePrefab, new Vector3(transform.position.x, Random.Range(-0.8f, 0.8f), transform.position.z), Quaternion.identity);
    }
}
