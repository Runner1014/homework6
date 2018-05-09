using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolController : MonoBehaviour
{
    public List<Vector3> path;
    private int currentNode = 0;
    private int speed = 4;
    private Rigidbody rb;
    private Animator ani;
    public delegate void hitPlayer();
    public delegate void Score();
    public static event hitPlayer hitPlayerEvent;
    public static event Score scoreEvent;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
        setPath();
    }

    void FixedUpdate()
    {
        Vector3 target = path[currentNode];
        Vector3 V = target - transform.position;
        V = V.normalized;
        Quaternion rotation = Quaternion.LookRotation(V, Vector3.up);
        //transform.rotation = rotation;
        //rb.velocity = new Vector3(V.x, 0, V.z) * speed;
        if (Vector3.Distance(transform.position, target) < 0.1)
        {
            currentNode = (currentNode + 1) % path.Count;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "monster")
        {
            currentNode = (currentNode + 1) % path.Count;
        }
        if (other.gameObject.tag == "Walls")
        {
            setPath();
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            ani.SetTrigger("attack");
            if (hitPlayerEvent != null)
            {
                hitPlayerEvent();
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            path.Clear();
            path.Add(other.gameObject.transform.position);
            ani.SetBool("run", true);
            speed = 6;
            currentNode = 0;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            setPath();
            ani.SetBool("run", false);
            speed = 4;
            if (scoreEvent != null)
            {
                scoreEvent();
            }
        }
    }

    private void setPath()
    {
        path.Clear();
        System.Random ran = new System.Random();
        int length = ran.Next(10, 15);
        Vector3 right = new Vector3(transform.right.x, 0, transform.right.z).normalized;
        Vector3 forward = new Vector3(transform.forward.x, 0, transform.forward.z).normalized;
        Vector3 pos = transform.position - forward * 2;
        path.Add(pos);
        path.Add(pos + right * length);
        path.Add(pos - forward * length + right * length);
        path.Add(pos - forward * length);
        currentNode = 0;
    }
}