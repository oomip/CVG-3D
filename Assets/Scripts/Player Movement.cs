using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private float horizontalInput;
    private float forwardInput;

    // Will make it custom fit to the board dimensions soon
    private float xRangeMin = -0.25f;
    private float zRangeMin = -0.25f;
    private float xRangeMax = 3.25f;
    private float zRangeMax = 7.25f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Get player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        float xPos = Mathf.Clamp(transform.position.x, -0.25f, 3.25f);
        float zPos = Mathf.Clamp(transform.position.z, -0.25f, 7.25f);
        transform.position = new Vector3(xPos, transform.position.y, zPos);
    }
}