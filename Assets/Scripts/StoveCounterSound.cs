using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterSound : MonoBehaviour
{
    [SerializeField] private StoveCounter stoveCounter;
   private AudioSource AudioSource;
    private void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
    }

    private void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStateChangedEventArgs e)
    {
        bool playSound = e.states == StoveCounter.States.Frying ||e.states ==  StoveCounter.States.Fried;
        if (playSound)
        {
            AudioSource.Play();
        }
        else
        {
            AudioSource.Pause();
        }
    }

    
}
