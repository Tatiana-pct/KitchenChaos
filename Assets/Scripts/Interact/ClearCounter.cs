using UnityEngine;
using UnityEngine.Rendering;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO _kitchenObjectSO;
    [SerializeField] private Transform _counterTopPoint;
    [SerializeField] private ClearCounter _secondClearCounter;
    [SerializeField] private bool _testing ;

    private KitchenObject _kitchenObject;

    private void Update()
    {
        if(_testing && Input.GetKeyDown(KeyCode.T))
        {
           if(_kitchenObject != null)
            {
                _kitchenObject.SetClearCounter(_secondClearCounter);
               
            }
        }
    }

    #region Intreact()
    public void Intreact()
    {
        if (_kitchenObject == null)
        {
            Transform kitchenObjectTransform = Instantiate(_kitchenObjectSO._prefabs, _counterTopPoint);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetClearCounter(this);
           
        }
        else
        {
            Debug.Log(_kitchenObject.GetClearCounter());
        }

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

#region
#endregion
