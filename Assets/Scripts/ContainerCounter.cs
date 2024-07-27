using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    public event EventHandler OnPlayerGrabbedObject;

    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    // Start is called before the first frame update
    public override void Interact(Player player)
    {
        if(!player.HasKitchenObjects())
        {
            KitchenObjects.SpwanKitchenObject(kitchenObjectSO,player);
            //Player is not carrying Anything
            
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);


        }
    }

}
