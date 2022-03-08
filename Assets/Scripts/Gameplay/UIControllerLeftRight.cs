using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIControllerLeftRight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Player player;
    [SerializeField] private bool IsThisLeftBtn;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (IsThisLeftBtn)
        {
            player.IsLeftBtnPressed = true;
        }
        else
        {
            player.IsRightBtnPressed = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (IsThisLeftBtn)
        {
            player.IsLeftBtnPressed = false;
        }
        else
        {
            player.IsRightBtnPressed = false;
        }
    }
}
