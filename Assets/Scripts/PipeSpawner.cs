using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class spawner : MonoBehaviour
{
    public float queueTime = 1.5f;
    private float time = 0;
    public GameObject obstacle;
    private Transform spawnPoint;

    public float height;

    void Start()
    {
        spawnPoint = GetComponent<Transform>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(time > queueTime)
        {
            GameObject go = Instantiate(obstacle);
            go.transform.position = spawnPoint.position + new Vector3(0, Random.Range(-height, height), 0);

            time = 0;

            Destroy(go, 10);
        }

        time += Time.deltaTime;
    }
}
