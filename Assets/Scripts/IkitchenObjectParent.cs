using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IkitchenObjectParent
{
    public Transform GetKitchenObjectFollowTransform();
    public void SetkitchenObject(KitchenObjects kitchenObjects);
    public KitchenObjects GetKitchenObject();
    public void ClearKitchenObjects();
    public bool hasKitchenObjects();
    
}
