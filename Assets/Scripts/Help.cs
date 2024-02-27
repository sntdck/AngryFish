using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    public GameObject helpPanel;
    private bool isPanelActive = false;

    public void ToggleHelpPanel()
    {
        // ѕерев≥р€Їмо, чи панель зараз активна
        if (isPanelActive)
        {
            // якщо так, то ховаЇмо панель та встановлюЇмо isPanelActive в false
            helpPanel.SetActive(false);
            isPanelActive = false;
        }
        else
        {
            // якщо н≥, то показуЇмо панель та встановлюЇмо isPanelActive в true
            helpPanel.SetActive(true);
            isPanelActive = true;
        }
    }
}
