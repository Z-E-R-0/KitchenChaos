using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    public static DeliveryCounter Instance { get; private set; }
    // Start is called before the first frame update

    private void Awake()
    {
        Instance = this;
    }
    public override void Interact(Player player)
    {
        if(player.HasKitchenObjects())
        {
            if(player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
            {
                //Only accepts Plates
                DeliveryManager.Instance.DeliverRecipe(plateKitchenObject);
                player.GetKitchenObject().DestroySelf();

            }
           


        }
    }
}
