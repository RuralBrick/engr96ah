using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;

    Vector2 move;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed * move.y * Vector3.forward * Time.deltaTime);
        transform.Rotate(0, turnSpeed * move.x * Time.deltaTime, 0);
    }
}
