using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    public GameObject targetIndicator;
    private GameObject currIndicator;
    private Vector3 indicatorPos = new Vector3(1, 0.25f, 1);

    public GameObject targetIndicator2;
    private GameObject currIndicator2;
    private Vector3 indicatorPos2 = new Vector3(6, 0.25f, 10);

    public float targetDelay = 3.0f;

    private bool rightTriggerActive = false;
    private bool targeterSummoned = false;
    private float nextTarget = 0.0f;

    private bool shiftKeyActive = false;
    private bool targeterSummoned2 = false;
    private float nextTarget2 = 0.0f;

    public PlayerInputActions playerControls;
    public PlayerInputActions2 playerControls2;
    private InputAction target;
    private InputAction target2;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
        playerControls2 = new PlayerInputActions2();
    }

    private void OnEnable()
    {
        target = playerControls.Player.Target;
        target.Enable();

        target2 = playerControls2.Player.Target;
        target2.Enable();
    }

    private void OnDisable()
    {
        target.Disable();
        target2.Disable();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rightTriggerActive = target.IsPressed();
        shiftKeyActive = target2.IsPressed();

        // PLAYER 1 TARGETER
        // When the right trigger is first pressed, summons targeting indiactor
        if (!targeterSummoned && rightTriggerActive && Time.time > nextTarget)
        {
            currIndicator = Instantiate(targetIndicator, indicatorPos, Quaternion.identity);
            targeterSummoned = true;
        }

        // Once the right trigger is released, deletes the nearest tile below
        if (!rightTriggerActive && targeterSummoned)
        {
            indicatorPos = currIndicator.GetComponent<Transform>().position;
            int i = (int)Mathf.Round(indicatorPos.x);
            int j = (int)Mathf.Round(indicatorPos.z);

            GameObject selectedTile = Floor.floor[(i, j)];
            if (selectedTile != null)
            {
                Destroy(selectedTile);
                nextTarget = Time.time + targetDelay;
            }

            Destroy(currIndicator);
            targeterSummoned = false;
        }

        // PLAYER 2 TARGETER
        if (!targeterSummoned2 && shiftKeyActive && Time.time > nextTarget2)
        {
            currIndicator2 = Instantiate(targetIndicator2, indicatorPos2, Quaternion.identity);
            targeterSummoned2 = true;
        }

        // Once the right trigger is released, deletes the nearest tile below
        if (!shiftKeyActive && targeterSummoned2)
        {
            indicatorPos2 = currIndicator2.GetComponent<Transform>().position;
            int i2 = (int)Mathf.Round(indicatorPos2.x);
            int j2 = (int)Mathf.Round(indicatorPos2.z);

            GameObject selectedTile2 = Floor.floor[(i2, j2)];
            if (selectedTile2 != null)
            {
                Destroy(selectedTile2);
                nextTarget2 = Time.time + targetDelay;
            }

            Destroy(currIndicator2);
            targeterSummoned2 = false;
        }


        // Initial tile destruction test code
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    GameObject selectedTile = Floor.floor[(1, 1)];
        //    Destroy(selectedTile);
        //}

        // Summon the targeting indicator
        //if (Input.GetKeyDown(KeyCode.K) && currIndicator == null)
        //{
        //    currIndicator = Instantiate(targetIndicator, new Vector3(1, 0.25f, 1), Quaternion.identity);
        //    keyPressed = true;
        //}

        //if (keyPressed)
        //{
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Vector3 currPosition = currIndicator.GetComponent<Transform>().position;
        //    int i = (int)Mathf.Round(currPosition.x);
        //    int j = (int)Mathf.Round(currPosition.z);

        //    GameObject selectedTile = Floor.floor[(i, j)];
        //    if (selectedTile != null)
        //    {
        //        Destroy(selectedTile);
        //        Destroy(currIndicator);
        //        keyPressed = false;
        //    }
        //}
        //}

        //if (Input.GetKeyUp(KeyCode.K))
        //{
        //    keyPressed = false;
        //    Destroy(currIndicator);
        //}


        // Find and destroy the nearest tile in the grid
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Vector3 currPosition = currIndicator.GetComponent<Transform>().position;
        //    int i = (int)Mathf.Round(currPosition.x);
        //    int j = (int)Mathf.Round(currPosition.z);

        //    GameObject selectedTile = Floor.floor[(i, j)];
        //    Destroy(selectedTile);
        //}

        // Remove the targeting indicator from the scene.
        //if (Input.GetKeyDown(KeyCode.L) && currIndicator != null)
        //{
        //    Destroy(currIndicator);
        //}
    }
}