using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HovercraftScript : MonoBehaviour
{
    public Transform player;

    [SerializeField] float acceleration;
    new Rigidbody rigidbody;

    bool attack = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                attack = true;
                break;
            case InputActionPhase.Canceled:
                attack = false;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (attack)
        {
            Vector3 direction = player.position - transform.position;
            rigidbody.AddForce(acceleration * direction.normalized);
        }
    }
}
