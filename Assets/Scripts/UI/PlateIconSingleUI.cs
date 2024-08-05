using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlateIconSingleUI : MonoBehaviour
{
    [SerializeField] private Image image; 
    // Start is called before the first frame update
   public void SetKitchenObjectSO(KitchenObjectSO kitchenObjectSO)
    {

        image.sprite = kitchenObjectSO.sprite;

    }
}
