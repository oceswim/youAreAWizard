using UnityEngine;
using System.Collections;

namespace Pathfinding
{
    /// <summary>
    /// Simple patrol behavior.
    /// This will set the destination on the agent so that it moves through the sequence of objects in the <see cref="targets"/> array.
    /// Upon reaching a target it will wait for <see cref="delay"/> seconds.
    ///
    /// See: <see cref="Pathfinding.AIDestinationSetter"/>
    /// See: <see cref="Pathfinding.AIPath"/>
    /// 
    /// See: <see cref="Pathfinding.AILerp"/>
    /// </summary>
    [UniqueComponent(tag = "ai.destination")]
    [HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_patrol.php")]
    public class Patrol : VersionedMonoBehaviour
    {
        /// <summary>Target points to move to in order</summary>
        public Transform[] targets;
        public Transform attackSpot;
        public static bool hasArrived;
        private int single;
        /// <summary>Time in seconds to wait at each target</summary>
        public float delay = 0;

        /// <summary>Current target index</summary>
        int index;

        IAstarAI agent;
        float switchTime = float.PositiveInfinity;

        protected override void Awake()
        {
            single = 0;
            base.Awake();
            agent = GetComponent<IAstarAI>();
        }

        
        void Update()
        {
            if (targets.Length == 0) return;

            bool search = false;

            // Note: using reachedEndOfPath and pathPending instead of reachedDestination here because
            // if the destination cannot be reached by the agent, we don't want it to get stuck, we just want it to get as close as possible and then move on.
            if (!CTRLBoss.playerSpotted)
            {
                if (agent.reachedEndOfPath && !agent.pathPending && float.IsPositiveInfinity(switchTime))
                {
                    switchTime = Time.time + delay;
                }

                if (Time.time >= switchTime)
                {
                    index = index + 1;
                    search = true;
                    switchTime = float.PositiveInfinity;
                }

                index %= targets.Length;
                agent.destination = targets[index].position;

                if (search) agent.SearchPath();
            }
            else
            {
                if (true)
                {
                    if (single == 0)
                    {
                        single++;
                        agent.isStopped = true;
                    }
                    if (!hasArrived)
                    {
                        Debug.Log("going to attack spot");
                        if (agent.reachedEndOfPath && !agent.pathPending && float.IsPositiveInfinity(switchTime))
                        {
                            single = 0;
                            hasArrived = true;
                        }

                        if (Time.time >= switchTime)
                        {
                            search = true;
                            switchTime = float.PositiveInfinity;
                        }
                        if(single==1)
                        {
                            single++;
                            agent.isStopped = false;
                        }
                        agent.destination = attackSpot.position;

                        if (search) agent.SearchPath();
                     
                    }
             
                }
                else
                {
                }
            }
        }

        void goToNewTarget()
        {
            bool search = false;
            float diff1= Mathf.Abs(targets[0].position.magnitude - transform.position.magnitude);
            int theIndex = 0;
            foreach(Transform t in targets)
            {
                float diff = Mathf.Abs(t.position.magnitude - transform.position.magnitude);
                if (diff < diff1)
                { 
                    theIndex++;
                }
            }

            if (agent.reachedEndOfPath && !agent.pathPending && float.IsPositiveInfinity(switchTime))
            {
              
                Debug.Log("i'm done fleeing");
                single = 0;
               
                hasArrived = true;
            }

            if (Time.time >= switchTime)
            {
                search = true;
                switchTime = float.PositiveInfinity;
            }
            if (single == 2)
            {
                single++;
                agent.isStopped = false;
            }
            agent.destination = targets[theIndex].position;
            Debug.Log("going to" + agent.destination);

            if (search) agent.SearchPath();
        
        }
    }
}
