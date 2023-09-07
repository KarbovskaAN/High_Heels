using System;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    [SerializeField ]private Animator Animator;
    [SerializeField] private Rigidbody[] AllRigidbodys;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private MediatorUi _mediator;
    

    private List<GameObject> _listCollader;

    private void Awake()
    {
        for (int i = 0; i < AllRigidbodys.Length; i++)
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
            AllRigidbodys[i].isKinematic = true;
            AllRigidbodys[i].GetComponent<Collider>().enabled = false;
        }
    }

    private void Start()
    {
        _listCollader = gameObject.GetComponent<CollectShoes>()._colliderShoesList;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle") && _listCollader.Count == 0)
        {
            Makephysical();
            _mediator.PanelLost();
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
            _rigidbody.velocity = new Vector3(0, 0, 0);
        }
    }
}
