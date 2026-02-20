using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    public bool isDead = false;
    public float flapVelocity = 2f;
    private Rigidbody2D birdRB;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        birdRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            birdRB.linearVelocity = Vector2.up * flapVelocity;
        }
    }
    
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        gameManager.GameOver();
    }
}
