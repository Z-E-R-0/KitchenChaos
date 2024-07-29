using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{
    [SerializeField] PlateKitchenObject plateKitchenObject;
    // Start is called before the first frame update
    public struct kitchenObjectSO_Gameobject
    {
        public KitchenObjectSO KitchenObjectSO;
        public GameObject GameObject;

    }
    private void Start()
    {
        //plateKitchenObject.OnIngredientAdded += PlateKitchenObject_OnIngredientAdded;
    }

    private void PlateKitchenObject_OnIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e)
    {
       // e.kitchenObjectSO
    }
}
