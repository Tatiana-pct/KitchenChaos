using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{

    public event EventHandler OnPlayerGrabbedObject;

    [SerializeField] private KitchenObjectSO _kitchenObjectSO;


    #region Interact()
    public override void Interact(Player player)
    {
            Transform kitchenObjectTransform = Instantiate(_kitchenObjectSO._prefabs);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
    }

    #endregion

    
}


