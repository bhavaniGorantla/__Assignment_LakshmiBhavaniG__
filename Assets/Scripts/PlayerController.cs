using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public GameObject secondBodyPart;
	private GameObject[] bodypart;
	private float timer = 0f;
	private Vector3 forward = Vector3.forward;
	public int count;
	public bool isDead = false;
    public GameObject GameoverPanel;

    //Food Values
    public bool food1;
    public bool food2;
    public int food1Count;
    public int food2Count;

    //Scores
    public int scoreCount;
    public int bestScoreCount;
    public Text currentScore;

    public Text scoreGameover;
    public Text bestScore;

    //Food Spawning
    public GameObject[] foods;

    //ContnousFoodCounts
    public Text ball1Count;
    public Text ball2Count;



    void Start () {
        GameoverPanel.SetActive(false);
        bodypart = new GameObject[50];
        bodypart[0] = gameObject;
        bodypart[1] = secondBodyPart;
		count = 2;
        scoreCount = 0;
        currentScore.text = "Score: "+scoreCount.ToString();
        ball1Count.text = "x " + 0;
        ball2Count.text = "x " + 0;

    }

    // Update is called once per frame
    void Update () {
		forward = Movement();
		timer += Time.deltaTime;

		if (timer > 0.15f) {
			headDir ();
			transform.position += forward;
			timer = 0f;
		}
	}


    void OnTriggerEnter(Collider other) {

        //On collision with yellow food : Score 20 for yellow
		if (other.gameObject.tag == "Food1") {
            
			increment ();
            Destroy(other.gameObject);
            food2Count = 0;
            food1Count++;
            if(food1Count>1)
            {
                scoreCount += (20 * food1Count);
            }else
            {
                scoreCount += 20;
            }
            currentScore.text = "Score: " + scoreCount.ToString();
            ball1Count.text = "x " + food1Count.ToString();
            ball2Count.text = "x " + food2Count.ToString();

            randomPosition();
        }

        //On collision with green food : Score 30 for Green
        if (other.gameObject.tag == "Food2")
        {
           
            increment();
            Destroy(other.gameObject);
            food1Count = 0;
            food2Count++;
            if (food2Count > 1)
            {
                scoreCount += (30 * food2Count);
               
            }
            else
            {
                scoreCount += 30;
            }

            currentScore.text = "Score: " + scoreCount.ToString();
            ball1Count.text = "x " + food1Count.ToString();
            ball2Count.text = "x " + food2Count.ToString();

            randomPosition();
        }

        if (other.gameObject.tag == "Wall") {
			forward = Vector3.zero;
			isDead = true;
            GameoverPanel.SetActive(true);
            scoreGameover.text = "Score: " + scoreCount.ToString();
            if(scoreCount >= DB.Instance.bestScoreCount)
            {
                DB.Instance.bestScoreCount = scoreCount;
                bestScore.text = "Best Score: "+scoreCount.ToString();
              
                PlayerPrefs.SetInt("bestScoreCount", DB.Instance.bestScoreCount);
            }else
            {
                bestScore.text = "Best Score: " + DB.Instance.bestScoreCount.ToString();
            }
		}
	}




    Vector3 Movement() {
		if (Input.GetKeyDown (KeyCode.A)) {
			return Vector3.left;
		}
        else if (Input.GetKeyDown (KeyCode.W)) {
			return Vector3.forward;
		}
        else if (Input.GetKeyDown (KeyCode.S)) {
			return Vector3.back;
		}
        else if (Input.GetKeyDown (KeyCode.D)) {
			return Vector3.right;
		}
        else {
			return forward;
		}
	}

	void headDir() {
		if (!isDead) {
			for (int i = count - 1; i > 0; i--) {
                bodypart[i].transform.position = bodypart[i - 1].transform.position;
			}
		}
	}

	void increment() {
		GameObject newBody = GameObject.Instantiate (secondBodyPart);
        bodypart[count] = newBody;
		count++;
	}

    //Spawning Food in different positions
    void randomPosition()
    {
        int i = Random.Range(0, foods.Length);
        GameObject Food = Instantiate(foods[i]);

        float x = Random.Range(-18f, 18f);
        float z = Random.Range(-18f, 18f);

        Food.transform.position = new Vector3(x, 0.5f, z);
    }

    public void OnMenu()
    {
        SceneManager.LoadScene("MainScene");
    }
}
