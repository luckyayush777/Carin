using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackManager : MonoBehaviour
{
    public UnitBehaviour m_enemyTileAttackerInstance = null;
    [SerializeField]
    private UnitBehaviour m_playerTileAttackedInstance = null;
    private static int count = 0;
    public static int randomMatch = 0;

    private void Start()
    {
        StartCoroutine(ExecuteAfterTime(0.1f));
    }


    private void SetupRandomAttackerTileInstance()
    {
        randomMatch = Random.Range(0, BoardGenerator.boardWidth);
        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Tile"))
        {
            if(g.GetComponent<Tile>().allocatedToEnemy &&
                g.GetComponent<Tile>().boardCoordinates.yCoordinate == BoardGenerator.boardHeight / 2 )
            {
                ++count;
                if(count == randomMatch)
                {
                    if(g.GetComponent<UnitBehaviour>() != null)
                    {
                        Debug.Log("DOES HAVE THE SCRIPT ATTACHED!");
                        Debug.Log(count);
                    }
                    m_enemyTileAttackerInstance = g.GetComponent<UnitBehaviour>();
                }
            }
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        SetupRandomAttackerTileInstance();
    }

}
