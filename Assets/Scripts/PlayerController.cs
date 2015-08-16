using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour {

    public float speed;
    private Rigidbody rb;
    private int score = 0;
    private Text gameOver;
    public float size = 1f;
    public Vector3 originalScale;
    private PlayerController playerSize;
    private float ratio = 0.0f;
    float enemysize;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        score = 0;
        originalScale = transform.localScale;
        playerSize = gameObject.GetComponent<PlayerController>();
    }

    public float EnemySize
    {
        set
        {
            Collision col = new Collision();
            enemysize = col.gameObject.GetComponent<EnemyController>().GetSize();
            value = enemysize;
        }
        get
        {
            return enemysize;
        }
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
    public float GetRatio(Collision col)
    {
        float enemysize = col.gameObject.GetComponent<EnemyController>().GetSize();
        float difference = playerSize.GetSize() - enemysize;
        if (enemysize < 1)
        {
            return ratio = playerSize.GetSize() / enemysize;
        }
        else if (difference < 1)
        {
            return ratio = playerSize.GetSize() + difference;
        }
        else
        {
            return ratio = playerSize.GetSize() / enemysize;
        }
        
    }
    public float ScaleSizeSmall(Collision col)
    {
       return size = size * (float)Math.Sqrt((double)GetRatio(col));
    }
    public float ScaleMediumSize(Collision col)
    {
        float difference = playerSize.GetSize() - EnemySize;
        Debug.Log("Size of the player :" + GetSize());
        if (difference < 1)
        {
            size = size / (float)Math.Sqrt((double)GetRatio(col));
        }
        else if(difference > 1)
        {
            size = size + (float)Math.Sqrt((double)GetRatio(col));
        }
        Debug.Log("ratio : " + ratio);
        Debug.Log("size - " + size);
        return size;
    }
    public float ScaleBigSize(Collision col)
    {
        size = size * (float)Math.Sqrt((double)GetRatio(col));
        Debug.Log("ratio : " + GetRatio(col));
        Debug.Log("size : " + size);
        return size;
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            float col_obj_size = col.gameObject.GetComponent<EnemyController>().GetSize();
            if (col_obj_size < playerSize.GetSize())
            {
                Debug.Log("collision with:" + col.gameObject.name);
                col.gameObject.SetActive(false);

                Debug.Log("" + col_obj_size + " < playersize");
                if (col_obj_size < 1)
                {
                    //ratio = playerSize.GetSize() * col.gameObject.GetComponent<EnemyController>().GetSize();
                    GetRatio(col);
                    Debug.Log("ratio : " + GetRatio(col));
                    ScaleSizeSmall(col);
                    //size = size / (float)Math.Sqrt((double)GetRatio(col));

                    Debug.Log("size after scale : " + Math.Log(ratio));
                }
                if(col_obj_size >= 1)
                {
                    if(col_obj_size < 5)
                    {
                        GetRatio(col);
                        Debug.Log("ratio : " + GetRatio(col));
                        ScaleMediumSize(col);
                    }
                }
                if (col_obj_size > 5)
                {
                    GetRatio(col);
                    ScaleBigSize(col);
                }
            }
        }
    }
}
