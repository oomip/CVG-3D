using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement1 : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    //private float horizontalInput;
    //private float forwardInput;

    Vector2 moveDirection = Vector2.zero;
    public PlayerInputActions playerControls;
    private InputAction move;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
        transform.rotation = Quaternion.identity;

        // Get player input
        //horizontalInput = Input.GetAxis("HorizontalP1");
        //forwardInput = Input.GetAxis("VerticalP1");

        //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        //float xPos = Mathf.Clamp(transform.position.x, -0.25f, 3.25f);
        //float zPos = Mathf.Clamp(transform.position.z, -0.25f, 7.25f);
        //transform.position = new Vector3(xPos, transform.position.y, zPos);
    }

    private void FixedUpdate()
    {
        Vector3 moveTest = new Vector3(moveDirection.x * moveSpeed, 0.0f, moveDirection.y * moveSpeed);
        transform.Translate(moveTest * Time.deltaTime);
    }
}