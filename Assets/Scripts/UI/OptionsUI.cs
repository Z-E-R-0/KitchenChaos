using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class OptionsUI : MonoBehaviour
{
    public static OptionsUI Instance { get; private set; }
    [SerializeField] private Button soundEffectsButton;
    [SerializeField] private Button musicButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button moveUPButton;
    [SerializeField] private Button moveDownButton;
    [SerializeField] private Button moveLeftButton;
    [SerializeField] private Button moveRightButton;
    [SerializeField] private Button interactButton;
    [SerializeField] private Button interactAlternateButton;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button gamepad_InteractButton;
    [SerializeField] private Button gamepad_InteractAlternateButton;
    [SerializeField] private Button gamepad_PauseButton;
    [SerializeField] TextMeshProUGUI soundEffectsText;
    [SerializeField] TextMeshProUGUI musicText;
    [SerializeField] TextMeshProUGUI moveUPText;
    [SerializeField] TextMeshProUGUI moveDownText;
    [SerializeField] TextMeshProUGUI moveLeftText;
    [SerializeField] TextMeshProUGUI moveRightText;
    [SerializeField] TextMeshProUGUI interactText;
    [SerializeField] TextMeshProUGUI interactAlternateText;
    [SerializeField] TextMeshProUGUI pauseText;
    [SerializeField] TextMeshProUGUI gamepad_InteractText;
    [SerializeField] TextMeshProUGUI gamepad_InteractAlternateText;
    [SerializeField] TextMeshProUGUI gamepad_PauseText;
    [SerializeField] private Transform pressToRebindKeyUI;

    private Action onCloseButtonAction;

    private void Awake()
    {
        Instance = this;
        soundEffectsButton.onClick.AddListener(() =>
            {
                SoundManager.Instance.ChangeVolume();
                UpdateVisuals();

            });
        musicButton.onClick.AddListener(() =>
            {
                MusicManager.Instance.ChangeVolume();
                UpdateVisuals();
               
            });
        
        closeButton.onClick.AddListener(() =>
            {
                Hide();
                onCloseButtonAction();
            });

        moveUPButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInputs.Binding.Move_UP);
            
        });

        moveDownButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInputs.Binding.Move_Down);

        });
        moveRightButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInputs.Binding.Move_Right);

        });
        moveLeftButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInputs.Binding.Move_Left);

        });
        interactButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInputs.Binding.Interact);

        });
        interactAlternateButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInputs.Binding.InteractAlternate);

        });
        pauseButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInputs.Binding.Pause);

        });
        gamepad_InteractButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInputs.Binding.GamepadInteract);

        });
        gamepad_InteractAlternateButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInputs.Binding.Gamepad_InteractAlernate);

        });
        gamepad_PauseButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInputs.Binding.Gamepad_Pause);

        });
    }
    private void Start()
    {
        GameManager.Instance.OnGameUnpause += GameManager_OnGameUnpause;
        UpdateVisuals();
        Hide();
        HidePressToRebindKey();
    }

    private void GameManager_OnGameUnpause(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void UpdateVisuals()
    {
        soundEffectsText.text = "Sound Effects :" + Mathf.Round(SoundManager.Instance.GetVolume() * 10f);
        musicText.text = "Music :"+ Mathf.Round(MusicManager.Instance.GetVolume() * 10f);
        moveUPText.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.Move_UP);
        moveDownText.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.Move_Down);
        moveLeftText.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.Move_Left);
        moveRightText.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.Move_Right);
        interactText.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.Interact);
        interactAlternateText.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.InteractAlternate);
        pauseText.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.Pause);
        gamepad_InteractText.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.GamepadInteract);
        gamepad_InteractAlternateText.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.Gamepad_InteractAlernate);
        gamepad_PauseText.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.Gamepad_Pause);
    }

    public  void Show(Action onCloseButtonAction)
    {
        this.onCloseButtonAction = onCloseButtonAction;
        gameObject.SetActive(true);
        soundEffectsButton.Select();
    }

    public void Hide()
    {

        gameObject.SetActive(false);
    } 
    
    public  void ShowPressToRebindKey()
    {

        pressToRebindKeyUI.gameObject.SetActive(true);

    }

    public void HidePressToRebindKey()
    {

        pressToRebindKeyUI.gameObject.SetActive(false);
    }

    private void RebindBinding(GameInputs.Binding binding)
    {
        ShowPressToRebindKey();
        GameInputs.Instance.RebindBinding(binding, () =>
         {

             HidePressToRebindKey();
             UpdateVisuals();
         });

    }
}



