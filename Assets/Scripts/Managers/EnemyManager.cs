using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject LevelEnd;
    public GameObject Bear, Bear1, Bear2;

    void Update()
    {
        if (!Bear.activeInHierarchy && !Bear1.activeInHierarchy && !Bear2.activeInHierarchy)
        {
            LevelEnd.SetActive(true);
        }
    }
}
