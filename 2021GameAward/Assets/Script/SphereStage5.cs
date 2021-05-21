using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SphereStage5 : MonoBehaviour
{
    public float speed = 1.0f;
    public Rigidbody rb;
    public GameObject Item;
    public bool GetItem;
    public GameObject over;
    public GameObject normal;
    Vector3 addcutSize;
    Vector3 downaddcutSize;
    public bool hitflag;
    public bool changeSize;
    public GameObject lever;
    public GameObject leverblock;
    public GameObject valve;
    public GameObject valveblock;
    public GameObject valveblock2;
    public GameObject valve2;
    public GameObject valve2block;
    public GameObject lever2;
    public GameObject lever2block;
    public bool getValve;
    public bool getValve2;
    public bool leverON;
    public bool lever2ON;
    public GameObject button;
    public GameObject buttonblock;
    public GameObject button2;
    public GameObject button2block;
    public GameObject button3;
    public GameObject button3block;
    public GameObject button3block2;
    public GameObject button4;
    public GameObject button4block;
    public GameObject button5;
    public GameObject button5block;
    public bool getButton;
    public bool getButton2;
    public bool getButton3;
    public bool getButton4;
    public bool getButton5;

    public Slider changeGauge;
    public float Gauge;
    bool changeBig;
    PlayerItem playerItem;
    float keyTimelimit;

    public Camera pcamera;
    public static bool IsGoal = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        addcutSize = new Vector3(0.01f, 0.01f, 0);
        downaddcutSize = new Vector3(0.1f, 0.1f, 0);
        changeSize = false;
        getValve = false;
        getValve2 = false;
        GetItem = false;
        getButton = false;
        getButton2 = false;
        getButton3 = false;
        getButton4 = false;
        getButton5 = false;
        leverON = false;
        lever2ON = false;
        changeGauge.value = 1000;
        changeBig = true;
        //block2 = GameObject.FindGameObjectsWithTag("block2");
        playerItem = GetComponent<PlayerItem>();
        PlayerItem.GetItem = false;
        PlayerItem.DropItem = false;
        keyTimelimit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0f)
            return;

        float x = Input.GetAxis("Horizontal") * speed;
        rb.AddForce(x, 0, 0);
        //this.transform.rotation = Quaternion.Euler(0, 0, 0);

        if (Input.GetKey(KeyCode.Z) ||
            Input.GetKey("joystick button 0"))
        {
            changeSize = true;
            //if (changeGauge.value > 0)
            //{
            if (PlayerItem.GetItem)
            {
                keyTimelimit += Time.deltaTime;
                if (keyTimelimit > 0.5f)
                {
                    PlayerItem.DropItem = true;
                    keyTimelimit = 0;
                }
            }
            else if (normal.transform.localScale.x <= 2.6f && changeBig)
            {
                normal.transform.localScale = normal.transform.localScale + addcutSize;
                over.transform.localScale = over.transform.localScale + addcutSize;
                //changeGauge.value -= 0.01f;
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            changeSize = true;
            //if (changeGauge.value > 0)
            //{
            if (normal.transform.localScale.x <= 2.6f)
            {
                normal.transform.localScale = normal.transform.localScale + downaddcutSize;
                over.transform.localScale = over.transform.localScale + downaddcutSize;
                //changeGauge.value -= 0.1f;
            }
            //}
        }
        if (Input.GetKey(KeyCode.X) ||
           Input.GetKey("joystick button 1"))
        {
            //changeSize = false;
            if (PlayerItem.GetItem)
            {
                keyTimelimit += Time.deltaTime;
                if (keyTimelimit > 0.5f)
                {
                    PlayerItem.DropItem = true;
                    keyTimelimit = 0;
                }
            }
            else if (normal.transform.localScale.x >= 1.00f)
            {
                normal.transform.localScale = normal.transform.localScale - addcutSize;
                over.transform.localScale = over.transform.localScale - addcutSize;
                //changeGauge.value += 0.01f;
            }
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            //changeSize = false;
            if (normal.transform.localScale.x >= 1.00f)
            {
                normal.transform.localScale = normal.transform.localScale - downaddcutSize;
                over.transform.localScale = over.transform.localScale - downaddcutSize;
                //changeGauge.value += 0.1f;
            }
        }

        if (Input.GetKeyUp(KeyCode.Z) ||
            Input.GetKeyUp("joystick button 0") ||
            Input.GetKeyUp(KeyCode.X) ||
            Input.GetKeyUp("joystick button 1"))
        {
            keyTimelimit = 0;
        }

        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown("joystick button 6"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        //ゲージで大きさの指標をしている処理
        Gauge = normal.transform.localScale.x - 1.0f;
        changeGauge.value = (Gauge * 1000) / 1.6f;

        if (normal.transform.localScale.x == 1.0f)
        {
            changeSize = false;
        }

        //if(GetItem)
        //{
        //    Item.SetActive(false);
        //}

        //if(Input.GetKeyDown(KeyCode.C)&&GetItem)
        //{
        //    GetItem = false;
        //    Item.SetActive(true);
        //    Item.transform.position = this.transform.position;
        //}
        //if (normal.transform.localScale.x <= 1)
        //{
        //    hitflag = true;
        //}
        //else
        //{
        //    hitflag = false;
        //    GetItem = false;
        //}
        if (getValve)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
        if (getValve)
        {
            this.transform.position = valve.transform.position;
            if (Input.GetKey(KeyCode.D) && valve.transform.localPosition.y <= -3.5f)
            {
                valve.transform.localPosition += new Vector3(0, 0.004f, 0);
                valveblock.transform.localPosition += new Vector3(0, 0.004f, 0);
            }
            if (Input.GetKey(KeyCode.A) && valve.transform.localPosition.y >= -6.8f)
            {
                valve.transform.localPosition -= new Vector3(0, 0.004f, 0);
                valveblock.transform.localPosition -= new Vector3(0, 0.004f, 0);
            }
            if (valve.transform.localPosition.y >= -3.5f)
            {
                valveblock2.SetActive(false);
            }
            //if (Input.GetKey(KeyCode.D) && valve.transform.localPosition.y >= 0.7f || Input.GetKey("joystick button 8") && valve.transform.localPosition.y >= 0.7f)
            //{
            //    valve.transform.Rotate(0, 0, 0.1f);
            //    valve.transform.localPosition -= new Vector3(0, 0.004f, 0);
            //    valveblock.transform.localPosition -= new Vector3(0, 0.004f, 0);
            //}
            //if (Input.GetKey(KeyCode.A) && valve.transform.localPosition.y <= 10.5f || Input.GetKey("joystick button 9") && valve.transform.localPosition.y <= 10.5f)
            //{
            //    valve.transform.Rotate(0, 0, -0.1f);
            //    valve.transform.localPosition += new Vector3(0, 0.004f, 0);
            //    valveblock.transform.localPosition += new Vector3(0, 0.004f, 0);
            //}
        }
        if (getValve2)
        {
            this.transform.position = valve2.transform.position;
            if (Input.GetKey(KeyCode.D) && valve2.transform.localPosition.y >= 0.7f || Input.GetKey("joystick button 8") && valve2.transform.localPosition.y >= 0.7f)
            {
                valve2.transform.Rotate(0, 0, 0.1f);
                valve2.transform.localPosition -= new Vector3(0, 0.004f, 0);
                valveblock2.transform.localPosition -= new Vector3(0, 0.004f, 0);
            }
            if (Input.GetKey(KeyCode.A) && valve2.transform.localPosition.y <= 10.5f || Input.GetKey("joystick button 9") && valve2.transform.localPosition.y <= 9.6f)
            {
                valve2.transform.Rotate(0, 0, -0.1f);
                valve2.transform.localPosition += new Vector3(0, 0.004f, 0);
                valveblock2.transform.localPosition += new Vector3(0, 0.004f, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown("joystick button 3"))
        {
            getValve = false;
            getValve2 = false;
        }

        if (getValve || getValve2)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            pcamera.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, pcamera.transform.localPosition.z);

        }
        if (getButton)
        {
            if (buttonblock.transform.localPosition.y >= -3.16)
            {
                buttonblock.transform.localPosition -= new Vector3(0, 0.01f, 0);
            }
        }
        if (!getButton)
        {
            if (buttonblock.transform.localPosition.y <= 2.4f)
            {
                buttonblock.transform.localPosition += new Vector3(0, 0.005f, 0);
            }
        }
        if (getButton3)
        {
            if (PlayerItem.GetItem == true)
            {
                button3block2.SetActive(false);
            }
            if (button3block.transform.localPosition.y >= -2.87f)
            {
                button3block.transform.localPosition -= new Vector3(0, 0.01f, 0);
            }
        }
        if (!getButton3)
        {
            if(button3block.transform.localPosition.y <= -0.029f)
            {
                button3block.transform.localPosition += new Vector3(0, 0.005f, 0);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "button2")
        {
            getButton = false;
            button.transform.localPosition = new Vector3(0, 0, 10);
        }
        if(other.tag=="button3")
        {
            getButton3 = false;
            button3.transform.localPosition = new Vector3(0, 0, 10);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "Item"&&hitflag)
        //{
        //    GetItem = true;
        //}
        //if(other.tag=="DeadItem"&&!GetItem)
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //}
        if (other.tag == "button2")
        {
            getButton = true;
            button.transform.localPosition = new Vector3(0.5f,0, 10);
        }
        if(other.tag=="button")
        {
            getButton2 = true;
            button2.SetActive(false);
            button2block.SetActive(false);
        }
        if (other.tag == "button3")
        {
            getButton3 = true;
            button3.transform.localPosition = new Vector3(0.5f, 0, 10);
        }
        if (other.tag == "Goal" && PlayerItem.GetItem)
        {
            PlayerItem.GetItem = false;
            PlayerItem.DropItem = false;
            IsGoal = true;
            //SceneManager.LoadScene("EndingScene");
            FadeManager.Instance.LoadScene("EndingScene", 0.1f);
        }
        if (other.tag == "lever")
        {
            leverblock.SetActive(false);
            lever.transform.localRotation = new Quaternion(0, 0, -3.5f, 1);
            leverON = true;
        }

        if (other.tag == "lever2")
        {
            lever2block.SetActive(false);
            lever2.transform.localRotation = new Quaternion(0, 0, 3.5f, 1);
            lever2ON = true;
        }

        if (other.tag == "valve")
        {
            getValve = true;
        }
    }
}
