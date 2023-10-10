using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float speed = 5.0f;
    private float horizontalInput;
    private float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal2");
        verticalInput = Input.GetAxis("Vertical2");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);


        //forwardInput = Input.GetKeyDown(KeyCode.Y);
        //backwardInput = Input.GetKeyDown(KeyCode.H);
        //rightInput = Input.GetKeyDown(KeyCode.J);
        //leftInput = Input.GetKeyDown(KeyCode.G);

        //if (forwardInput) { transform.Translate(Vector3.forward * Time.deltaTime * speed); }
        //if (backwardInput) { transform.Translate(Vector3.forward * Time.deltaTime * speed); }
        //if (rightInput) { transform.Translate(Vector3.forward * Time.deltaTime * speed); }
        //if (leftInput) { transform.Translate(Vector3.forward * Time.deltaTime * speed); }
    }
}
