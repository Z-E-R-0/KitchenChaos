using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisuals : MonoBehaviour
{
    [SerializeField] private BaseCounter baseCounter;
    [SerializeField] private GameObject[] visualGameObjectArray;
    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
        Hide();
    }

    private void Player_OnSelectedCounterChanged(object sender,Player.OnSelectedCounterChangedEventArgs e)
    {
        if(e.selectedCounter ==baseCounter)
        {
            Show();
        }

        else
        {
            Hide();

        }
       // e.selectedCounter
    }

    private void Show()
    {
        foreach (GameObject visualGameObjects in visualGameObjectArray)
        {
            visualGameObjects.SetActive(true);
        }

    }

    private void Hide()
    {
        foreach (GameObject visualGameObjects in visualGameObjectArray)
        {
            visualGameObjects.SetActive(false);
        }

    }
}
