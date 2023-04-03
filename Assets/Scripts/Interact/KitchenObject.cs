using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO _kitchenObjectSO;

    private IKitchenObjectParent _kitchenObjectParent;

    #region GetkitchenObjectSO()
    public KitchenObjectSO GetkitchenObjectSO()
    {
        return _kitchenObjectSO;
    }
    #endregion

    #region SetKitchenObjectParent()
    public void SetKitchenObjectParent( IKitchenObjectParent kitchenObjectParent)
    {
        if(this._kitchenObjectParent != null)
        {
            this._kitchenObjectParent.ClearKitchenObject();
        }

        this._kitchenObjectParent = kitchenObjectParent;

        if(_kitchenObjectParent.HasKitchenObject())
        {
            Debug.Log("IKitchenObjectParent already has a KitchenObject!");
        }

        _kitchenObjectParent.SetKitchenObject(this);

        transform.parent = kitchenObjectParent.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }
    #endregion

    #region GetKitchenObjectParent()
    public IKitchenObjectParent GetKitchenObjectParent()
    {
        return _kitchenObjectParent;
    }
    #endregion

    #region
    #endregion
}
