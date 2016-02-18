using UnityEngine;
using System.Collections;

public class FishFoodPellets : MonoBehaviour {
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -48f)
            Destroy(this.gameObject);
        if (rb.velocity.magnitude < 1 && rb.gravityScale < 1)
            rb.isKinematic = true;
    }
}
