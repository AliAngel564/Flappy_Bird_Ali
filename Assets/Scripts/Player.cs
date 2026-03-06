using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [Header("Dependencies")]
    public Obstacle obstacle;
    public spawner  pipeSpawner;
    public gameManager gameManager;
    public ParticleSystem ps;
    [Header("Bird Variables")]
    public bool isDead = false;
    public float flapVelocity = 2f;
    public float dashForce = 0.5f;
    public float dashImpulse = 1f;
    private bool isDashAvailable = true;
    [Header("Bird Components")]
    public Rigidbody2D birdRB;
    private Transform playerTransform;
    private Vector2 initialPosition;
    
    private float initialPipeVelocity = 1;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ps.Stop();
        playerTransform = GetComponent<Transform>();
        isDead = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameManager.GameStarted = true;
            birdRB.constraints = RigidbodyConstraints2D.None;
            birdRB.linearVelocity = Vector2.up * flapVelocity;
        }

        if (Input.GetMouseButtonDown(1) && isDashAvailable)
        {
            //birdRB.position;
            StartCoroutine(Dash(isDashAvailable,playerTransform));
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        gameManager.GameOver();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ScoreTrigger")
        {
            gameManager.UpScore();
        }
    }

    IEnumerator Dash(bool dash,Transform _playerTransform)
    {
        pipeSpawner.queueTime = 1.5f;
        obstacle.pipeSpeed += dashForce;
        initialPosition= transform.position;
        isDashAvailable = false;
        ps.Play();
        foreach (GameObject obstacles in pipeSpawner.ObstacleList)
        {
            if (obstacles.TryGetComponent(out Obstacle obstacle))
            {
                obstacle.pipeSpeed += dashForce;
            }
        }

        yield return new WaitForSecondsRealtime(1);
        pipeSpawner.queueTime = 3;
        obstacle.pipeSpeed = initialPipeVelocity;
        isDashAvailable = true;
        obstacle.pipeSpeed = initialPipeVelocity;
        foreach (GameObject obstacles in pipeSpawner.ObstacleList)
        {
            if (obstacles.TryGetComponent(out Obstacle obstacle))
            {
                obstacle.pipeSpeed = initialPipeVelocity;
                
            }
        }
    }
}
