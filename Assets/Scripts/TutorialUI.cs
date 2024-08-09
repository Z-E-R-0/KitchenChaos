using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TutorialUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI keyMoveUp;
    [SerializeField] private TextMeshProUGUI keyMoveDown;
    [SerializeField] private TextMeshProUGUI keyMoveLeft;
    [SerializeField] private TextMeshProUGUI keyMoveRight;
    [SerializeField] private TextMeshProUGUI KeyInteract;
    [SerializeField] private TextMeshProUGUI KeyInteractAlternate;
    [SerializeField] private TextMeshProUGUI KeyPause;
    [SerializeField] private TextMeshProUGUI KeyGamePadMove;
    [SerializeField] private TextMeshProUGUI KeyGamepadInteract;
    [SerializeField] private TextMeshProUGUI KeyGamepadInteractAlternate;
    [SerializeField] private TextMeshProUGUI KeyGamepadPause;

    private void Start()
    {
        GameInputs.Instance.OnBindingRebind += GameInput_OnBindingRebind;
        GameInputs.Instance.OnInteractAction += GameInput_OnInteractAction;
        UpdateVisuals();
        Show();
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
       if(GameManager.Instance.IsCountDownToStartActive())
        {
            Hide();

        }
    }

    private void GameInput_OnBindingRebind(object sender, System.EventArgs e)
    {
        UpdateVisuals();
    }

    private void UpdateVisuals()
    {

        keyMoveUp.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.Move_UP);
        keyMoveDown.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.Move_Down);
        keyMoveLeft.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.Move_Left);
        keyMoveRight.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.Move_Right);
        KeyInteract.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.Interact);
        KeyInteractAlternate.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.InteractAlternate);
        KeyPause.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.Pause);
        KeyGamepadInteract.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.GamepadInteract);
        KeyGamepadInteractAlternate.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.Gamepad_InteractAlernate);
        KeyGamepadPause.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.Gamepad_Pause);
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
