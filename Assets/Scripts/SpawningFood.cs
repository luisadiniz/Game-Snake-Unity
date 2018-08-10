using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningFood : MonoBehaviour {

	public GameObject foodPrefab;
    public GameObject foodSpecial;

	public Transform borderTop;
	public Transform borderBottom;
	public Transform borderLeft;
	public Transform borderRight;

	
	public void Spawn() {

		int x = (int)Random.Range (borderLeft.position.x, borderRight.position.x);

		int y = (int)Random.Range (borderTop.position.y, borderBottom.position.y);

		Instantiate (foodPrefab, new Vector2 (x, y), Quaternion.identity);
	}

    public void SpawnSpecial()
    {
        int x = (int)Random.Range(borderLeft.position.x, borderRight.position.x);

        int y = (int)Random.Range(borderTop.position.y, borderBottom.position.y);


        GameObject a = Instantiate(foodSpecial, new Vector2(x, y), Quaternion.identity);

        Destroy(a, 4.0f);
    }
}
