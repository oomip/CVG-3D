using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private float horizontalInput;
    private float forwardInput;
    private float xRangeMin = -0.5f;
    private float zRangeMin = -0.5f;
    private float xRangeMax = 3.5f;
    private float zRangeMax = 7.5f;


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

        if (transform.position.x < xRangeMin)
        {
            transform.position = new Vector3(xRangeMin, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRangeMax)
        {
            transform.position = new Vector3(xRangeMax, transform.position.y, transform.position.z);
        }

        if (transform.position.z < zRangeMin)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeMin);
        }

        if (transform.position.z > xRangeMax)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeMax);
        }
    }
}