using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    public GameObject helpPanel;
    private bool isPanelActive = false;

    public void ToggleHelpPanel()
    {
        // ����������, �� ������ ����� �������
        if (isPanelActive)
        {
            // ���� ���, �� ������ ������ �� ������������ isPanelActive � false
            helpPanel.SetActive(false);
            isPanelActive = false;
        }
        else
        {
            // ���� �, �� �������� ������ �� ������������ isPanelActive � true
            helpPanel.SetActive(true);
            isPanelActive = true;
        }
    }
}
