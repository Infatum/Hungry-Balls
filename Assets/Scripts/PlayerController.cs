using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    private Rigidbody rb;
    private int score = 0;
    private Text gameOver;
    public float size = 1f;
    public Vector3 originalScale;
    private PlayerController playerSize;

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
        if (col.gameObject.CompareTag("Enemy") && col.gameObject.GetComponent<EnemyController>().GetSize() < playerSize.GetSize())
        {
            Debug.Log("Collision with small enemy");
            col.gameObject.SetActive(false);
            size = col.gameObject.GetComponent<EnemyController>().GetSize() + playerSize.GetSize() / 2;
        }
    }
}
