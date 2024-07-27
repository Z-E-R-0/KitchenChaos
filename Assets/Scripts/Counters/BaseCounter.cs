using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour, IkitchenObjectParent
{

  
    [SerializeField] private Transform counterTopPoint;
    private KitchenObjects kitchenObjects;
    public virtual void Interact(Player player)
    {

        Debug.LogError("Base Counter Intracted");

    }public virtual void InteractAlternate(Player player)
    {

        Debug.LogError("Base Counter IntractedAlternate");

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

    public bool HasKitchenObjects()
    {
        return kitchenObjects != null;

    }
}
