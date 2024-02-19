using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BushFruits : MonoBehaviour
{
    private bool hasFruits;
    private BushVisuals bushVisual;
    [SerializeField]
    private int[] numberFruits;
    [SerializeField]
    private int[] fruitsReset;

    public float timer;
    void Awake()
    {
        bushVisual=GetComponent<BushVisuals>();

        // Randomly choose bushes to have fruit at start or not , 50% chance to be exact
        if (Random.Range(0, 2) == 0)
        {
            hasFruits = false;
            timer = Time.time + fruitsReset[(int)bushVisual.GetBushVariant()];
        }
        else
        {
            hasFruits = true;
            bushVisual.ShowFruits();
        }
    }

    // 
    void Update()
    {
        // this updates the fruit status if the bushes didnt have the fruits
        if(Time.time > timer)
        {
            hasFruits = true;
            bushVisual.ShowFruits();

        }
        
    }
    public bool HasFruits() { return hasFruits; }


    // this returns an integer of number of that fruit-bush variant
    public int HarvestFruit()
    {
        if (hasFruits)
        {
            //fruits are hidden and return of the bush visual is done along with reset of the timer to reset the fruits
            hasFruits= false;
            bushVisual.HideFruits();
            timer = Time.time + fruitsReset[(int)bushVisual.GetBushVariant()];
            return numberFruits[(int)bushVisual.GetBushVariant()];
            //returns the value of fruits for the variant
        }
        else return 0;

    }
    //this will be used to get the fruit destroyed mechanic when attacked by a wolf
    public void EatFruits()
    {
        enabled = false;
        bushVisual.SetToDry();
    }
}
