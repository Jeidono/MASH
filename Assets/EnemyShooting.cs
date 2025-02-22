using Unity.Mathematics;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletpos;
    private float timer;
    private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Check if player is still valid before accessing
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);

            if (distance < 7)
            {
                timer += Time.deltaTime;

                if (timer > 2)
                {
                    timer = 0;
                    shoot();
                }
            }
        }
    }

    void shoot()
    {
        Instantiate(bullet, bulletpos.position, Quaternion.identity);
    }
}
