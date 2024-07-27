using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO cutKitchenObjectSO;
    // Start is called before the first frame update
    public override void Interact(Player player)
    {
        if (!HasKitchenObjects())
        {
            //there is no kitchen object Here
            if (player.HasKitchenObjects())
            {
                //Player Carying Someting
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                //Player Not Carriying Anything 

            }
        }

        else
        {
            //there is a kitchen object Here
            if (player.HasKitchenObjects())
            {

                //player carrying somting 
            }
            else
            {
                //Player is not carrying anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }



        }
    }
    public override void InteractAlternate(Player player)
    {
        if(HasKitchenObjects())
        {
            //There is a KitchenObject Lets Cut it 
            GetKitchenObject().DestroySelf();
            KitchenObjects.SpwanKitchenObject(cutKitchenObjectSO, this);
            
        }
    }
}
