using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float turnSpeed;
    [SerializeField] float jumpPower;
    [SerializeField] float dashPower;
    [SerializeField] float dashTime;
    [SerializeField] float dashCooldown;

    new Rigidbody rigidbody;

    Vector2 move;
    uint floorsTouched = 0;
    bool dashing = false;
    bool dashCooling = false;

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

    public void OnDash(InputAction.CallbackContext context)
    {
        if (!dashing && !dashCooling)
        {
            dashing = true;
            Invoke("StopDash", dashTime);
        }
    }

    void StopDash()
    {
        dashCooling = true;
        dashing = false;
        Invoke("EnableDash", dashCooldown);
    }

    void EnableDash()
    {
        dashCooling = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 displacement = moveSpeed * move.y * Vector3.forward * Time.deltaTime;
        if (dashing)
            displacement *= dashPower;
        transform.Translate(displacement);
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
