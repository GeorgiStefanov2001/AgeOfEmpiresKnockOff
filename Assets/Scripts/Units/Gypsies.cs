using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Gypsies : MonoBehaviour {

    public bool interacted = false;
    float maxDist = 100.0f;
    bool walking = true;
    public float angularSpeed;
    public float speed;
    public float acceleration;
    int p = -2;

    NavMeshAgent agent;
    GameObject gypsie;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        agent.angularSpeed = angularSpeed;
        agent.acceleration = acceleration;
    }

    void MakeGypsie()
    {
        if (GameObject.Find("Town Hall").GetComponent<TownHall>().takenOut)
        {
            gypsie = Instantiate(gameObject, GameObject.FindGameObjectWithTag("Terrain").transform);
            GameObject.Find("Town Hall").GetComponent<TownHall>().takenOut = false;
        }
    }

    void Update() {
        if (interacted)
        {
            Move();
        }
        MakeGypsie();
        UnIntreract();
    }

    void Move() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(ray, out hit, maxDist))
            {
                walking = true;
                agent.destination = hit.point;

            }
        }

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            walking = false;

        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            interacted = true;
        }
    }

    void UnIntreract()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDist))
        {
            if (Input.GetMouseButtonDown(0) && hit.transform.gameObject != gameObject && interacted)
            {
                interacted = false;
            }
        }
    }
}
