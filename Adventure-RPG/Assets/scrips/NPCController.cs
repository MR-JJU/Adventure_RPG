using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, Interactable
{
   // private Transform player;

    //initialize dialog für NPC and shows it
    [SerializeField] Dialog dialog;

    public void Interact()
    {
        StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
    }
    /*
    private void OnTriggerStay2D(Collider2D collision) 
    {
    if (collision.gameObject.tag == "Player") 
        {
            // find players transform
            player = collision.gameObject.GetComponent<Transform>();

            //check to see where the player is and then turn towards 
            if (player.position.x > transform.position.x && transform.parent.localScale.x < 0) 
            {
                Flipx();
            }
            else if (player.position.x > transform.position.x && transform.parent.localScale.x > 0) 
            {
                Flipx();
            }

            if (player.position.y > transform.position.y && transform.parent.localScale.y < 0)
            {
                Flipy();
            }
            else if (player.position.y > transform.position.y && transform.parent.localScale.y > 0)
            {
                Flipy();
            }

        }
    }

    private void Flipx() 
    {
        Vector3 currentScale = transform.parent.localScale;
        currentScale.x *= -1;
        transform.parent.localScale = currentScale;
    }

    private void Flipy()
    {
        Vector3 currentScale = transform.parent.localScale;
        currentScale.y *= -1;
        transform.parent.localScale = currentScale;
    }*/

}
