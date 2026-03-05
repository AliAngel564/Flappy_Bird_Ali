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
    public List<GameObject> ObstacleList = new List<GameObject>();

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
            go.transform.position = spawnPoint.localPosition + new Vector3(0, Random.Range(-height, height), 0);
            ObstacleList.Add(go);
            time = 0;

            Destroy(go, 10);
        }
        CheckForNullObstacle();
        time += Time.deltaTime;
    }

    void CheckForNullObstacle()
    {
        foreach (GameObject obstacle in ObstacleList)
        { 
            if (obstacle == null)
            {
                ObstacleList.Remove(obstacle);
            }
            
        }
    }
}
