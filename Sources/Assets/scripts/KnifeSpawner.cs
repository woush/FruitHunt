using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeSpawner : MonoBehaviour
{
    public GameObject knife;
    public static bool enableKnife = false;
    Vector2 position = new Vector2(0f, -4.12f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && !enableKnife)
        {
            
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                enableKnife = true;
                Instantiate(knife, position, Quaternion.identity);
            }
        }
        if (Input.GetMouseButtonDown(0) && !enableKnife)
        {
            enableKnife = true;
            Instantiate(knife, position, Quaternion.identity);
        }
    }

    public void setEnableToFalse()
    {
        enableKnife = false;
    }
}
