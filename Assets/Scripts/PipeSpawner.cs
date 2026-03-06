using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class spawner : MonoBehaviour
{
    public float queueTime = 1.5f;
    private float time = 0;
    public GameObject obstacle;
    private Transform spawnPoint;
    public List<GameObject> PipePool = new List<GameObject>();
    public Transform pipeSpawnPoint;
    
    public float height;

    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    
    void CheckForThreshold()
    {
        foreach (GameObject obstacle in PipePool)
        { 
            
        }
    }
}
