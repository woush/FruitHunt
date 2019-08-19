using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Knife : MonoBehaviour
{
    public float speed;
    bool enable = true;
    Vector2 mySpawn;

    // Start is called before the first frame update
    void Start()
    {
        mySpawn = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(enable)
        {
            Vector2 targetPos = this.transform.position;
            targetPos.y += 10;
            this.transform.position = Vector2.MoveTowards(this.transform.position, targetPos, speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D obj)
    {        
        if(obj.transform.tag == "Duck" && enable == true)
        {
            this.transform.parent = obj.transform;
            Death(true);
            SceneManager.LoadScene("SampleScene");
        }

        if(obj.transform.tag == "Fruit" && enable == true)
        {
            this.transform.parent = obj.transform;
            
            obj.gameObject.GetComponent<Fruit>().Hit();
            
            Death(true);
        }
    }

    //tue le cut 
    void Death(bool remove)
    {
        enable = false;
        this.GetComponent<BoxCollider2D>().enabled = false;

        if (remove)
        {
            KnifeSpawner.enableKnife = false;
            Destroy(this.gameObject);
        }
    }

}
