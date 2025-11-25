using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public Transform destination;
    NavMeshAgent mAgent;
    Animator mAnimator;
     private bool mStarted = false;
     private bool mReached = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mAgent = gameObject.GetComponent<NavMeshAgent>();
        mAnimator = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    public void StartNavation()
    {
        mAgent.SetDestination(destination.position);
        mAnimator?.Play("walk");
        mStarted = true;
    }

    private void Update()
    {
        if (!mStarted) 
            return;

        if (mAgent && mAgent.enabled)
        {
            if (mAgent.remainingDistance <= mAgent.stoppingDistance)
            {
                mAgent.isStopped = true;
                mAgent.enabled = false;
                mReached = true;
            }
        }

        if (mReached)
        {
            var cols = Physics.OverlapSphere(destination.position, 0.4F);
            if (cols.Length > 0)
            {
                foreach (var col in cols)
                {
                    var house = col.GetComponentInParent<House>();
                    if (house != null)
                    {
                        transform.SetParent(house.transform);
                        transform.localPosition = house.ground.localPosition;
                        mAnimator?.Play("idle");
                        mReached = false;
                        Debug.Log("reach destination");
                        return;
                    }
                }
            }
        }
    }
}
