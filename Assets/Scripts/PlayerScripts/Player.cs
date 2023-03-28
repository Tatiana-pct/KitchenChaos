using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _rotateSpeed = 20f;
    [SerializeField] private float _playerRadius = 0.7f;
    [SerializeField] private float _playerheight = 2f;
    [SerializeField] private GameInput _gameInput;


    private bool _isWalking;

    private void Update()
    {

        Vector2 inputVector = _gameInput.GetMouvementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        float _moveDistance = _moveSpeed * Time.deltaTime;

        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * _playerheight, _playerRadius, moveDir, _moveDistance);

        if(!canMove)
        {
            //Cannot move toward moveDir

            //Attemp only X mvt
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * _playerheight, _playerRadius, moveDirX, _moveDistance);

            if(canMove)
            {
                //Can only on the X
                moveDir = moveDirX;
            }
            else
            {
                //Cannot move only the X

                //Attemp only Z mvt
                Vector3 moveDirZ = new Vector3(0,0,moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * _playerheight, _playerRadius, moveDirZ, _moveDistance);
                
                if(canMove)
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

    public bool IsWalking()
    {
        return _isWalking;
    }
}
