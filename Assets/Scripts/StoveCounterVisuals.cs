using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterVisuals : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private StoveCounter stoveCounter;
    [SerializeField] private GameObject stoveOnGameObject;
    [SerializeField] private GameObject ParticleGameObject;


    private void Start()
    {
        stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
    }

    private void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStateChangedEventArgs e)
    {
        bool showVisual = e.states == StoveCounter.States.Frying || e.states == StoveCounter.States.Fried;
        stoveOnGameObject.SetActive(showVisual);
        ParticleGameObject.SetActive(showVisual);
    }
}
