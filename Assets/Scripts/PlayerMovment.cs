using System;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovment : MonoBehaviour
{
    private bool alive = true;

    public float speed = 5f;
    public Rigidbody rb;
    private float horizontalInput;
    public float horizontalMultiplier = 2f;

    private void FixedUpdate()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;

        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }

    public void Die()
    {
        alive = false;
        Debug.Log("Player died. Restarting scene...");
        Invoke("restart", 2);

    }

    void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
