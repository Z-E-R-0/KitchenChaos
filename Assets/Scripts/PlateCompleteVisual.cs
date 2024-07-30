using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlateCompleteVisual : MonoBehaviour
{

    // Start is called before the first frame update
    [Serializable]
    public struct kitchenObjectSO_Gameobject
    {
        public KitchenObjectSO KitchenObjectSO;
        public GameObject gameObject;

    }

    [SerializeField] private PlateKitchenObject plateKitchenObject;
    [SerializeField] private List<kitchenObjectSO_Gameobject> kitchenObjectSOGameobjectsList;
    private void Start()
    {
        plateKitchenObject.OnIngredientAdded += PlateKitchenObject_OnIngredientAdded;
        foreach (kitchenObjectSO_Gameobject kitchenObjectSOGameobject in kitchenObjectSOGameobjectsList)
        {



            kitchenObjectSOGameobject.gameObject.SetActive(false);



        }
    }

    private void PlateKitchenObject_OnIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e)
    {
        foreach (kitchenObjectSO_Gameobject kitchenObjectSOGameobject in kitchenObjectSOGameobjectsList)
        {
            if (kitchenObjectSOGameobject.KitchenObjectSO == e.kitchenObjectSO)
            {

                kitchenObjectSOGameobject.gameObject.SetActive(true);

            }

        }
        // / e.kitchenObjectSO
    }
}
