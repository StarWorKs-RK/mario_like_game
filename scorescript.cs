using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scorescript : MonoBehaviour {
    public static int score_number;
    private int now_score;
    public GameObject Score_text;
    Text number;
    public Shiki_script shikiscript;
	// Use this for initialization
	void Start () {
        score_number = 0;
        now_score = -1;
    }
	
	// Update is called once per frame
	void Update () {
        if (now_score != score_number)
        {
            number = Score_text.GetComponent<Text>();
            number.text ="Score:"+score_number;
            now_score = score_number;
        }
	}

    public void Addscore(int point)
    {

      score_number+=point;
      //Debug.Log(score_number);
    }

    public static int ReturnScore()
    {
        return score_number;
    }
}
