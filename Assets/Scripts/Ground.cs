using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    int boardLength = 8;
    int boardHeight = 10;
    // Start is called before the first frame update
    void Start()
    {
        public GameObject groundTile;
        List<(int, int)> gameBoard = new List<(int, int)>();
        for (int i = 0; i < boardLength; i++)
        {
            for (int j = 0; j < boardHeight; j++)
            {
                gameBoard.append((i, j));
                Instantiate(groundTile, new Vector3(i, 0, j), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
