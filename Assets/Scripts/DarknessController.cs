using System.Collections;
using UnityEngine;

public class DarknessController : MonoBehaviour
{
    public GameObject darknessPanel;

    void Start()
    {
        StartCoroutine(DarkenScreen(1f));
    }

    IEnumerator DarkenScreen(float duration)
    {
        darknessPanel.SetActive(true);

        yield return new WaitForSeconds(duration);

        darknessPanel.SetActive(false);
    }
}