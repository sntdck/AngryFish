using System.Collections;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    public float speed = 10f;
    public float horizontalSpeed = 8f;
    private bool isSlowed = false;
    private float originalSpeed;

    public float returnSpeedTime = 2f;

    private float distanceTraveled = 0f;

    public float winLimit = 1000;

    public GameManagerScript gameManagerScript;

    public AudioSource audioSource;
    public float rotation = 8f;
    public float rotationX = 20f;
    private Quaternion originalRotation;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        originalRotation = transform.rotation;
    }
    void Update()
    {
        Shader.SetGlobalVector("Player", transform.position + Vector3.up);

        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput * horizontalSpeed, 0f, speed);
        transform.Translate(movement * Time.deltaTime, Space.World);

        if (horizontalInput > 0)
        {
            // «м≥н≥ть ротац≥ю лодки вправо
            transform.rotation *= Quaternion.Euler(rotationX * Time.deltaTime, rotation * Time.deltaTime, 0);
        }
        // якщо натиснута кнопка вл≥во
        else if (horizontalInput < 0)
        {
            // «м≥н≥ть ротац≥ю лодки вл≥во
            transform.rotation *= Quaternion.Euler(-rotationX * Time.deltaTime, -rotation * Time.deltaTime, 0);
        }
        // якщо кнопка не натиснута
        else
        {
            // ѕоверн≥ть лодку в початкове положенн€
            transform.rotation = Quaternion.Lerp(transform.rotation, originalRotation, Time.deltaTime * 5f); // Ўвидк≥сть поверненн€ 2f
        }

        distanceTraveled += speed * Time.deltaTime;

        if (distanceTraveled >= winLimit)
        {
            gameManagerScript.winGame();
            //Debug.Log("√равець виграв!");
        }

        // play sound "boat_engine"
        
        if (speed > 0)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }

    public void PauseAudio()
    {
        if (audioSource.isPlaying)
        {
             audioSource.Stop();
             //Debug.Log("Audio Paused");
        }
    }

    public void ResumeAudio()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
            //Debug.Log("Audio Play");
        }
    }

    public float GetDistanceTraveled()
    {
        return distanceTraveled;
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
            RestorePlayerSpeedAfterDelay(returnSpeedTime);
        }
    }

    private void SlowPlayer()
    {
        if (!isSlowed)
        {
            originalSpeed = speed;
            speed = 5f;
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
