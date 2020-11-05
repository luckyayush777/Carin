using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator: MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject TilePrimitive;
    public GameObject Board;
    [SerializeField]
    private Vector2 firstTilePosition = Vector2.zero;
    [SerializeField]
    private float xOffset;
    [SerializeField]
    private float xOffsetIncrease = 0;
    [SerializeField]
    private float yOffset;
    [SerializeField]
    private float yOffsetIncrease = 0;

    private float spawnXPos;
    private float spawnYPos;
    private int boardHeight = 8;
    private int boardWidth = 8;
    




    void Start()
    {
        SetupBoard(boardHeight, boardWidth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetupBoard(int width , int height)
    {
        for (int i = 0; i < height; i++)
        {
            yOffset += yOffsetIncrease;
            spawnYPos = firstTilePosition.y - yOffset;
            xOffset = 0;
            for (int j = 0; j < width; j++)
            {
                xOffset += xOffsetIncrease;
                spawnXPos = firstTilePosition.x + xOffset;
                Instantiate(TilePrimitive, new Vector3(spawnXPos, spawnYPos,
                    0.0f), Quaternion.identity, Board.transform);

            }
            
        }
    }
}
