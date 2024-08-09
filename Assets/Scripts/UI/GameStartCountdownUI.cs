using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameStartCountdownUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText;
    private Animator animator;
    private int previousCountdownNumber;
    private const string NUMBER_POPUP = "NumberPopUP";

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
        Hide();
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if(GameManager.Instance.IsCountDownToStartActive())
        {
            Show();


        }

        else
        {
            Hide();

        }
      
    }
    private void Update()
    {
        int countdownNumber = Mathf.CeilToInt(GameManager.Instance.GetCountdownToStartTimer());
        countdownText.text = countdownNumber.ToString();
        if(previousCountdownNumber != countdownNumber)
        {
           previousCountdownNumber = countdownNumber;
            animator.SetTrigger(NUMBER_POPUP);
            SoundManager.Instance.PlayCountdownSound();

        }
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
