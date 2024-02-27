using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Text speedAmount;
    public BoatController boatController;
    public Text distanceAmount;

    void Update()
    {
        if (boatController != null && speedAmount != null)
        {
            speedAmount.text = "Speed: " + boatController.speed.ToString("F2") + " m";
        }

        if (boatController != null && distanceAmount != null)
        {
            distanceAmount.text = "Distance: " + boatController.GetDistanceTraveled().ToString("F2") + " m";
        }
    }
}
