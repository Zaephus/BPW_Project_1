using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public int damage = 5;
    public float range = 100;
    public float speed = 10;

    private Vector3 startPos;

    public void Start() {
        startPos = transform.position;
    }

    public void Update() {
        transform.position += transform.forward * speed * Time.deltaTime;

        if(Vector3.Distance(startPos,transform.position) >= range) {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter(Collider other) {
        if(other.GetComponent<IDamageable>() != null) {
            other.GetComponent<IDamageable>().TakeDamage(damage);
        }
        Destroy(this.gameObject);
    }

}