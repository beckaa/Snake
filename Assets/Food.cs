using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public List<Sprite> diffFood;
    public GameObject foodItem;
    public BoxCollider2D GridArea;
    Bounds bound;
    // Start is called before the first frame update
    void Start()
    {
        bound = GridArea.bounds;
    }

    public void instantiateNewFood()
    {
        int numberFood = Random.Range(0, diffFood.Count-1);
        float randomX = Mathf.Round(Random.Range(bound.min.x, bound.max.x));
        float randomY =Mathf.Round(Random.Range(bound.min.y, bound.max.y));
        GameObject newItem=Instantiate(foodItem);
        SpriteRenderer render = newItem.GetComponent<SpriteRenderer>();
        render.sprite = diffFood[numberFood];
        newItem.transform.position = new Vector3(randomX, randomY, 0.0f);
        newItem.SetActive(true);
    }
}
