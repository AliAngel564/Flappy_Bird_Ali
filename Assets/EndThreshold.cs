using UnityEngine;

public class EndThreshold : MonoBehaviour
{
    public Transform spawnPoint;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pipe"))
        {
            other.transform.position = spawnPoint.position;
        }
    }
    
    
}
