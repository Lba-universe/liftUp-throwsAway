using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushForce : MonoBehaviour
{

    private Vector3 velocty;
    private Rigidbody rb;
    public bool Lift;
    private Transform tf;
    [SerializeField]
    private ForceMode forcemode;
    [SerializeField]
    private float ForceLevel = 15;


    // Start is called before the first frame update
    void Start()
    {
        
        rb = gameObject.GetComponent<Rigidbody>();
        tf = gameObject.GetComponent<Transform>();
        Lift= false;
    }


    void OnCollisionEnter(Collision other)
    {
        
        if (enabled && (other.gameObject.tag == "Player" || other.gameObject.tag == "RedDragon" || other.gameObject.tag == "Enemy"))
        {
            other.rigidbody.AddForce(transform.forward* ForceLevel, forcemode);
        }
    }

}
