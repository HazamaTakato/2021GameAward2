using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    PlayerItem playerItem;
    // Start is called before the first frame update
    void Start()
    {
        playerItem = GetComponent<PlayerItem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerItem.GetItem)
        {
            transform.Rotate(new Vector3(0, 0, -5));
        }
    }
}
