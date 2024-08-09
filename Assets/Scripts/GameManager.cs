using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event EventHandler OnStateChanged;
    public static GameManager Instance { get; private set; }
    private enum State
    {
        WaitingToStart,
        CountdownToStart,
        GamePlaying,
        GameOver,



    }
    private State state;
    [SerializeField]private float waitingToStartTimer = 1f;
    [SerializeField] private float countdownToStartTimer = 3f;
     private float gamePlayingTimer;
    [SerializeField] private float gamePlayingTimerMax = 10f;
    private void Awake()
    {
        Instance = this;
        state = State.WaitingToStart;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.WaitingToStart:
                waitingToStartTimer -= Time.deltaTime;
                if (waitingToStartTimer < 0f)
                {
                    state = State.CountdownToStart;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
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
        Debug.Log(state);


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

}

