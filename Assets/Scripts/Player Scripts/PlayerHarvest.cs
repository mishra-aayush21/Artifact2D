using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHarvest : MonoBehaviour
{
    [SerializeField]
    private float harvestTime = 0.4f;

    private PlayerMovement playerMovement;
    private PlayerBackpack backpack;

    private AudioSource audioSource;

    private Collider2D collidedBush;
    private BushFruits hitBush;

    private bool canHarvestFruits;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        backpack = GetComponent<PlayerBackpack>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        //Creating an input wall over the harvesting mechanic
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space))
        {
            TryHarvestFruit();
        }
    }
    private void TryHarvestFruit()
    {
        //checks wheather the bush has fruits or not
        if (!canHarvestFruits) 
            return;
        if (collidedBush != null)
        {
            hitBush=collidedBush.GetComponent<BushFruits>();
            if (hitBush.HasFruits()) 
            {
                audioSource.Play();
                playerMovement.HarvestStopMovement(harvestTime);
                backpack.AddFruits(hitBush.HarvestFruit());
            }
        }
        
    }
    //ontrigger enter code to just register potential harvest to the system, also enables the input wall
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bush"))
        {
            canHarvestFruits = true;
            collidedBush = collision;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Bush"))
        {
            canHarvestFruits= false;
            collidedBush = null;
        }
    }
}
