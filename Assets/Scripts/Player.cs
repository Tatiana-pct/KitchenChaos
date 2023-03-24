using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float _moveSpeed =10f;
    [SerializeField]private float _rotateSpeed =20f;

    private bool _isWalking;

    private void Update()
    {
        Vector2 inputVector = new Vector2(0, 0);
        //Touche Z
        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y = +1f;
            Debug.Log("Presing W!");
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1f;
            Debug.Log("Presing S!");
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1f;
            Debug.Log("Presing A!");
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = +1f;
            Debug.Log("Presing D!");
        }

        inputVector = inputVector.normalized;

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
