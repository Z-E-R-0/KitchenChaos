using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu()]
public class BurningRecipeSO : ScriptableObject
{

    // Start is called before the first frame update
    public KitchenObjectSO input;
    public KitchenObjectSO output;
    public float BurningingTimerMax;
}
