using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Snake : MonoBehaviour {
	public GameObject tailPrefab;
	List<Transform> tail = new List<Transform>();
	bool ate = false;
	private Vector2 dir = Vector2.right;
    public SpawningFood spawningFood;
    public GUIText gameOverText;
    public Vector2 initialPosition;
    public GameObject buttonRestart;

    public GUIText scoreText;
    public int score;

    public bool gameOver;

    void Start () {
        gameOver = false;
        gameOverText.text = "";

        score = 0;
        UpdateScore();

        buttonRestart.SetActive(false);

        spawningFood.Spawn();                     
        InvokeRepeating ("Move", 0.15f, 0.15f);
	}

	void Move() {
        if(!gameOver)
        {
            Vector2 v = transform.position;

            transform.Translate(dir);

            if (ate)
            {
                GameObject g = Instantiate(tailPrefab, v, Quaternion.identity);

                tail.Insert(0, g.transform);
                ate = false;
            }
            else if (tail.Count > 0)
            {
                tail.Last().position = v;

                tail.Insert(0, tail.Last());
                tail.RemoveAt(tail.Count - 1);

            }
        }
	
	}


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Food")
        {
            ate = true;
            Destroy(coll.gameObject);

            score = score + 10;
            UpdateScore();

            spawningFood.Spawn();

            int randomNumber = Random.Range(0,100);
            Debug.Log("Aleatorio " + randomNumber);

            if (randomNumber > 50) {
                spawningFood.SpawnSpecial(); 

            }
        }
        else if (coll.tag == "FoodSpecial"){
            ate = true;
            Destroy(coll.gameObject);

            score = score + 50;
            UpdateScore();

        }

        else if (coll.tag == "Border")       
        {
            //Game Over
            GameOver();
            Debug.Log("PERDI");
        }
        else
        {
            GameOver();
        }
    }

    void GameOver() {
        gameOver = true;
        gameOverText.text = "Game Over!";

        buttonRestart.SetActive(true);
	}

    void AddScore(int newScoreValue) {
        score += newScoreValue;
        UpdateScore();
    }

    // converter o score para uma string no jogo
    void UpdateScore() {
        scoreText.text = "Score :" + score;
    }


    // faz as funções do teclado funcionarem para movimentar a cobra
	void Update() {
		if (Input.GetKey (KeyCode.RightArrow) && dir != Vector2.left) {
			dir = Vector2.right;
        } else if (Input.GetKey (KeyCode.DownArrow) && dir != Vector2.up) {
			dir = Vector2.down;
        } else if (Input.GetKey (KeyCode.LeftArrow) && dir != Vector2.right) {
			dir = Vector2.left;
        } else if (Input.GetKey (KeyCode.UpArrow) && dir != Vector2.down) {
			dir = Vector2.up;
		}
        else if (Input.GetKey (KeyCode.Space) && gameOver)
        {
                gameOver = false;
                transform.position = initialPosition;
                gameOverText.text = "";
                // gameOverText.gameObject.SetActive(false); - outra opcao

        }
	}
}
