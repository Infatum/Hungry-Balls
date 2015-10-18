using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class EnemyAI : BaseLogic {

    public float patrolSpeed = 2f;
    public float chaseSpeed = 5f;
    public float chaseWaitTime = 5f;
    public float patrolWaitTime = 1f;
    public Transform[] patrolWayPoints;

    private float AgrChance;

	// Use this for initialization
	void Start()
	{
	    
	}

    void OnCollisionStay(Collision colisionObjects)
    {
        
    }

    
	
	// Update is called once per frame
	void Update()
	{
	
	}
}
