using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI recipiesDeliveredText;
    private void Start()
    {

        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
        Hide();
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsGameOver())
        {
            Show();
            recipiesDeliveredText.text = DeliveryManager.Instance.GetSucessfulRecipiesAmount().ToString();

        }

        else
        {
            Hide();

        }

    }
    private void Update()
    {
        
    }

    private void Show()
    {

        gameObject.SetActive(true);

    }

    private void Hide()
    {

        gameObject.SetActive(false);


    }
}
