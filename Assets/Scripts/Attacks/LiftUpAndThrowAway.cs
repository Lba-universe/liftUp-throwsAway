using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftUpAndThrowAway : MonoBehaviour
{

    public Transform OtherPlayer;
    public float Throwing_force = 100;
    private GameObject ThPlayer;
    bool lifted = false;

    // Start is called before the first frame update
    void OnCollisionEnter(Collision o)
    {
        if (o.gameObject.tag == "RedDragon" || o.gameObject.tag == "Player")
        {
            ThPlayer = o.gameObject;
            if (!lifted && Input.GetKey(KeyCode.R) && !ThPlayer.GetComponentInChildren<PushForce>().Lift)
            {
                GetComponent<Rigidbody>().useGravity = false;
                this.gameObject.GetComponent<PushForce>().enabled = false;
                this.gameObject.GetComponent<EnemyMovement>().enabled = false;
                GetComponent<Rigidbody>().isKinematic = true;
                GetComponent<PushForce>().enabled = false;
                this.transform.rotation = OtherPlayer.rotation;
                this.transform.position = OtherPlayer.position;
                this.transform.parent = GameObject.Find("Me").transform;
                lifted = true;
                ThPlayer.GetComponentInChildren<PushForce>().Lift = true;
            }

          }
            
        }

    private void Update()
    {
        if (lifted)
        this.transform.rotation = OtherPlayer.rotation;
        if (lifted && Input.GetKey(KeyCode.F))
        {
            this.transform.parent = null;
            this.gameObject.GetComponent<PushForce>().enabled = true;
            this.gameObject.GetComponent<EnemyMovement>().enabled = true;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().AddRelativeForce(ThPlayer.GetComponent<Rigidbody>().velocity * Throwing_force);
            lifted = false;
            GetComponent<PushForce>().enabled = true;
            ThPlayer.GetComponentInChildren<PushForce>().Lift = false;
        }
    }

}
