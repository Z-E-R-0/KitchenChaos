using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStaticData : MonoBehaviour
{
    //Cleaning Up the Static Scripts
    private void Awake()
    {
        CuttingCounter.ResetStaticData();
        BaseCounter.ResetStaticData();
        TrashCounter.ResetStaticData();

    }
}
