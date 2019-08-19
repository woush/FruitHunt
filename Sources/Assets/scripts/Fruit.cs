using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public AudioSource hitsong;
    public int scoreValue = 1;

    // Start is called before the first frame update
    void Start()
    {
        hitsong = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Hit()
    {
        hitsong.Play();
        ScoreManager.score += scoreValue;
    }
}
