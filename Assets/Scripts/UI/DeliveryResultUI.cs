using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryResultUI : MonoBehaviour
{
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private Color successColor;    
    [SerializeField] private Color failColor;
    [SerializeField] private Sprite successSprite;
    [SerializeField] private Sprite failSprite;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        DeliveryManager.Instance.OnRecipeSuccess += DeliveryManager_OnRecipeSuccess;
        DeliveryManager.Instance.OnRecipeFail += DeliveryManager_OnRecipeFail;
    }

    private void DeliveryManager_OnRecipeFail(object sender, System.EventArgs e)
    {
       backgroundImage.color = failColor;
        iconImage.sprite = failSprite;
        messageText.text = "DELIVERY\nFAILED";
    }

    private void DeliveryManager_OnRecipeSuccess(object sender, System.EventArgs e)
    {
       backgroundImage.color=successColor;
        iconImage.sprite=successSprite;
        messageText.text = "DELIVERY\nSUCCESS";
    }
}
