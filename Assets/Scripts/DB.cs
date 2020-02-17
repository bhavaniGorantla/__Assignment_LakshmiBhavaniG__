using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB : MonoBehaviour
{

    private static DB instance = null;


    [HideInInspector] public int bestScoreCount;
    public static DB Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.Find("DB").GetComponent<DB>();
            }
            return instance;
        }
    }


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
 
}
