using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Assets.Scripts;

public class PlayerController : BaseLogic {

    //public float speed;
    private Rigidbody rb;
    //private int score = 0;
    private Text gameOver;
    //public float size = 1f;
    public Vector3 originalScale;
    private PlayerController player;
    private float ratio = 0.0f;
    EnemyController enemy;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        //score = 0;
        originalScale = transform.localScale;
        player = gameObject.GetComponent<PlayerController>();
    }
    public float GetSize()
    {
        return size;
    }
    public void ShowScoreText()
    {

    }
    public void Update()
    {
        transform.localScale = originalScale * size;

    }
    public void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
    public float CalculateRatio(Collision col)
    {
        float enemysize = col.gameObject.GetComponent<EnemyController>().GetSize();
        float difference = player.GetSize() - enemysize;
        if (enemysize < 1)
        {
            return ratio = player.GetSize() * enemysize;
        }
        if (difference < 1)
        {
            return ratio = 1 + (1 - difference);
        }
        else
        {
            return ratio = enemysize / player.GetSize();
        }

    }
    public float ScaleSizeSmall(Collision col)
    {
        return size = size + (float)Math.Pow((double)CalculateRatio(col), 2d);
    }
    public float ScaleMediumSize(Collision col)
    {
        float difference = player.GetSize() - enemy.GetSize();
        Debug.Log("Size of the player :" + GetSize());
        if (difference < 1)
        {
            size = size + (float)Math.Sqrt((double)CalculateRatio(col)) * 0.2f;
        }
        else
        {
            size = size + (float)Math.Sqrt((double)CalculateRatio(col)) * 0.1f;
        }
        Debug.Log("ratio : " + ratio);
        Debug.Log("size - " + size);
        return size;
    }
    public float ScaleBigSize(Collision col)
    {
        size = size + (float)Math.Sqrt((double)CalculateRatio(col)) * 0.05f;
        Debug.Log("ratio : " + CalculateRatio(col));
        Debug.Log("size : " + size);
        return size;
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            float palyerSize = player.GetSize();
            float col_obj_size = col.gameObject.GetComponent<EnemyController>().GetSize();
            if (col_obj_size < player.GetSize())
            {
                Debug.Log("collision with:" + col.gameObject.name);
                col.gameObject.SetActive(false);

                Debug.Log("" + col_obj_size + " < playersize");
                if (size - col_obj_size < 1)
                {
                    //ratio = playerSize.GetSize() * col.gameObject.GetComponent<EnemyController>().GetSize();
                    CalculateRatio(col);
                    Debug.Log("ratio : " + CalculateRatio(col));
                    ScaleSizeSmall(col);
                    //size = size / (float)Math.Sqrt((double)GetRatio(col));

                    Debug.Log("size after scale : " + Math.Log(ratio));
                }
                else if (player.GetSize() >= 1)
                {
                    if (player.GetSize() < 5)
                    {
                        CalculateRatio(col);
                        Debug.Log("ratio : " + CalculateRatio(col));
                        ScaleMediumSize(col);
                    }
                }
                if (player.GetSize() >= 5f)
                {
                    CalculateRatio(col);
                    ScaleBigSize(col);
                }
                //    switch (playerSize)
            }
        }
    }
}
