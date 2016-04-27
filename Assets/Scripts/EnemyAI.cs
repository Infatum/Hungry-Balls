using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;

public class EnemyAI : BaseLogic
{
    [SerializeField]
    private float patrolSpeed = 2f;
    [SerializeField]
    private float chaseSpeed = 5f;
    [SerializeField]
    private float chaseWaitTime = 5f;
    [SerializeField]
    private float patrolWaitTime = 1f;

    private SortedList<float, GameObject> victims = null;
    private float agrChance;
    private float distance;
    private float agrZone;

    /// <summary>
    /// Returns the Sorted List of potential targets
    /// </summary>
    public SortedList<float, GameObject> Victims
    {
        get { return victims; }
    }

    /// <summary>
    /// 
    /// </summary>
    void Start()
	{
        victims = new SortedList<float, GameObject>();
	}
    /// <summary>
    /// TODO
    /// </summary>
    public float AttackZone
    {
        get { return agrZone; } 
    }

    /// <summary>
    /// Returns a distance between an enemy and the potential victim 
    /// </summary>
    public float TargetDistance
    {
        get { return distance; }
    }

    /// <summary>
    /// Adds new victims to the Collection of victims
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision)
    {
        //TODO
    }

    /// <summary>
    /// Calculates the AgrChance for an each target 
    /// </summary>
    /// <param name="agrZonetion"></param>
    /// <param name="victim"></param>
    /// <returns></returns>
    public float AgrChance(int agrZonetion, BaseLogic victim )
    {
        switch (agrZonetion)
        {
            case 1:
                agrChance = Random.Range(30, 45) + SizeRatio(victim);
                break;
            case 2:
                agrChance = Random.Range(10, 20) + SizeRatio(victim);
                break;
            case 3:
                agrChance = Random.Range(2, 8) + SizeRatio(victim);
                break;
            default:
                agrChance = 0;
                break;
        }
        return agrChance;
    }
    /// <summary>
    /// All the gameobjects that hit collider are cheked for their size needed to be smaller then the enemy size
    /// Then adding all gameobjects with smaller size to the enemy's potential victims Sorted List
    /// </summary>
    /// <param name="colisionObject"></param>
    void OnCollisionStay(Collision colisionObject)
    {
        SphereCollider col = (SphereCollider)colisionObject.collider;
        var enemyPosition = col.gameObject.transform.position;
        var targetPosition = colisionObject.transform.position;
        var targetBaseLogic = colisionObject.gameObject.GetComponent<BaseLogic>();
        
        if(victims.Count < 10)
        {
            var distance = Vector3.Distance(enemyPosition, targetPosition);
            float agrZone = distance / col.radius; 

            if (agrZone < 0.8)
            {
                victims.Add(AgrChance(1, targetBaseLogic), colisionObject.gameObject);
            }
            if (agrZone < 0.5)
            {
                victims.Add(AgrChance(2, targetBaseLogic), colisionObject.gameObject);
            }
            else
            {
                victims.Add(AgrChance(3, targetBaseLogic), colisionObject.gameObject);
            }
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
        return ratio * 100;
    }
	
	// Update is called once per frame
	void Update()
	{
	    
	}
}
