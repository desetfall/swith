using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSwtichPanels : MonoBehaviour
{
    [SerializeField] private GameObject parentPanel, targetPanel;

    public void Switch()
    {
        parentPanel.SetActive(false);
        targetPanel.SetActive(true);
    }
}
