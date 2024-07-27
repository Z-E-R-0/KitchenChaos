using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounterVisual : MonoBehaviour
{
    private Animator _animator;
    private const string CUT = "Cut";
    [SerializeField] private CuttingCounter cuttingCounter;
    // Start is called before the first frame update
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }


    private void Start()
    {
        cuttingCounter.OnCut += CuttingCounter_OnCut;
    }

    private void CuttingCounter_OnCut(object sender,System.EventArgs e)
    {

        _animator.SetTrigger(CUT);
    }
}
