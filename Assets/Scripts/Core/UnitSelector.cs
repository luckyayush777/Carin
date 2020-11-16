using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public enum UnitType { 
    NO_UNIT = 0,
    MELEE = 1,
    RANGED = 2
}


public class UnitSelector : MonoBehaviour
{
    public Unit MeleeUnit;
    public GameObject MeleeUnitSpriteMini;
    public Unit RangedUnit;
    public GameObject RangedUnitSpriteMini;
    public static UnitType unitTypeInstantiated = UnitType.NO_UNIT;
    public Sprite MeleeTileSprite;
    public Sprite RangedTileSprite;
    private GameObject SpriteOnPointer = null;
    private GameObject spriteInUse;

    private void Start()
    {
        
    }

    private void Update()
    {
        if(TileBehaviour.clickedTile)
        {
            Destroy(spriteInUse);
        }
    }

    public void InitialiseMiniSprite(Unit unitType)
    {
        switch (unitType.m_UnitID)
        {
            case 0: //Instantiate(MeleeUnitSpriteMini, Vector3.zero, Quaternion.identity);
                SpriteOnPointer = MeleeUnitSpriteMini;
                unitTypeInstantiated = UnitType.MELEE;
                break;
            case 1: //Instantiate(RangedUnitSpriteMini,Vector3.zero, Quaternion.identity);
                SpriteOnPointer = RangedUnitSpriteMini;
                unitTypeInstantiated = UnitType.RANGED;
                break;
        }
        if (spriteInUse != null)
            Destroy(spriteInUse);
        spriteInUse = Instantiate(SpriteOnPointer, Vector3.zero, Quaternion.identity);
      
    }

    public Sprite getTypeOfSprite()
    {
        if (unitTypeInstantiated == UnitType.MELEE)
            return MeleeTileSprite;
        else if (unitTypeInstantiated == UnitType.RANGED)
            return RangedTileSprite;
        else return null;
    }

    public UnitType getUnitType()
    {
        return unitTypeInstantiated;
    }

    public Sprite getRandomSprite()
    {
        int randomNumber = Random.Range(0, (int)UnitType.RANGED);
        if (randomNumber == 0)
        {
            return MeleeTileSprite;
        }
        else if (randomNumber == 1)
        {
            return RangedTileSprite;
        }
        else
            return null;
    }

    public Tuple<int, Sprite> getRandomSpriteAndID()
    {
        int randomNumber = Random.Range(0, (int)UnitType.RANGED);
        if (randomNumber == 0)
        {
            return Tuple.Create(0, MeleeTileSprite);
        }
        else if (randomNumber == 1)
        {
            return Tuple.Create(1, RangedTileSprite);
        }
        else
            return null;
    }
}
