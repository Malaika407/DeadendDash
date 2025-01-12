using UnityEngine;

public class Coins : MonoBehaviour
{
    public float turnSpeed = 90f; // Rotation speed for visual effect
    public float lifetime = 10f; // Time after which the coin is destroyed if not collected

    private void Start()
    {
        // Destroy the coin after its lifetime if not collected
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is an obstacle
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(other.gameObject);
            return;
        }

        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Coin collected!");
            Destroy(gameObject); // Destroy the coin
        }

    }
        void Update()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1f);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("Player"))
                {
                    Debug.Log("Coin collected!");
                GameManager.instance.IncrementScore();
                Destroy(gameObject);
                }
            }
       
        transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
    }
}
