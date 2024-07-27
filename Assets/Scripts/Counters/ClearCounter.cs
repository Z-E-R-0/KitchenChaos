using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

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
        





}
