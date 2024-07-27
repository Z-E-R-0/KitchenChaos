using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObjects : MonoBehaviour
{
    [SerializeField] KitchenObjectSO kitchenObjectSO;
    private IkitchenObjectParent kitchenObjectParent;
    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;



    }

    public void SetKitchenObjectParent(IkitchenObjectParent kitchenObjectParent)
    {
        if (this.kitchenObjectParent != null)
        {

            this.kitchenObjectParent.ClearKitchenObjects();

        }

        this.kitchenObjectParent = kitchenObjectParent;
        if(kitchenObjectParent.HasKitchenObjects())
        {
            Debug.LogError("Counter already has a Object");

        }
        kitchenObjectParent.SetkitchenObject(this);


        transform.parent = kitchenObjectParent.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;

    }
    public IkitchenObjectParent GetKitchenObjectParent()
    {
        return kitchenObjectParent;


    }
  
}
