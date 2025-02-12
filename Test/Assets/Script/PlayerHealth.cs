using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth;
    public float maxHealth;

    public Text healthText;

    public GameObject deathScreen;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth < 0)
        {
            playerHealth = 0;
        }

        if (playerHealth <= 0)
        {
            deathScreen.SetActive(true);
           gameObject.SetActive(false);
        }

        healthText.text = "Health:" + playerHealth.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            playerHealth--;
            Debug.Log(playerHealth);
        }
    }
}
