using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Obstacle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float pipeSpeed = 1f;
    public float height = 1f;
    
    // Update is called once per frame
    private void Start()
    {
        pipeSpeed = 1f;
        transform.position += new Vector3(0, Random.Range(-height, height), 0);
    }
    void Update()
    {
        transform.position += (Vector3.left * (pipeSpeed * Time.deltaTime));
    }
    
}
