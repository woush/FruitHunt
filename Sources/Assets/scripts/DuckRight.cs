using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckRight : MonoBehaviour
{
    float speed;
    bool enable = true;
    Vector2 mySpawn;
    public AudioSource hitsong;

    // Start is called before the first frame update
    void Start()
    {
        hitsong = GetComponent<AudioSource>();

        speed = Random.Range(0.03f, 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        if (enable)
        {
            Vector2 targetPos = this.transform.position;
            targetPos.y += 0.7f;
            targetPos.x -= 1.5f;
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

        if (obj.transform.tag == "Knife" && enable == true)
        {
            hitsong.Play();
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
