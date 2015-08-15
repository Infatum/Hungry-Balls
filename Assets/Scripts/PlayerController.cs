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

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        score = 0;
        originalScale = transform.localScale;
        playerSize = gameObject.GetComponent<PlayerController>();
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

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            float col_obj_size = col.gameObject.GetComponent<EnemyController>().GetSize();
            if (col_obj_size < playerSize.GetSize())
            {
                Debug.Log("collision with:" + col.gameObject.name);
                col.gameObject.SetActive(false);

                Debug.Log("" + col_obj_size + " < 1");
                if (col_obj_size < gameObject.GetComponent<PlayerController>().GetSize())
                {
                    ratio = playerSize.GetSize() * col.gameObject.GetComponent<EnemyController>().GetSize();
                    Debug.Log("ratio : " + ratio);
                    size = size / (float)Math.Sqrt((double)ratio);
                    Debug.Log("size" + Math.Log(ratio));
                }
            }
        }
    }
}
