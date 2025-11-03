using System;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int health = 50;
    [SerializeField] private float movespeed = 2f;
    [SerializeField] private int value = 10;
    
    private Transform checkpoint;
    private Rigidbody2D rb;
    [NonSerialized] public int index = 0;
    [NonSerialized] public float distance =0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        checkpoint = enemymanager.main.checkpoints[index];
    }
    void Update()
    {
        checkpoint = enemymanager.main.checkpoints[index];
        distance = Vector2.Distance(transform.position, enemymanager.main.checkpoints[index].position);

        if(Vector2.Distance(checkpoint.transform.position, transform.position) <= 0.1f)
        {
            index++;
            if(index >= enemymanager.main.checkpoints.Length)
            {
                Player.main.Damage(health);
                Destroy(gameObject);
            }
        }

    }

    // Update is called once per frame
    void  FixedUpdate()
    {
        Vector2 direction = (checkpoint.position - transform.position).normalized;
        transform.right = checkpoint.position - transform.position;
        rb.linearVelocity = direction * movespeed;
    }

    public void Damage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Player.main.money += value;
            Destroy(gameObject);
        }
    }
}
