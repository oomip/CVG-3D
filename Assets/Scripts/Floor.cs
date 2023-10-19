using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public static IDictionary<(int, int), GameObject> floor = new Dictionary<(int, int), GameObject>();

    public GameObject floorTile1;
    public GameObject floorTile2;

    public static int boardWidth = 8;
    public static int boardHeight = 12;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < boardWidth; i++)
        {
            for (int j = 0; j < boardHeight; j++)
            {
                bool isOffSet = (i + j) % 2 == 1;

                Vector3 tilePosition = new Vector3(i, 0, j);
                //floorTile.GetComponent<Material>().SetColor("_Color", isOffSet ? floorColor1 : floorColor2);
                GameObject currTile = Instantiate(isOffSet ? floorTile1 : floorTile2, tilePosition, Quaternion.identity);
                floor.Add((i, j), currTile);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
