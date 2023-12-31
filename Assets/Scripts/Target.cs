using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Target : MonoBehaviour
{
    public float moveTargetSpeed = 5.0f;
    public PlayerInputActions playerControls;
    private InputAction moveTarget;
    Vector2 moveTargetDirection = Vector2.zero;

    public GameObject targetIndicator;
    private GameObject currIndicator;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        moveTarget = playerControls.Player.MoveTarget;
        moveTarget.Enable();
    }

    private void OnDisable()
    {
        moveTarget.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveTargetDirection = moveTarget.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector3 moveTest = new Vector3(-moveTargetDirection.x * moveTargetSpeed, 0.0f, -moveTargetDirection.y * moveTargetSpeed);
        transform.Translate(moveTest * Time.deltaTime);

        // Keeps the targeter within the bounds of the game board
        float xPos = Mathf.Clamp(transform.position.x, -0.25f, (float)Floor.boardWidth + -0.75f);
        float zPos = Mathf.Clamp(transform.position.z, -0.25f, (float)Floor.boardHeight + -0.75f);
        transform.position = new Vector3(xPos, transform.position.y, zPos);
    }
}
