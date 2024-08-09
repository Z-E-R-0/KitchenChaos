using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{
    [SerializeField]private Button mainMenuButton;
    [SerializeField]private Button resumeMenuButton;


    private void Awake()
    {
        resumeMenuButton.onClick.AddListener(() =>
        {
            GameManager.Instance.TogglePauseGame();

        });mainMenuButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MainMenu);

        });
    }
    private void Start()
    {
        GameManager.Instance.OnGamePause += GameManager_OnGamePause;
        GameManager.Instance.OnGameUnpause += GameManager_OnGameUnpause;
        Hide();
    }

    private void GameManager_OnGameUnpause(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void GameManager_OnGamePause(object sender, System.EventArgs e)
    {
        Show();
    }

    // Start is called before the first frame update
    void Show()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Hide()
    {
        gameObject.SetActive(false);
    }
}
