using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO _kitchenObjectSO;

    private ClearCounter _clearCounter;

    #region GetkitchenObjectSO()
    public KitchenObjectSO GetkitchenObjectSO()
    {
        return _kitchenObjectSO;
    }
    #endregion

    #region SetClearCounter()
    public void SetClearCounter( ClearCounter clearCounter)
    {
        if(this._clearCounter != null)
        {
            this._clearCounter.ClearKitchenObject();
        }

        this._clearCounter = clearCounter;

        if(_clearCounter.HasKitchenObject())
        {
            Debug.Log("Counter already has a KitchenObject!");
        }

        _clearCounter.SetKitchenObject(this);

        transform.parent = clearCounter.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }
    #endregion

    #region GetClearCounter()
    public ClearCounter GetClearCounter()
    {
        return _clearCounter;
    }
    #endregion

    #region
    #endregion
}
