using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RespawnPointManager : MonoBehaviour
{
    public static RespawnPointManager instance;
    public List<Transform> RespawnPoints;


    private void Awake() {
        if(instance == null)
        {
            instance = this;
        }
    }

    public Transform GetClosestRespawnPoint(Transform Player)
    {
        if(RespawnPoints.Count == 0)
        {
            return null;
        }
        Transform closestPoint = RespawnPoints[0];
        foreach(Transform t in RespawnPoints)
        {
            if(Vector2.Distance(closestPoint.position,Player.position)  > Vector2.Distance(t.position,Player.position))
            {
                closestPoint = t;
            }
        }
        return closestPoint;
    }
}
