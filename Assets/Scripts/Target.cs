using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float speed = 5.0f;
    private bool forwardInput;
    private bool backwardInput;
    private bool rightInput;
    private bool leftInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetKeyDown(KeyCode.Y);
        backwardInput = Input.GetKeyDown(KeyCode.H);
        rightInput = Input.GetKeyDown(KeyCode.J);
        leftInput = Input.GetKeyDown(KeyCode.G);

        if (forwardInput) { transform.Translate(Vector3.forward * Time.deltaTime * speed); }
        if (backwardInput) { transform.Translate(Vector3.forward * Time.deltaTime * speed); }
        if (rightInput) { transform.Translate(Vector3.forward * Time.deltaTime * speed); }
        if (leftInput) { transform.Translate(Vector3.forward * Time.deltaTime * speed); }
    }
}
