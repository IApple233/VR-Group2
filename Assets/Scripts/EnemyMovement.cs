using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public long startTime = 5;
    public Transform player;
    public GameObject ghost_0;
    public float moveTime_0;
    public GameObject ghost_1;
    public float moveTime_1;
    public GameObject ghost_2;
    public float moveTime_2;
    public GameObject ghost_3;
    public float moveTime_3;

    private Transform ghost_0_trans;
    private Transform ghost_1_trans;
    private Transform ghost_2_trans;
    private Transform ghost_3_trans;

    private NavMeshAgent ghost_0_nav;
    private NavMeshAgent ghost_1_nav;
    private NavMeshAgent ghost_2_nav;
    private NavMeshAgent ghost_3_nav;

    private float loadTime;
    private void Sleep(NavMeshAgent g)
    {
        g.updatePosition = false;
        g.updateRotation = false;
    }

    private void Move(Transform t, NavMeshAgent g, Vector3 destination)
    {
        g.updatePosition = true;
        g.updateRotation = true;
        g.SetDestination(destination);
        t.LookAt(destination);
    }
    private void Start()
    {
        loadTime = Time.time;
        ghost_0_trans = ghost_0.GetComponent<Transform>();
        ghost_1_trans = ghost_1.GetComponent<Transform>();
        ghost_2_trans = ghost_2.GetComponent<Transform>();
        ghost_3_trans = ghost_3.GetComponent<Transform>();
        ghost_0_nav = ghost_0.GetComponent<NavMeshAgent>();
        ghost_1_nav = ghost_1.GetComponent<NavMeshAgent>();
        ghost_2_nav = ghost_2.GetComponent<NavMeshAgent>();
        ghost_3_nav = ghost_3.GetComponent<NavMeshAgent>();
        Sleep(ghost_0_nav);
        Sleep(ghost_1_nav);
        Sleep(ghost_2_nav);
        Sleep(ghost_3_nav);
    }
    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        while (Time.time - loadTime < startTime) return;
        if (Time.time - loadTime > moveTime_0)
        {
            Move(ghost_0_trans, ghost_0_nav, player.position);
        }
        if (Time.time - loadTime > moveTime_1)
        {
            Move(ghost_1_trans, ghost_1_nav, player.position);
        }
        if (Time.time - loadTime > moveTime_2)
        {
            Move(ghost_2_trans, ghost_2_nav, player.position);
        }
        if (Time.time - loadTime > moveTime_3)
        {
            Move(ghost_3_trans, ghost_3_nav, player.position);
        }
    }
}
