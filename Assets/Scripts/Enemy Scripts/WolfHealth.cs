using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class WolfHealth : MonoBehaviour
{
    [SerializeField]
    private GameObject healthUI;
    [SerializeField]
    private int maxHealth=100;

    private float scale;
    private int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int amount)
    {
        currentHealth-=amount;
        scale = (float)currentHealth / maxHealth;

        healthUI.transform.localScale=new Vector3(scale,healthUI.transform.localScale.y,1f);
        if (currentHealth <= 0) Destroy(gameObject);
    }









}//class
