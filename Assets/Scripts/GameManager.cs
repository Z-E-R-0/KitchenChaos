using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event EventHandler OnStateChanged;
    public event EventHandler OnGamePause;
    public event EventHandler OnGameUnpause;
    public static GameManager Instance { get; private set; }

    private enum State
    {
        WaitingToStart,
        CountdownToStart,
        GamePlaying,
        GameOver,



    }
    private State state;
   
    [SerializeField] private float countdownToStartTimer = 3f;
     private float gamePlayingTimer;
    [SerializeField] private float gamePlayingTimerMax = 10f;
    private bool isGamePaused = false;
    private void Awake()
    {
        Instance = this;
        state = State.WaitingToStart;
    }
    // Start is called before the first frame update
    void Start()
    {
        GameInputs.Instance.OnGamePaused += GameInput_OnGamePaused;
        GameInputs.Instance.OnInteractAction += GameInput_OnInteractAction;
    }

    private void GameInput_OnInteractAction(object sender, EventArgs e)
    {
        if (state == State.WaitingToStart)
        {
            state = State.CountdownToStart;
            OnStateChanged?.Invoke(this, EventArgs.Empty);  
        }
    }

    private void GameInput_OnGamePaused(object sender, EventArgs e)
    {
        TogglePauseGame();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.WaitingToStart:
               
                break;

            case State.CountdownToStart:
                countdownToStartTimer -= Time.deltaTime;
                if (countdownToStartTimer < 0f)
                {
                    state = State.GamePlaying;
                    gamePlayingTimer = gamePlayingTimerMax;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);

                }
                break;
            case State.GamePlaying:
                gamePlayingTimer -= Time.deltaTime;
                if (gamePlayingTimer < 0f)
                {
                    state = State.GameOver;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);

                }
                break;
            case State.GameOver:

                break;
        }
       


    }

    public bool IsGamePlaying()
    {
        return state == State.GamePlaying;

    }
    public bool IsCountDownToStartActive()
    {
        return state == State.CountdownToStart;

    }

    public float GetCountdownToStartTimer()
    {
        return countdownToStartTimer;


    } public float GetGamePlayingTimerNormalized()
    {
        return 1 -(gamePlayingTimer / gamePlayingTimerMax);


    }
    public bool IsGameOver()
    {
        return state == State.GameOver;

    }
    public  void TogglePauseGame()
    {
        isGamePaused = !isGamePaused;
        if(isGamePaused)
        {
            OnGamePause?.Invoke(this, EventArgs.Empty);
            Time.timeScale = 0f;

        }
        else
        {
            OnGameUnpause?.Invoke(this, EventArgs.Empty);
            Time.timeScale = 1f;
        }
        

    }

}

