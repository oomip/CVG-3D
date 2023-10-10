using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject targetIndicator;
    private GameObject currIndicator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject selectedTile = SpawnFloor.floor[(1, 1)];
            Destroy(selectedTile);
        }

        if (Input.GetKeyDown(KeyCode.K) && currIndicator == null)
        {
            currIndicator = Instantiate(targetIndicator, new Vector3(1, 0.25f, 1), Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.O) && currIndicator != null)
        {
            Vector3 currPosition = currIndicator.GetComponent<Transform>().position;
            int i = (int)Mathf.Round(currPosition.x);
            int j = (int)Mathf.Round(currPosition.z);

            GameObject selectedTile = SpawnFloor.floor[(i, j)];
            Destroy(selectedTile);
        }

        if (Input.GetKeyDown(KeyCode.L) && currIndicator != null)
        {
            Destroy(currIndicator);
        }
    }
}