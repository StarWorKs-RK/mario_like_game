using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fieldscript : MonoBehaviour {
    GameObject shiki;
    public GameObject field,item1;
    GameObject new_field;
    GameObject new_item1;
    int block_point_x,block_point_y,block_tenzyo_y;
    int item1_x;
    //int item1_y;
    bool is_dicided;
	// Use this for initialization
	void Start () {
        shiki = GameObject.FindGameObjectWithTag("shiki");
        block_point_x = 230;
        block_point_y = -30;
        item1_x = 230;
        //item1_y = 0;
        block_tenzyo_y = block_point_y+100;
        is_dicided = false;
        new_field = null;
        new_item1 = null;
        
	}
    //190+40+40
	
	// Update is called once per frame
	void Update () {
        Vector2 shiki_pos = shiki.GetComponent<Rigidbody2D>().transform.position ;
        int random0 = Random.Range(0, 2);
        int random1 = Random.Range(0,2);
        int ramdom2 = Random.Range(0, 2);
        int item1_cri = Random.Range(0,5);

        Random.Range(0, 4);//最終的にランダム範囲を1～50とかにして、5の倍数でitem1,50の倍数でitem2とかにする。
        //Debug.Log("block:" + block_point_x + " shiki:" + shiki_pos);
        //Debug.Log("random:" + random + "b-s:" + (block_point_x - shiki_pos.x));
        if (block_point_x - shiki_pos.x < 200 && block_point_x - shiki_pos.x>180)
        {
            if (!is_dicided && shiki_pos.x <500)
            {
               // Debug.Log("sakusei");
                new_field = Instantiate(field, new Vector3(block_point_x,block_point_y, 0), transform.rotation);
                if (random1 == 1)
                {
                    new_field = Instantiate(field, new Vector3(block_point_x, block_point_y + block_tenzyo_y, 0), transform.rotation);
                }
                if (ramdom2 == 1)
                {
                    new_field = Instantiate(field, new Vector3(block_point_x, block_point_y + block_tenzyo_y + block_tenzyo_y, 0), transform.rotation);
                }
                if(item1_cri == 4)
                {
                    int floar = Random.Range(0, 3);
                    new_item1 = Instantiate(item1,new Vector3(item1_x,block_point_y+15+block_tenzyo_y*floar,0),transform.rotation);
                    Debug.Log("sakusei");
                }
                //Debug.Log("sakusei");
                is_dicided = true;
                block_point_x += 40;
                item1_x += 40;
            }
            else if(!is_dicided && shiki_pos.x > 500 /*&& shiki_pos.x < 1000*/)
            {
                if (random0 == 1)
                {
                    new_field = Instantiate(field, new Vector3(block_point_x, block_point_y, 0), transform.rotation);
                }
                if (random1 == 1)
                {
                    new_field = Instantiate(field, new Vector3(block_point_x, block_point_y + block_tenzyo_y, 0), transform.rotation);
                }
                if (ramdom2 == 1)
                {
                    new_field = Instantiate(field, new Vector3(block_point_x, block_point_y + block_tenzyo_y + block_tenzyo_y, 0), transform.rotation);
                }
                if (item1_cri == 4)
                {
                    int floar = Random.Range(0, 3);
                    new_item1 = Instantiate(item1, new Vector3(item1_x, block_point_y + 15 + block_tenzyo_y * floar, 0), transform.rotation);
                    Debug.Log("sakusei");
                }
                //Debug.Log("sakusei");
                is_dicided = true;
                block_point_x += 40;
                item1_x += 40;
            }
            else 
            {
               // Debug.Log("else");
               // block_point += 40;
                is_dicided = false;
            }

        }

	}
}
