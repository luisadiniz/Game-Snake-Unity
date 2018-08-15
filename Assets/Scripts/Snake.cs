using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Snake : MonoBehaviour {
    [SerializeField]
    GameObject tailPrefab;
	List<Transform> tail = new List<Transform>();
	bool ate = false;
	Vector2 dir = Vector2.right;

    [SerializeField]
    SpawningFood spawningFood;
    Vector2 initialPosition;

    [SerializeField]
    private float velocidade;

    [SerializeField]
    private bool gameOver;
    [SerializeField]
    GameObject buttonRestart;
    [SerializeField]
    GameUpDate gameUpDate;


    void Start () {

        gameOver = false;
 

        buttonRestart.SetActive(false);
        velocidade = PlayerPrefs.GetFloat("Velocity");

        spawningFood.Spawn(false);                     
        InvokeRepeating ("Move", velocidade, velocidade);
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

            gameUpDate.AddScore(10);

            spawningFood.Spawn(false);

            int randomNumber = Random.Range(0,100);

            if (randomNumber > 50) {
                spawningFood.Spawn(true); 

            }
        }
        else if (coll.tag == "FoodSpecial"){
            ate = true;
            Destroy(coll.gameObject);

            gameUpDate.AddScore(50);
        }

        else
        {
            // COLIDE COM QUALQUER OUTRA COISA QUE NAO EH COMIDA
           GameOver();
        }
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
                gameUpDate.gameOverText.text = "";
                // gameOverText.gameObject.SetActive(false); - outra opcao

        }
	}

    public void GameOver()
    {
        gameOver = true;
        gameUpDate.GameOverText();
        buttonRestart.SetActive(true);

        gameUpDate.StoreHighscore();
        gameUpDate.UpdateHighScoreUI();
    }
}
