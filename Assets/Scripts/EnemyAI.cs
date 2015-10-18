using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts;

public class EnemyAI : BaseLogic {

    public float patrolSpeed = 2f;
    public float chaseSpeed = 5f;
    public float chaseWaitTime = 5f;
    public float patrolWaitTime = 1f;
    public Dictionary<float,Collision> victims;

    private float AgrChance;

	// Use this for initialization
	void Start()
	{
	    victims = new Dictionary<float, Collision>();
	}
    /// <summary>
    /// Adds new victims to the Collection of victims
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision)
    {
        if (collision is BaseLogic)
        victims.Add(AgrChance, collision);
    }
    /// <summary>
    /// Sets the agression zone in the enemy collider
    /// </summary>
    /// <param name="colisionObject"></param>
    void OnCollisionStay(Collision colisionObject)
    {
        SphereCollider col = (SphereCollider)colisionObject.collider;
        var distance = Vector3.Distance(col.gameObject.transform.position, colisionObject.transform.position);
        float agrZone = distance/col.radius;
        if (agrZone < 0.2)
        {
            AgrChance = Random.Range(5, 15);
        }
        if (agrZone < 0.5)
        {
            AgrChance = Random.Range(20, 40);
        }
        else
        {
            AgrChance = Random.Range(50, 80);
        }

    }
    /// <summary>
    /// Sets the ratio for the enemy size and size of a victim
    /// </summary>
    /// <param name="victim"></param>
    /// <returns></returns>
    public float SizeRatio(BaseLogic victim)
    {
        float ratio = size/victim.size;
        return ratio;
    }
	
	// Update is called once per frame
	void Update()
	{
	    
	}
}
