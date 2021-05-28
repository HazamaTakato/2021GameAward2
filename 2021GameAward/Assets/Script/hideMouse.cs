using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class hideMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)&&
            Cursor.lockState!=CursorLockMode.Locked)
        {
            Onclick();
        }
    }
    void Onclick()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            return;
        }
    }
}
