using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    // Start is called before the first frame update
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
