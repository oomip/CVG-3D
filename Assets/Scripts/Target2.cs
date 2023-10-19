using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Target2 : MonoBehaviour
{
    public float moveTargetSpeed2 = 5.0f;
    public PlayerInputActions2 playerControls2;
    private InputAction moveTarget2;
    Vector2 moveTargetDirection2 = Vector2.zero;

    public GameObject targetIndicator;
    private GameObject currIndicator;

    private void Awake()
    {
        playerControls2 = new PlayerInputActions2();
    }

    private void OnEnable()
    {
        moveTarget2 = playerControls2.Player.MoveTarget;
        moveTarget2.Enable();
    }

    private void OnDisable()
    {
        moveTarget2.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveTargetDirection2 = moveTarget2.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector3 moveTest = new Vector3(-moveTargetDirection2.x * moveTargetSpeed2, 0.0f, -moveTargetDirection2.y * moveTargetSpeed2);
        transform.Translate(moveTest * Time.deltaTime);

        // Keeps the targeter within the bounds of the game board
        float xPos = Mathf.Clamp(transform.position.x, -0.25f, (float)Floor.boardWidth + -0.75f);
        float zPos = Mathf.Clamp(transform.position.z, -0.25f, (float)Floor.boardHeight + -0.75f);
        transform.position = new Vector3(xPos, transform.position.y, zPos);
    }
}
