using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrashCounter : BaseCounter
{
    // Start is called before the first frame update
    public static event EventHandler OnAnyObjectTrashed;
     new public static void ResetStaticData()
    {
        OnAnyObjectTrashed = null;


    }
    public override void Interact(Player player)
    {
       if(player.HasKitchenObjects())
        {

            player.GetKitchenObject().DestroySelf();
            OnAnyObjectTrashed?.Invoke(this,EventArgs.Empty);

        }
    }
}
