using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSpawner : MonoBehaviour
{
    public GameObject duck1, duck2;
    public float Timer1 = 2f;
    public float Timer2 = 1.5f;

    Vector2 position1;
    Vector2 position2;


    // Start is called before the first frame update
    void Start()
    {
        position1 = new Vector2(-4f, Random.Range(-3.5f, 1f));
        position2 = new Vector2(4f, Random.Range(-3.5f, 1f));


    }

    // Update is called once per frame
    void Update()
    {
        Timer1 -= Time.deltaTime;
        if (Timer1 <= 0f)
        {
            Instantiate(duck1, position1, Quaternion.identity);
            Instantiate(duck2, position2, Quaternion.identity);

            Timer1 = 1.6f;
            Start();
        }
    }

}
