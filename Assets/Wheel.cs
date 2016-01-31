using UnityEngine;
using System.Collections;

public class Wheel : MonoBehaviour
{
    private bool follow = false;
    private Rigidbody2D rb;
    public GameObject pancakeOtherSide;
    public Vector3 mousePos;
    public Vector3 oldMousePos;

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
        oldMousePos = mousePos;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos = new Vector3(mousePos.x, mousePos.y, 0f);
        if (Input.GetMouseButtonUp(0))
            follow = false;
        if (follow)
        {
            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.Equals(pancakeOtherSide))
        {
            Debug.Log("Victory");
        }
    }
}
