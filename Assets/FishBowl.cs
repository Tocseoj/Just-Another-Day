using UnityEngine;
using System.Collections;

public class FishBowl : MonoBehaviour {


    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col);
        if (col.gameObject.tag.Equals("Water"))
        {
            col.gameObject.GetComponent<Rigidbody2D>().velocity /= 2;
            col.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.25f;
        }
    }
}
