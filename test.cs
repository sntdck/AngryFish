using System.Collections;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    public float speed = 5f;
    public float horizontalSpeed = 5f;
    private bool isSlowed = false;
    private float originalSpeed;
    public float speedTime = 2f;


    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput * horizontalSpeed, 0f, speed);
        transform.Translate(movement * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            SlowPlayer();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            RestorePlayerSpeedAfterDelay(speedTime);
        }
    }

    private void SlowPlayer()
    {
        if (!isSlowed)
        {
            originalSpeed = speed;
            speed = 7f;
            isSlowed = true;
        }
    }

    private void RestorePlayerSpeedAfterDelay(float delay)
    {
        StartCoroutine(RestorePlayerSpeedCoroutine(delay));
    }

    private System.Collections.IEnumerator RestorePlayerSpeedCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);

        speed = originalSpeed;
        isSlowed = false;
    }
}
