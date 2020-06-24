using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field_del_script : MonoBehaviour {
    float shiki_pos_x ;
	// Use this for initialization
	void Start () {
       // shiki_pos_x = shikiscript.Getpos();
	}
	
	// Update is called once per frame
	void Update () {
        shiki_pos_x = GameObject.FindGameObjectWithTag("shiki").GetComponent<Shiki_script>().Getpos();
        if (shiki_pos_x - transform.position.x > 300)
        {
            //Debug.Log("delete");
            Destroy(gameObject);
        }
    }
}
