using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.UI;

public class BushVisuals : MonoBehaviour
{
    public enum BushVariants { Green,Cyan,Yellow}
    private BushVariants variants;
    public float hideTimePerFruit=0.2f;
    private SpriteRenderer sr;

    [SerializeField]
    private SpriteRenderer[] FruitsRenderers;
    [SerializeField]
    private Sprite[] bushSprites,fruitSprites, drySprites;

    // All Sprite and sprite renderer arrays carry the different sprites and thier variants
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        variants= (BushVariants)Random.Range(0,bushSprites.Length);
        sr.sprite= bushSprites[(int)variants];

        //randomly generate the side of the bush and also its probablity of holding fruits
        if (Random.Range(0, 2)==1)
        {
            sr.flipX = true;
        }
        for (int i = 0; i < FruitsRenderers.Length; i++)
        {
            FruitsRenderers[i].sprite= fruitSprites[(int)variants];
            FruitsRenderers[i].enabled= false;
        }

        
    }
    // Returning Variants from the enum
    public BushVariants GetBushVariant()
    {
        return variants;
    }
    //Setting the bushes to dry so that they change visuals over time
     public void SetToDry() 
    {
        sr.sprite = drySprites[(int)variants];
    }
    //Coroutine sequence to actually hide friuts inside the window
    IEnumerator _HideFruits(float time, int index)
    {
        yield return new WaitForSeconds(time);
        FruitsRenderers[index].enabled= false;
    }
    //public function to call the coroutine
    public void HideFruits()
    {
        float waitTimeForFruits = hideTimePerFruit;
        for (int i = 0; i < FruitsRenderers.Length; i++)
        {
            StartCoroutine(_HideFruits(waitTimeForFruits, i));
            waitTimeForFruits += hideTimePerFruit;
        }
    }
    //function to show the fruits at start
    public void ShowFruits()
    {
        for (int i = 0; i < FruitsRenderers.Length; i++)
        {
            FruitsRenderers[i].enabled = true;
        }
    }
    



}
