using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameboard : MonoBehaviour
{
    public Transform[,] gBPoints = new Transform[27, 30];
    private GameObject turningPoints;

    // Start is called before the first frame update
    void Start()
    {
        turningPoints = GameObject.Find("TurningPoints");
        foreach(Transform point in turningPoints.transform)
        {
            Vector2 pos = point.position;
            gBPoints[(int)pos.x, (int)pos.y] = point;
        }
    }
}
