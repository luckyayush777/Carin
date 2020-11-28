using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardBehaviour : MonoBehaviour
{
    public static int xBoardCoordinate = 1;
    public static int yBoardCoordinate = 1;

    public List<Tile> listOfTiles = new List<Tile>();

    private void Start()
    {
        InitialiseListOfTiles();
        AllocateCoordinates();
    }

    private void Update()
    {
        if(AttackManager.unitDied)
        {
            BoardDisable();
        }
        else if(!AttackManager.unitDied)
        {
            BoardReset();
        }
    }

    private void InitialiseListOfTiles()
    {
        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Tile"))
        {
            listOfTiles.Add(g.GetComponent<Tile>());
        }
    }

    private void AllocateCoordinates()
    {
        foreach(Tile tile in listOfTiles)
        {
            if (xBoardCoordinate % BoardGenerator.boardHeight == 0)
                yBoardCoordinate++;
            tile.boardCoordinates.yCoordinate = yBoardCoordinate;
            tile.boardCoordinates.xCoordinate = xBoardCoordinate;
            xBoardCoordinate++;
            if (xBoardCoordinate == BoardGenerator.boardWidth)
                xBoardCoordinate = 0;
            
        }
    }

    private void BoardDisable()
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x = 0;
        tempScale.y = 0;
        tempScale.z = 0;
        transform.localScale = tempScale;

    }

    private void BoardReset()
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x = 1;
        tempScale.y = 1;
        tempScale.z = 1;
        transform.localScale = tempScale;
    }
   
}
