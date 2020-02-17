using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Main : MonoBehaviour
{
    private static Main instance = null;
    public Text best;
   

    public static Main Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.Find("Main").GetComponent<Main>();
            }
            return instance;
        }
    }


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {

        DB.Instance.bestScoreCount = PlayerPrefs.GetInt("bestScoreCount");
     
        best.text = "Score: " + DB.Instance.bestScoreCount.ToString(); 
    }
    
    public void OnPlay()
    {
        SceneManager.LoadScene("GameScene");
    }


}
