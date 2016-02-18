using UnityEngine;
using System.Collections;

public class Sink : MonoBehaviour {
    public GameObject waterDroplet;
    public int numberOfDroplets;
    private int currentWater;
    public Sprite[] waterSprites;
    public Transform waterSpawn;
    public Dish cup;
    public Dish bowl;

    void Update()
    {
        if (numberOfDroplets <= 0)
        {
            for (int x = 0; x < 3; x++)
            {
                GameObject water1 = (GameObject)Instantiate(waterDroplet, waterSpawn.position + new Vector3(Random.Range(-2, 3), 0), transform.rotation);
                water1.GetComponent<SpriteRenderer>().sprite = waterSprites[currentWater];
                if (currentWater >= waterSprites.Length-1)
                    currentWater = 0;
                else
                    currentWater += 1;
            }
        }

        if (cup.percentClean >= 100f && bowl.percentClean >= 100f)
        {
            GameController.control.PlayerWon(3f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer.Equals("Water"))
            numberOfDroplets++;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer.Equals("Water"))
            numberOfDroplets--;
    }
}
