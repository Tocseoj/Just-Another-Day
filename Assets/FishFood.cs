using UnityEngine;
using System.Collections;

public class FishFood : MonoBehaviour {
    public GameObject foodPellet;
    public int numberOfPellets;
    public Transform foodSpawn;
    private bool follow = false;
    private Rigidbody2D rb;
    private Vector3 mousePos;
    private int currentPellet;
    public Sprite[] pelletSprites;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            follow = true;
        }
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos = new Vector3(mousePos.x, mousePos.y, 0f);
        if (Input.GetMouseButtonUp(0))
            follow = false;

        if (follow)
            rb.velocity = (-transform.position + mousePos) * 5f;

        if (Vector3.Dot(transform.up, Vector3.down) > 0)
        {
            for (int x = 0; x < 1; x++)
            {
                Vector3 euler = transform.eulerAngles;
                euler.z = Random.Range(0.0f, 360.0f);
                GameObject pellet = (GameObject)Instantiate(foodPellet, foodSpawn.position + new Vector3(Random.Range(-3, 4), 0), Quaternion.Euler(euler));
                pellet.GetComponent<SpriteRenderer>().sprite = pelletSprites[currentPellet];
                currentPellet = Random.Range(0, pelletSprites.Length);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer.Equals("Water"))
            numberOfPellets++;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer.Equals("Water"))
            numberOfPellets--;
    }
}