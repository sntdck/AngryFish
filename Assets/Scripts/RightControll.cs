using UnityEngine.EventSystems;
using UnityEngine;

public class RightControll : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private bool ispressed = false;
    public GameObject player;
    public float speed = 8f;
    public float rotation = 8f;
    public float rotationX = 8f;

    private Quaternion quaternionR;

    private void Start()
    {
        quaternionR = player.transform.rotation;
    }

    private void Update()
    {
        if (ispressed)
        {
            Vector3 leftDirection = Vector3.left;

            Vector3 playerDirection = player.transform.rotation * leftDirection;

            player.transform.Translate(playerDirection * speed * Time.deltaTime);

            player.transform.Rotate(Vector3.up, rotation * Time.deltaTime);
            player.transform.Rotate(Vector3.right, rotationX * Time.deltaTime);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ispressed = true;
        quaternionR = Quaternion.Euler(10, -260, 0);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ispressed = false;
        quaternionR = Quaternion.Euler(0, -270, 0);
    }
}