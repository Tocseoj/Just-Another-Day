using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Water"))
        {
            Destroy(col.gameObject);
        }
    }
}