using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
    [SerializeField] float lookSpeed;

    Vector2 look;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnLook(InputAction.CallbackContext context)
    {
        look = context.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(lookSpeed * look.y * Time.deltaTime, 0, 0);
    }
}
