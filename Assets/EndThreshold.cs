using UnityEngine;

public class EndThreshold : MonoBehaviour
{
    public Transform spawnPoint;
    private void OnTriggerEnter2D(Collider2D other)
    {

        var obstacle = other.GetComponentInParent<Obstacle>();
        other.transform.parent.position = spawnPoint.transform.position + new Vector3(0, Random.Range(-obstacle.height, obstacle.height), 0);
        Debug.Log("entra pipa");
    }
    
    
}
