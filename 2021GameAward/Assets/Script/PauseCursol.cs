using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Selecting
{
    BGM,
    SE,
}

public class PauseCursol : MonoBehaviour
{
    public GameObject parentPos;
    float onInput;
    float onKeyboardInput;
    Selecting select;
    public static bool onSelect;


    // Start is called before the first frame update
    void Start()
    {
        select = Selecting.BGM;
        parentPos.GetComponent<GameObject>();
        onSelect = true;
    }

    // Update is called once per frame
    void Update()
    {
        onInput = Input.GetAxis("right");
        onKeyboardInput = Input.GetAxis("Vertical");

        if (onInput > 0.1f&&!onSelect||Input.GetKeyDown(KeyCode.W)&&!onSelect)
        {
            select = Selecting.BGM;
            onSelect = true;
        }
        else if (onInput < -0.1f&& onSelect||Input.GetKeyDown(KeyCode.S) && onSelect)
        {
            select = Selecting.SE;
            onSelect = false;
        }

        if (select == Selecting.BGM)
        {
            this.transform.position = new Vector3(parentPos.transform.position.x - 0,
                                                  parentPos.transform.position.y - 0);
        }
        else
        {
            this.transform.position = new Vector3(parentPos.transform.position.x - 0,
                                                  parentPos.transform.position.y - 70);
        }
    }
}
