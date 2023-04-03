using System;
using UnityEngine;

public class Player : MonoBehaviour, IKitchenObjectParent
{
    //private static Player instance;
   //public static Player Instance
   //{
   //    get { return instance; }
   //    set { instance = value; }
   //}

    public  static Player Instance { get; private set ; }

    

    public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;
    public class OnSelectedCounterChangedEventArgs : EventArgs
    {
        public BaseCounter _selectedCounter;
    }


    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _rotateSpeed = 20f;
    [SerializeField] private float _playerRadius = 0.7f;
    [SerializeField] private float _playerheight = 2f;
    [SerializeField] private float _interactDistance = 2f;
    [SerializeField] private GameInput _gameInput;
    [SerializeField] private LayerMask _CountersLayerMask;
    [SerializeField] private Transform _kitchenObjectHoldPoint;


    private bool _isWalking;
    private Vector3 _lastInteractDir;
    private BaseCounter _selectedCounter;
    private KitchenObject _kitchenObject;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("There is more than one player instance");
        }
        Instance = this;
    }

    private void Start()
    {
        _gameInput.OnInteractAction += _gameInput_OnInteractAction;
    }

    private void _gameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        if (_selectedCounter != null)
        {
            _selectedCounter.Interact(this);
        }


    }

    private void Update()
    {
        HandleMouvement();
        HandleInteractions();

    }


    #region IsWalking()
    public bool IsWalking()
    {
        return _isWalking;
    }
    #endregion

    #region HandleInteractions()
    private void HandleInteractions()
    {
        Vector2 inputVector = _gameInput.GetMouvementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        if (moveDir != Vector3.zero)
        {
            _lastInteractDir = moveDir;
        }

        RaycastHit hit;

        if (Physics.Raycast(transform.position, moveDir, out hit, _interactDistance, _CountersLayerMask))
        {
            if (hit.transform.TryGetComponent(out BaseCounter baseCounter))
            {
                //Has ClearCounter
                if (baseCounter != _selectedCounter)
                {
                    SetSelectedCounter(baseCounter);
                }
            }
            else
            {
                SetSelectedCounter(null);
            }

        }
        else
        {
            SetSelectedCounter(null);
        }
    }

    #endregion

    #region HandleMouvement()
    private void HandleMouvement()
    {

        Vector2 inputVector = _gameInput.GetMouvementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        float _moveDistance = _moveSpeed * Time.deltaTime;

        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * _playerheight, _playerRadius, moveDir, _moveDistance);

        if (!canMove)
        {
            //Cannot move toward moveDir

            //Attemp only X mvt
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * _playerheight, _playerRadius, moveDirX, _moveDistance);

            if (canMove)
            {
                //Can only on the X
                moveDir = moveDirX;
            }
            else
            {
                //Cannot move only the X

                //Attemp only Z mvt
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * _playerheight, _playerRadius, moveDirZ, _moveDistance);

                if (canMove)
                {
                    moveDir = moveDirZ;
                }
                else
                {
                    //Cannot move in any direction
                }

            }
        }

        if (canMove)
        {
            transform.position += moveDir * _moveSpeed * Time.deltaTime;

        }


        _isWalking = moveDir != Vector3.zero;

        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * _rotateSpeed);
    }
    #endregion

    #region SetSelectedCounter()
    private void SetSelectedCounter(BaseCounter selectedCounter)
    {
        this._selectedCounter = selectedCounter;

        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs
        {
            _selectedCounter = _selectedCounter,
        });
    }
    #endregion

    #region GetKitchenObjectFollowTransform() Interface
    public Transform GetKitchenObjectFollowTransform()
    {
        return _kitchenObjectHoldPoint;
    }
    #endregion

    #region SetKitchenObject() Interface
    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this._kitchenObject = kitchenObject; 
    }
    #endregion

    #region GetKitchenObject() Interface
    public KitchenObject GetKitchenObject()
    {
        return _kitchenObject;
    }
    #endregion

    #region ClearKitchenObject() Interface
    public void ClearKitchenObject()
    {
        _kitchenObject = null;
    }
    #endregion

    #region HasKitchenObject() Interface
    public bool HasKitchenObject()
    {
        return _kitchenObject != null;
    }
    #endregion


}
