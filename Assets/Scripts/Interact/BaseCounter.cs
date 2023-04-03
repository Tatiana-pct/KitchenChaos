using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent
{

    [SerializeField] private Transform _counterTopPoint;


    private KitchenObject _kitchenObject;


    #region virtual void Interact(P)
    public virtual void Interact(Player player)
    {
        Debug.LogError("BaseCounter.INterac()");
    }
    #endregion

    #region GetKitchenObjectFollowTransform()
    public Transform GetKitchenObjectFollowTransform()
    {
        return _counterTopPoint;
    }
    #endregion

    #region SetKitchenObject()
    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this._kitchenObject = kitchenObject;
    }
    #endregion

    #region GetKitchenObject()
    public KitchenObject GetKitchenObject()
    {
        return _kitchenObject;
    }
    #endregion

    #region ClearKitchenObject()
    public void ClearKitchenObject()
    {
        _kitchenObject = null;
    }
    #endregion

    #region HasKitchenObject()
    public bool HasKitchenObject()
    {
        return _kitchenObject != null;
    }
    #endregion
}
