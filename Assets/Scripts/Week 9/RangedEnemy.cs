using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{

    public int barkPrefab;

    public Transform barkSpawnPosition;

    public float barkForce = 500f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        this.transform.LookAt(player.transform.position);
        base.Update();
    }   

    protected override void Attack()
    {
        GameObject go = Instantiate(barkPrefab, barkSpawnPosition.position, barkSpawnPosition.rotation);
    }
}
