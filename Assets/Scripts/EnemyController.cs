using UnityEngine;
using System.Collections;
using System;
using Assets.Scripts;

public class EnemyController : BaseLogic {
    Rigidbody rigid;
    private Vector3 originalScale;
    public GameObject target;
    public float targetDistance;
    public System.Random rand = new System.Random();
    private int chance;
    
    
    void Start()
	{
       rigid = GetComponent<Rigidbody>();
       originalScale = transform.localScale;
       chance = rand.Next(0, 100);
    }

    void Awake()
    {
        target = GameObject.FindWithTag("Player");
    }
    //void LateUpdate()
    //{
    //    transform.position = target.transform.position;
    //}

    void OnCollisionEnter(Collision col)
    {

    }
    public float GetSize()
    {
        return size;
    }
	
	void Update()
	{
        transform.localScale = originalScale * size;
        targetDistance = Vector3.Distance(gameObject.transform.position, target.transform.position);
	}
    public void OnTriggerEnter(Collider col)
    {
        //float horizontalFollow = transform.position
        SphereCollider scol = (SphereCollider)col;
        
        PlayerController target = gameObject.GetComponent<PlayerController>();
       if(col.gameObject.name == gameObject.GetComponent<EnemyController>().name)
        {
            if (targetDistance == scol.radius - scol.radius * 0.2)
            {
                if (chance < 25)
                {
                    //Vector3 follow = new Vector3(horizontalFollow, 0.0f, verticalFollow);
                    //rigid.AddForce()
                }
            }
        }
    }
}
