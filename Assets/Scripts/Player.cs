using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveSpeed = 10;
    private bool isWalking;
    [SerializeField]private GameInput gameInput;
    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        transform.position += moveDir*Time.deltaTime*moveSpeed;

        isWalking = moveDir != Vector3.zero;

        float rotateSpeed = 5;
        transform.forward = Vector3.Slerp(transform.forward,moveDir,Time.deltaTime* rotateSpeed);


    }

    public bool IsWalking()
    {
        return isWalking;
    }

}
