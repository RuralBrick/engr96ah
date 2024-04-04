using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    bool movingFoward = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 move = context.ReadValue<Vector2>();
        movingFoward = move.y > 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingFoward)
        {
            Debug.Log("Forward");
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
    }
}
