using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostLevel2 : MonoBehaviour
{
    public Vector3 newSpawn;
    public Move player;
    public GameObject fallenTree1;
    public GameObject fallenTree2;
    public GameObject goondalf;
    // Start is called before the first frame update
    void Awake()
    {
        if(GameObject.Find("InventoryManager").GetComponent<KeyHolder>().previousScene == "Level 2")
        {
            player.startFalling = false;
            player.gameObject.transform.position = newSpawn;
            fallenTree1.SetActive(false);
            fallenTree2.SetActive(true);
            goondalf.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
