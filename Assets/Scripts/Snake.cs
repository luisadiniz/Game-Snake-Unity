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


    void Start () {
		InvokeRepeating ("Move", 0.3f, 0.3f);	
	}

	void Move() {

		Vector2 v = transform.position;

		transform.Translate (dir);

		if (ate) {
			GameObject g = Instantiate (tailPrefab, v, Quaternion.identity);

			tail.Insert (0, g.transform);
			ate = false;
		} else if (tail.Count > 0) {
			tail.Last ().position = v;

			tail.Insert (0, tail.Last ());
			tail.RemoveAt (tail.Count - 1);
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.name.StartsWith ("FoodPrefab")) {
			ate = true;
			Destroy (coll.gameObject);
            spawningFood.Spawn();
		} else {
			//Game Over
		}
	}

    // faz as funções do teclado funcionarem para movimentar a cobra
	void Update() {
		if (Input.GetKey (KeyCode.RightArrow)) {
			dir = Vector2.right;
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			dir = -Vector2.up;
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			dir = -Vector2.right;
		} else if (Input.GetKey (KeyCode.UpArrow)) {
			dir = Vector2.up;
		}
	}
}
