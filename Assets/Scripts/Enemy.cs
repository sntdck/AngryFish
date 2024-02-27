using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target; 
    public float speed = 7f;
    public GameManagerScript gameManager;
    public BoatController boatController;

    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);

            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.gameOver();
            //Debug.Log("Гра закінчена! Герой наздогнано!");
        }
    }
}
