using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckLeft : MonoBehaviour
{
    float speed;
    bool enable = true;
    Vector2 mySpawn;

    // Start is called before the first frame update
    void Start()
    {
        mySpawn = this.transform.position;
        speed = Random.Range(0.02f, 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        if (enable)
        {
            Vector2 targetPos = this.transform.position;
            targetPos.y += 0.5f;
            targetPos.x += 1.5f;
            this.transform.position = Vector2.MoveTowards(this.transform.position, targetPos, speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.transform.tag == "DeleteZone" && enable == true)
        {
            this.transform.parent = obj.transform;
           
            Death(true);
        }
    }

    void Death(bool remove)
    {
        enable = false;
        this.GetComponent<BoxCollider2D>().enabled = false;

        if (remove)
        {
            Destroy(this.gameObject);
        }
    }
}
