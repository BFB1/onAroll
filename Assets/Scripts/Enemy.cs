using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Einfaldur klasi. Fer í áttina að óvininum. Deyr þegar hann rekst á byssukúlur eða spilaran.
    
    public Transform target;
    private Rigidbody m_Rb;
    
    // Start is called before the first frame update
    private void Start()
    {
        m_Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        m_Rb.AddForce(direction * 10);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameManager.instance.EnemySlain(this);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.EndGame();
        }
    }
}