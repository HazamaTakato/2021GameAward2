using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemStage2 : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Item;
    GameObject NormalPlayer;
    GameObject OverPlayer;

    Rigidbody ItemRigid;
    Rigidbody PlayerRigid;

    public Vector3 MyScale;
    Vector2 MyPosition;
    Vector2 ItemdropPosition;

    SphereStage2 player;

    public static bool GetItem = false;
    public static bool DropItem = false;

    // Start is called before the first frame update
    void Start()
    {
        Item = GameObject.Find("Item");
        NormalPlayer = GameObject.Find("normalPlayer");
        OverPlayer = GameObject.Find("OverPlayer");

        player = GetComponent<SphereStage2>();

        ItemRigid = Item.GetComponent<Rigidbody>();
        PlayerRigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MyPosition = NormalPlayer.transform.position;
        MyScale = NormalPlayer.transform.localScale;

        ItemdropPosition = new Vector3(MyPosition.x + 1.5f, MyPosition.y + 1, 0);

        if (GetItem)
        {
            Item.transform.position = new Vector3(MyPosition.x, MyPosition.y, -7);
            if (DropItem)
            {
                Item.transform.position = new Vector3(
                    Item.transform.position.x + (MyScale.x * (PlayerRigid.velocity.x > 0.0000001f ? -1 : 1)),
                    Item.transform.position.y + MyScale.y / 3, 0);
                ItemRigid.velocity = -PlayerRigid.velocity / 5;
                GetItem = false;
                DropItem = false;
            }
        }
        //if (player.GetItem)
        //{
        //    Item.transform.position = new Vector3(MyPosition.x, MyPosition.y, -7);
        //    if (DropItem)
        //    {
        //        Item.transform.position = new Vector3(
        //            Item.transform.position.x + (MyScale.x * (PlayerRigid.velocity.x > 0.0000001f ? -1 : 1)),
        //            Item.transform.position.y + MyScale.y / 3, 0);
        //        ItemRigid.velocity = -PlayerRigid.velocity / 5;
        //        player.GetItem = false;
        //        GetItem = false;
        //        DropItem = false;
        //    }
        //}
    }
    private void OnCollisionStay(Collision other)
    {
        if (GetItem)
            return;
        //if (player.GetItem)
        //    return;
        if (other.gameObject == Item)
        {
            //Debug.Log("アイテムに当たった");
            if (MyScale.x / 1.7f >= Item.transform.localScale.x && !GetItem)
            {
                //player.GetItem = true;
                GetItem = true;
                MyScale = new Vector3(Item.transform.localScale.x + 0.8f, Item.transform.localScale.y + 0.8f, 1);
                NormalPlayer.transform.localScale = MyScale;
                OverPlayer.transform.localScale = new Vector3(MyScale.x + 0.1f, MyScale.y + 0.1f, MyScale.z);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "Goal" && GetItem)
        //{
        //    Debug.Log("ゴールに当たった");
        //    SceneManager.LoadScene("GameScene3");
        //}
    }
}
