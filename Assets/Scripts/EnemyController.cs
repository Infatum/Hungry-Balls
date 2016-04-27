using UnityEngine;
using System.Collections.Generic;
using System;
using Assets.Scripts;

public class EnemyController : BaseLogic
{
    public float targetDistance;
    public System.Random rand = new System.Random();

    private Rigidbody rigid;
    private PlayerController enemy;
    private Transform enemyPosition;
    private Vector3 originalScale;
    private GameObject target = null;
    private EnemyAI enemyBrain;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        originalScale = transform.localScale;
        enemy = gameObject.GetComponent<PlayerController>();
    }

    void Awake()
    {
        target = null;
        enemyPosition = transform;
        enemyBrain = gameObject.GetComponent<EnemyAI>();
    }

    void OnCollisionEnter(Collision col)
    {

    }

    public void StartFollow()
    {
        target = enemyBrain.Victims.Values[0];
        enemyPosition.position += enemyPosition.forward * speed * Time.deltaTime;
    }

    void Update()
    {
        transform.localScale = originalScale * size;
        enemyPosition.position += enemyPosition.forward * speed * Time.deltaTime;
        if (target)
        {
            targetDistance = Vector3.Distance(gameObject.transform.position, target.transform.position);
        }

        if (enemyBrain.Victims.Count == 10)
        {
            StartFollow();
        }
        else
        {

        }
    }
}



class Ololo : MonoBehaviour
{
    Transform target; 
    int moveSpeed = 3;
    int rotationSpeed = 3;
    Transform myTransform; 
 
 void Awake()
    {
        myTransform = transform;
    }
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation,

        Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);

        myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
    }

}