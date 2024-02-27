using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

public class LeftControll : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
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
            Vector3 rightDirection = Vector3.right;

            Vector3 playerDirection = player.transform.rotation * rightDirection;

            player.transform.Translate(playerDirection * speed * Time.deltaTime);
            player.transform.Rotate(Vector3.up, -rotation * Time.deltaTime);
            player.transform.Rotate(Vector3.right, -rotationX * Time.deltaTime);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ispressed = true;
        quaternionR = Quaternion.Euler(-10, -280, 0);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ispressed = false;
        quaternionR = Quaternion.Euler(0, -270, 0);
    }
}