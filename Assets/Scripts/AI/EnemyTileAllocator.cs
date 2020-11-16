using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTileAllocator : MonoBehaviour
{
    [SerializeField]
    private List<SpriteRenderer> ListOfTiles = new List<SpriteRenderer>();
    [SerializeField]
    private Sprite enemyPrimitiveTileSprite = null;
    private List<UnitBehaviour> ListOfUnitBehaviours = new List<UnitBehaviour>();
    [SerializeField]
    private Sprite meleeUnitSpriteToCheckAgainst;
    [SerializeField]
    private Sprite rangedUnitSpriteToCheckAgainst;



    private List<Tile> UnitScripts = new List<Tile>();

    void Start()
    {
        InitialiseTileList();
        AllocateEnemyTiles();
        ChangeColourOfEnemyTiles();
        ChangeTileSpriteToRandomEnemySprite();
        AllocateIDsToTiles();
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
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Tile"))
        {
            ListOfUnitBehaviours.Add(g.GetComponent<UnitBehaviour>());
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
            ListOfTiles[i].sprite = FindObjectOfType<UnitSelector>().getRandomSpriteAndID().Item2;
        }
    }

    void AllocateIDsToTiles()
    {
        for (int i = 0; i < ListOfTiles.Count / 2; i++)
        {
            if(ListOfTiles[i].sprite == meleeUnitSpriteToCheckAgainst)
            {
                ListOfUnitBehaviours[i].m_unitID = 0;
                ListOfUnitBehaviours[i].m_unitName = "Melee";
            }else if(ListOfTiles[i].sprite == rangedUnitSpriteToCheckAgainst)
            {
                ListOfUnitBehaviours[i].m_unitID = 1;
                ListOfUnitBehaviours[i].m_unitName = "Ranged";
            }
        }
    }
}
