using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour, IkitchenObjectParent
{

    public static event EventHandler OnAnyObjectPlacedHere;
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
        if (kitchenObjects != null)
        {
            OnAnyObjectPlacedHere?.Invoke(this,EventArgs.Empty);
        }


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
