using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBackpack : MonoBehaviour
{
    public int maxFruits;
    public int currentFruits;

    [SerializeField]
    private Text backpackInfoText;


    private void Start()
    {
        SetBackpackInfoText(0);
    }
    // Globally updates the fruits amount to your tally, specifically the current fruits set
    public void AddFruits(int amount)
    {
        currentFruits += amount;
        if (currentFruits>maxFruits)
        {
            currentFruits = maxFruits;
        }
        SetBackpackInfoText(currentFruits);
    }
    //Uses the fruits to heal-up the artfact as soo as it enters the trigger around the artifact
    //another implementation wouldve been as to give a prompt to heal it instead of just letting the trigger mechanic do it
    public int TakeFruits()
    {
        int takenFruits = currentFruits;
        currentFruits = 0;
        SetBackpackInfoText (currentFruits);
        return takenFruits;

    }
    void SetBackpackInfoText(int amount)
    {
        backpackInfoText.text = "Backpack:" + amount + "/" + maxFruits;

    }
}
