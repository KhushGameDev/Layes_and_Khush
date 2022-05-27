using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Transform playerTransform;
    public Transform[] Background;
    
    private float leftviewend = 3.5f;
    private float leftmovepos = 32;
    private int lastleftbackground = 0;
    
    
    void Start()
    {
        
    }

    void Update()
    {
        if(playerTransform.position.x >= leftviewend)
        {
            Background[lastleftbackground].position = new Vector3(leftmovepos, 0, 0);
            if(lastleftbackground == 0)
            {
                if (Background[0].gameObject.GetComponent<SpriteRenderer>().flipX == true)
                {
                    Background[0].gameObject.GetComponent<SpriteRenderer>().flipX = false;
                }
                else
                {
                    Background[0].gameObject.GetComponent<SpriteRenderer>().flipX = true;
                }
                
            }
            if(lastleftbackground == 1)
            {
                if (Background[1].gameObject.GetComponent<SpriteRenderer>().flipX == true)
                {
                    Background[1].gameObject.GetComponent<SpriteRenderer>().flipX = false;
                }
                else
                {
                    Background[1].gameObject.GetComponent<SpriteRenderer>().flipX = true;
                }
            }
            if(lastleftbackground == 2)
            {
                if (Background[2].gameObject.GetComponent<SpriteRenderer>().flipX == true)
                {
                    Background[2].gameObject.GetComponent<SpriteRenderer>().flipX = false;
                }
                else
                {
                    Background[2].gameObject.GetComponent<SpriteRenderer>().flipX = true;
                }
            }
            
            leftmovepos = leftmovepos + 16;
            leftviewend = leftviewend + 16;

            lastleftbackground++;
            if(lastleftbackground == 3)
            {
                lastleftbackground = 0;
            }
            
        }
        
    }
}
