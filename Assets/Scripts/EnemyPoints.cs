using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoints : MonoBehaviour
{
    [SerializeField] int points;

    public int GetPoints()
    {
        return points;
    }
}
