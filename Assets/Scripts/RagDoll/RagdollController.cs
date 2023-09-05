using System;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    public Animator Animator;
    public Rigidbody[] AllRigidbodys;

    private void Awake()
    {
        for (int i = 0; i < AllRigidbodys.Length; i++)
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
            AllRigidbodys[i].isKinematic = true;
            AllRigidbodys[i].GetComponent<Collider>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            //Makephysical();
        }  
    }

    public void Makephysical()
    {
        Animator.enabled = false;
        for (int i =0; i < AllRigidbodys.Length;i++)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            AllRigidbodys[i].isKinematic = false;
            AllRigidbodys[i].GetComponent<Collider>().enabled = true;
        }
    }
}
