using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float turnSpeed;
    [SerializeField] float jumpPower;

    new Rigidbody rigidbody;

    Vector2 move;
    uint floorsTouched = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && floorsTouched > 0)
        {
            Vector3 explosionPosition = transform.position + Vector3.down;
            rigidbody.AddExplosionForce(jumpPower, explosionPosition, 100);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed * move.y * Vector3.forward * Time.deltaTime);
        if (!Mathf.Approximately(move.x, 0))
        {
            rigidbody.angularVelocity = Vector3.zero;
            transform.Rotate(0, turnSpeed * move.x * Time.deltaTime, 0);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
            floorsTouched++;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
            floorsTouched--;
    }
}
