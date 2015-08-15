using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
    public float size = 0.3f;
    private Vector3 originalScale;

    void Start()
	{
       originalScale = transform.localScale;
	}

    public float GetSize()
    {
        return size;
    }
	
	void Update()
	{
        transform.localScale = originalScale * size;
	}

    public void OnCollisonEnter(Collision col)
    {
       
    }
}
