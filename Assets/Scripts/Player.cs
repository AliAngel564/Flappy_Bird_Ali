using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [Header("Dependencies")]
    public gameManager gameManager;
    public ParticleSystem ps;
    [Header("Bird Variables")]
    public bool isDead;
    public float flapVelocity = 2f;
    public float dashForce = 0.5f;
    public bool isDashing;
    [Header("Bird Components")]
    public Rigidbody2D birdRB;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ps.Stop();
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

        if (Input.GetMouseButtonDown(1))
        {
            isDashing = true;
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
}
