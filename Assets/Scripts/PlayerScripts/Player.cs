using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float _moveSpeed =10f;
    [SerializeField]private float _rotateSpeed =20f;
    [SerializeField] private GameInput _gameInput;

    private bool _isWalking;

    private void Update()
    {
       
        Vector2 inputVector = _gameInput.GetMouvementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        transform.position += moveDir * _moveSpeed * Time.deltaTime;

        _isWalking = moveDir != Vector3.zero;

        transform.forward =  Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * _rotateSpeed);

    }

    public bool IsWalking()
    {
        return _isWalking;
    }
}
