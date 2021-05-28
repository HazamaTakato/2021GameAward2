using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public float RoteSpeed;
    public static bool GoalF;
    // Start is called before the first frame update
    void Start()
    {
        RoteSpeed = 8;
        GoalF = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(PlayerItem.GetItem||GoalF)
        {
            transform.Rotate(new Vector3(0, 0, RoteSpeed));
        }
    }
}
