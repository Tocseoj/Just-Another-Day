using UnityEngine;
using System.Collections;

public class Fly : MonoBehaviour {
    public Sprite[] frames;
    public int currentSprite;
    public SpriteRenderer sr;
    public Rigidbody2D rb;
    public float timeTillFlap;
    private int changeEveryFrames;
    public GameObject flyBody;
    public GameObject flyWing;

    // Use this for initialization
    void Start () {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        timeTillFlap = Random.Range(0.1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
        timeTillFlap -= Time.deltaTime;

        if (timeTillFlap <= 0)
        {
            rb.AddRelativeForce(Vector2.up*Random.Range(250,1000) + new Vector2(Random.Range(-1000,1000),0));
            timeTillFlap = timeTillFlap = Random.Range(0.1f, 2f);
        }
        
        if (changeEveryFrames >= rb.velocity.magnitude*0.25f)
        {
            animate();
            changeEveryFrames = 0;
        }
        else
        {
            changeEveryFrames++;
        }
    }

    private void animate()
    {
        if (frames.Length <= 0)
            return;
        if (currentSprite < frames.Length)
        {
            sr.sprite = frames[currentSprite];
            currentSprite++;
        }
        else
        {
            currentSprite = 0;
            animate();
        }
    }

    public void kill()
    {
        Vector3 euler = transform.eulerAngles;
        euler.z = Random.Range(0.0f, 360.0f);
        Instantiate(flyWing, transform.position + new Vector3(Random.Range(-3, 3), Random.Range(-3, 3)), Quaternion.Euler(euler));
        euler.z = Random.Range(0.0f, 360.0f);
        Instantiate(flyWing, transform.position + new Vector3(Random.Range(-3, 3), Random.Range(-3, 3)), Quaternion.Euler(euler));
        euler.z = Random.Range(0.0f, 360.0f);
        Instantiate(flyBody, transform.position + new Vector3(Random.Range(-3,3), Random.Range(-3, 3)), Quaternion.Euler(euler));
        Destroy(this.gameObject);
    }
}