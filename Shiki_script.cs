using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shiki_script : MonoBehaviour
{
    // Use this for initialization  
    float time1, time2, playtime;
    private float Shiki_pos_x;
    Animator anim;
    bool is_grounded;// is_walking;
    bool two_jump,one_jump;
    float j_count;
    public GameObject gameover;
    public SceneController scene_cs;
    //public high_score highscore;
   //public scorescript score_script;
    float time;
    //public high_score highscorescript;
    [SerializeField]
    float force_walk, force_jump, ratio;


    void Start()
    {
        anim = GetComponent<Animator>();
        playtime = 0.0f;
        is_grounded = false;
        //is_walking = false;
        two_jump=false;
        Shiki_pos_x = GetComponent<Rigidbody2D>().transform.position.x;
        time = 0.0f;
        force_walk = 100;
        force_jump = 1000;
        ratio = 10;
    }

    public float Getpos()
    {
        Shiki_pos_x =transform.position.x;
        return Shiki_pos_x;

    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D shiki_rig = GetComponent<Rigidbody2D>();
        var is_touch = Input.touchCount;
        is_grounded = Physics2D.Linecast(shiki_rig.transform.position + transform.up, shiki_rig.transform.position - transform.up * 1.0f, 1 << 9);
        //Debug.DrawLine(shiki_rig.transform.position + transform.up, shiki_rig.transform.position - transform.up * 1.0f);
        //Debug.Log(is_grounded);
        //is_walking = shiki_rig.velocity.x > 0.0f ? true : false;
        if (is_grounded)
        {
            one_jump = false;
            two_jump = false;
        }
        if((one_jump || two_jump) &&shiki_rig.velocity.y < 0 && shiki_rig.gravityScale < 25)
        {
            shiki_rig.gravityScale *= 1.05f;
        }
        else
        {
            shiki_rig.gravityScale = 20;
        }

        /*if (is_walking || !is_grounded )
        {
            anim.SetBool("is_walk", true);
        }*/
        if(shiki_rig.velocity.x ==0 && shiki_rig.velocity.y == 0)
        {
        anim.SetBool("is_walk", false);
        }
        else
        {
            anim.SetBool("is_walk", true);
        }


        if (is_touch > 0)
        {
            Touch finger1 = Input.GetTouch(0);
            finger_task(finger1, shiki_rig);
            // Debug.Log("finger_task_finish");
            if (is_touch > 1)
            {
                Touch finger2 = Input.GetTouch(1);
                finger_task(finger2, shiki_rig);
                // Debug.Log("finger2_task_finish");
            }
        }
        if (transform.position.y < -150)
        {
            time += Time.deltaTime;
            shiki_rig.velocity = new Vector2(0,0);
            gameover.SetActive(true);
            int point = scorescript.ReturnScore();
 
            if (time > 2.0f)
            {
                time = 0.0f;
                high_score.Score_change(point);
                scene_cs.SHiki_drop();

            }
        }
    }

    public void finger_task(Touch finger, Rigidbody2D shiki_rig)
    {

        if (finger.phase == TouchPhase.Began)
        {
            if (finger.position.x < Screen.width/2 && (two_jump==false || one_jump==false))
            {
 
                j_count = 0.0f;
                shiki_rig.AddForce(Vector2.up * force_jump, ForceMode2D.Impulse);
                //is_jumping = true;
                // Debug.Log("jump" + force_jump);
            }
            else if (finger.position.x > Screen.width / 2 && finger.position.x < Screen.width)
            {
                shiki_rig.velocity = new Vector2(force_walk + (force_walk * (playtime / ratio)), shiki_rig.velocity.y);
            }
        }

        if (finger.phase == TouchPhase.Stationary || finger.phase == TouchPhase.Moved)
            {
            if (finger.position.x < Screen.width / 2 )
            {
                j_count += Time.deltaTime;
                if (j_count<0.1f &&( two_jump==false||one_jump==false)) {
                    shiki_rig.AddForce(Vector2.up * force_jump, ForceMode2D.Impulse);
                }
            }

            if (is_grounded && finger.position.x > Screen.width / 2 && finger.position.x < Screen.width) 
                {
                    shiki_rig.velocity = new Vector2(force_walk + (force_walk * (playtime / ratio)), shiki_rig.velocity.y);
                }
            }

        if (finger.phase == TouchPhase.Ended)
        {
            if (finger.position.x < Screen.width / 2)
            {
                if (one_jump == false && two_jump == false)
                {
                    one_jump = true;
                }
                else if(one_jump==true && two_jump == false)
                {
                    two_jump = true;
                }
                //Debug.Log(two_jump);

                //shiki_rig.AddForce(Vector2.up * force_jump, ForceMode2D.Impulse);
                // Debug.Log("jump" + force_jump);
            }
            else if (finger.position.x > Screen.width / 2 && finger.position.x < Screen.width)
            {
                shiki_rig.velocity = new Vector2(0.0f, shiki_rig.velocity.y);
            }

        }
    }
}






