using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningFood : MonoBehaviour
{

    public GameObject foodPrefab;
    public GameObject foodSpecial;

    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;


    public void Spawn(bool isSpecialFood)
    {
        int x = (int)Random.Range(borderLeft.position.x + 2, borderRight.position.x - 2);
        int y = (int)Random.Range(borderTop.position.y - 2, borderBottom.position.y + 2);

        if (isSpecialFood)
        {
            GameObject a = Instantiate(foodSpecial, new Vector2(x, y), Quaternion.identity);
            Destroy(a, 4.0f);
        }
        else
        {
            Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);
        }
    }

}
