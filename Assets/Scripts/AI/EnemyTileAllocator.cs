using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTileAllocator : MonoBehaviour
{
    [SerializeField]
    private List<SpriteRenderer> ListOfTiles = new List<SpriteRenderer>();
    [SerializeField]
    private Sprite enemyPrimitiveTileSprite = null;

    private List<Tile> UnitScripts = new List<Tile>();

    void Start()
    {
        InitialiseTileList();
        Debug.Log(ListOfTiles.Count);
        AllocateEnemyTiles();
        ChangeColourOfEnemyTiles();
        ChangeTileSpriteToRandomEnemySprite();
    }
    private void Awake()
    {
        
    }
    void Update()
    {
       
    }
    void InitialiseTileList()
    {
        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Tile"))
        {
            ListOfTiles.Add(g.GetComponent<SpriteRenderer>());
        }
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Tile"))
        {
            UnitScripts.Add(g.GetComponent<Tile>());
        }

    }
    void ChangeColourOfEnemyTiles()
    {
        for(int i = 0; i < ListOfTiles.Count / 2; i++)
        {
            ListOfTiles[i].sprite = enemyPrimitiveTileSprite;
            ListOfTiles[i].color = Color.red;
        }
    }

    void AllocateEnemyTiles()
    {
        for (int i = 0; i < UnitScripts.Count / 2; i++)
        {
            UnitScripts[i].allocatedToEnemy = true;
        }
    }

    void ChangeTileSpriteToRandomEnemySprite()
    {
        for (int i = 0; i < ListOfTiles.Count / 2; i++)
        {
            ListOfTiles[i].sprite = FindObjectOfType<UnitSelector>().getRandomSprite();
        }
    }
}
