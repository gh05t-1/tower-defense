using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] private float movespeed = 2f;
    
    private Transform checkpoint;
    private Rigidbody2D rb;
    private int index = 0;
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
        if(Vector2.Distance(checkpoint.transform.position, transform.position) <= 0.1f)
        {
            index++;
            if(index >= enemymanager.main.checkpoints.Length)
            {
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
}
