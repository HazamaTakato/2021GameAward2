using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyboarVolume : MonoBehaviour
{
    public Slider volume;

    // Start is called before the first frame update
    void Start()
    {
        volume.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PauseCursol.onSelect&&transform.name == "BGMSlider")
            volume.value += Input.GetAxisRaw("Horizontal") * 0.6f;
        else if(!PauseCursol.onSelect && transform.name == "SESlider")
            volume.value += Input.GetAxisRaw("Horizontal") * 0.6f;

        //volume.value += Input.GetAxisRaw("Vertical") * 0.6f;
    }
}
