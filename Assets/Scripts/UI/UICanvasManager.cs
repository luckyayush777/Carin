using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICanvasManager : MonoBehaviour
{
    [SerializeField]
    private Canvas DefaultCanvas = null;
    [SerializeField]
    private Canvas TileEventCanvas = null;
    [SerializeField]
    private int CoolDownTime = 2;
    [SerializeField]
    private float timeSinceTileDeath = 0;
    [SerializeField]
    private TextMeshProUGUI EnemiesTileText = null;
    private static int countOfEnemyTiles = 0;
    private bool reducedCount = false;
    [SerializeField]
    private TextMeshProUGUI PlayerTileText = null;
    private static int countOfPlayerTiles = 0;



    private void Start()
    {
        TileEventCanvas.enabled = false;
        InitialiseEnemyAndPlayerCount();
        InitialiseEnemyAndPlayerCountText();
    }

    private void Update()
    {
        if (AttackManager.unitDied)
        {
            DefaultCanvas.enabled = false;
            TileEventCanvas.enabled = true;
            timeSinceTileDeath += Time.deltaTime;
            UpdateEnemyTileText();
        }
        if(timeSinceTileDeath >= CoolDownTime)
        {
            DefaultCanvas.enabled = true;
            TileEventCanvas.enabled = false;
            timeSinceTileDeath = 0;
            AttackManager.unitDied = false;
            reducedCount = false;
        }

    }

    private void InitialiseEnemyAndPlayerCount()
    {
        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Tile"))
        {
            if(g.GetComponent<Tile>().allocatedToEnemy)
            {
                countOfEnemyTiles++;
            }
            if(!g.GetComponent<Tile>().allocatedToEnemy)
            {
                countOfPlayerTiles++;
            }
        }
    }

    private void InitialiseEnemyAndPlayerCountText()
    {
        EnemiesTileText.text = "ENEMIES : " + countOfEnemyTiles.ToString();
        PlayerTileText.text = "PLAYER TILES : " + countOfPlayerTiles.ToString();
    }

    private void UpdateEnemyTileText()
    {
        if(reducedCount == false)
        countOfEnemyTiles--;
        reducedCount = true;
        EnemiesTileText.text = "ENEMIES : " + countOfEnemyTiles.ToString();
    }







}
