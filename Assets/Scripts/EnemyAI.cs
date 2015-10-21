using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;

public class EnemyAI : BaseLogic {

    public float patrolSpeed = 2f;
    public float chaseSpeed = 5f;
    public float chaseWaitTime = 5f;
    public float patrolWaitTime = 1f;
    public Dictionary<float,BaseLogic> victims;

    private float AgrChance;

	// Use this for initialization
	void Start()
	{
	    victims = new Dictionary<float, BaseLogic>();
	}
    /// <summary>
    /// Adds new victims to the Collection of victims
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision)
    {
        //if (collision is BaseLogic)
        //victims.Add(AgrChance, collision);
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
        BaseLogic victimBaseLogic = colisionObject.gameObject.GetComponent<BaseLogic>();
        
        if (agrZone < 0.8)
        {
            
            victims = GameObject.FindObjectsOfType<BaseLogic>().ToDictionary(v => AgrChance = 
            Random.Range(2, 8) + SizeRatio(victimBaseLogic));

        }
        if (agrZone < 0.5)
        {
            AgrChance = Random.Range(10, 20) + SizeRatio(victimBaseLogic);
        }
        else
        {
            AgrChance = Random.Range(30, 45) + SizeRatio(victimBaseLogic);
        }

    }

    public void StartFollow(GameObject obj)
    {
        gameObject.GetComponent<EnemyController>().target = obj;
        
    }
    /// <summary>
    /// Sets the ratio for the enemy size and size of a victim
    /// </summary>
    /// <param name="victim"></param>
    /// <returns></returns>
    public float SizeRatio(BaseLogic victim)
    {
        float ratio = size/victim.size;
        return ratio * 100;
    }
	
	// Update is called once per frame
	void Update()
	{
	    
	}
}
