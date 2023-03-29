using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _rotateSpeed = 20f;
    [SerializeField] private float _playerRadius = 0.7f;
    [SerializeField] private float _playerheight = 2f;
    [SerializeField] private float _interactDistance = 2f;
    [SerializeField] private GameInput _gameInput;
    [SerializeField] private LayerMask _CountersLayerMask;


    private bool _isWalking;
    private Vector3 _lastInteractDir;

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

        if(moveDir != Vector3.zero)
        {
            _lastInteractDir = moveDir;
        }

        RaycastHit hit;

        if(Physics.Raycast(transform.position, moveDir,out hit, _interactDistance, _CountersLayerMask))
        {
            if(hit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                //Has ClearCounter
                clearCounter.Intreact();
            }

           //ClearCounter clearCounter = hit.transform.GetComponent<ClearCounter>();
           //if(clearCounter != null)
           //{
           //    // Has ClearCounter
           //}
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
}
