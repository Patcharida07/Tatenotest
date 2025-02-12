using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    public Transform player;

    public float enemyHealth;

    public GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        UI = GameObject.FindGameObjectWithTag("UI");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            //player movement
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

            //enemy rotation
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; //-90f;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }

        if (enemyHealth <= 0)
        {
            UI.GetComponent<ScoreSystem>().AddScore();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
           
            enemyHealth--;
        }
    }
}
