using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByDashing : MonoBehaviour
{
    public PlayerMovement PlayerMovement;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Enemy")
        {  
            if (PlayerMovement.isDashing)
            {
                Destroy(collision.gameObject);
            }
            else if(PlayerMovement.isDashing == false)
            {
                Destroy(gameObject);
            }
            
        }
    }
}
