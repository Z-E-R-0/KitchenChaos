using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour,IkitchenObjectParent
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;
    private KitchenObjects kitchenObjects;
    
    // Start is called before the first frame update



    
    public void Interact(Player player)
   {
        if (kitchenObjects == null)
        {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
            kitchenObjectTransform.GetComponent<KitchenObjects>().SetKitchenObjectParent(this);
           
            

        }
        else
        {
            //GiveObjectToPlayer
            kitchenObjects.SetKitchenObjectParent(player);
           // Debug.Log(kitchenObjects.GetKitchenObjectParent());

        }

       

   }

    public Transform GetKitchenObjectFollowTransform()
    {

        return counterTopPoint;

    }

    public void SetkitchenObject(KitchenObjects kitchenObjects)
    {
        this.kitchenObjects = kitchenObjects;


    }
    public KitchenObjects GetKitchenObject()
    {

        return kitchenObjects;

    }

    public void ClearKitchenObjects()
    {

        kitchenObjects = null;

    }

    public bool hasKitchenObjects()
    {
        return kitchenObjects != null;

    }
}
