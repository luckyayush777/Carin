using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int m_tileID;
    private static int countOfTiles = 1;

    public Tile(int tileID)
    {
        this.m_tileID = tileID;
    }

    private void Start()
    {
        this.m_tileID = countOfTiles++;
    }
}
