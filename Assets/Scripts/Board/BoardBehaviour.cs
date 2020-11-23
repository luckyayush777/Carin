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
}
