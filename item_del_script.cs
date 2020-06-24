using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_del_script : MonoBehaviour
{
    public GameObject vanish;
    GameObject shiki,new_vanish,number_obj;
    public scorescript score_script;
    bool deth;
    // Use this for initialization
    void Start()
    { 
        shiki = GameObject.FindGameObjectWithTag("shiki");
        new_vanish = Instantiate(vanish, new Vector3(transform.position.x,transform.position.y,0), transform.rotation);
        score_script = GameObject.Find("number").GetComponent<scorescript>();
        deth = false;
    }

    // Update is called once per frame
    void Update()
    {
        float shiki_pos_x = shiki.GetComponent<Shiki_script>().Getpos();
        if (shiki_pos_x - transform.position.x > 300 && deth==false)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //float shiki_pos_x = shiki.GetComponent<Shiki_script>().Getpos();
        //Debug.Log("enter");
        if (collision.gameObject.tag == "shiki" && deth==false)
        {
           // Debug.Log("志希が100ポイントゲット");
            Destroy(gameObject);
            //Debug.Log("destroy");
            new_vanish.GetComponent<ParticleSystem>().Play();
            //Debug.Log("particle_start");
            score_script.Addscore(100);
            //Debug.Log("addscore");
            deth = true;
        }


    }
}
