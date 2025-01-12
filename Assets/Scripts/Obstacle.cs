using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private PlayerMovment playerMovent;

    private void Start()
    {
        playerMovent = FindAnyObjectByType<PlayerMovment>();
        if (playerMovent == null)
        {
            Debug.LogError("PlayerMovment script not found!");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player collided with obstacle!");
            playerMovent.Die();
        }
    }
}
