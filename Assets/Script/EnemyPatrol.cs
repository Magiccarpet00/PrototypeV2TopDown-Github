using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;    
    public bool stopMove;
    public float timeSuperMove;

    public Animator animator;

    public Transform[] waypoints;

    private Transform target;
    private int destPoint = 0;

    public Transform superTarget;

    void Start()
    {
        target = waypoints[0];

        
    }

    void Update()
    {
        if(stopMove == false)
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.fixedDeltaTime, Space.World);
        }      


        // Si l'ennemi est quasiment ariver à destination 
        if(Vector3.Distance(transform.position, target.position) < 0.01f)
        {
            //Essaye Super Target-------------------------------------------------------------------------
            if (Vector3.Distance(transform.position, superTarget.position) < 0.01f && superTarget != null)
            {
                StartCoroutine(SuperMove());
            }
            //---------------------------------------------------------------------------------------------

            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];

        }
    }

    public IEnumerator SuperMove()
    {        
        stopMove = true;
        animator.SetTrigger("StartSuperMove");
        yield return new WaitForSeconds(timeSuperMove);
        animator.SetTrigger("EndSuperMove");
        stopMove = false;
    }    
}
