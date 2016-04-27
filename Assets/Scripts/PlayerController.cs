using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Assets.Scripts;

public class PlayerController : BaseLogic
{
    public Vector3 originalScale;
    private Rigidbody rb;
    private Text gameOver;
    private PlayerController player;
    EnemyController enemy;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalScale = transform.localScale;
        player = gameObject.GetComponent<PlayerController>();
    }
    public void ShowScoreText()
    {

    }
    public void Update()
    {
        transform.localScale = new Vector3(size, size, size);
    }

    /// <summary>
    /// Movement of the player
    /// </summary>
    public void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="col"></param>
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            float palyerSize = player.GetSize();
            EnemyController collised_enemy = col.gameObject.GetComponent<EnemyController>();
            float col_obj_size = collised_enemy.GetSize();
            if (col_obj_size < player.GetSize())
            {       
                Debug.Log("collision with:" + col.gameObject.name);
                col.gameObject.SetActive(false);

                Debug.Log("" + col_obj_size + " < playersize");
                Debug.Log("Coeficient = " + CalculateCoeficient(player, collised_enemy));
                ScaleObject(player, collised_enemy);
            }
        }
    }
}
