using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputAction _playerInputActions;
     
    private void Awake()
    {
        _playerInputActions = new PlayerInputAction();
        _playerInputActions.Player.Enable();
    }

    public Vector2 GetMouvementVectorNormalized()
    {
        Vector2 inputVector = _playerInputActions.Player.Move.ReadValue<Vector2>();



        ////Touche Z
        //if (Input.GetKey(KeyCode.W))
        //{
        //    inputVector.y = +1f;
        //    Debug.Log("Presing W!");
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    inputVector.y = -1f;
        //    Debug.Log("Presing S!");
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    inputVector.x = -1f;
        //    Debug.Log("Presing A!");
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    inputVector.x = +1f;
        //    Debug.Log("Presing D!");
        //}

        inputVector = inputVector.normalized;
        return inputVector;
    }
}
