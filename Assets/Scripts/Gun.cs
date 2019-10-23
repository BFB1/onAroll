using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bullet;
    public Transform bulletSpawnPoint;
    private float m_FireInterval = 0;

    // Update is called once per frame
    private void Update()
    {
        if ((Input.GetKey(KeyCode.F) || Input.GetKey(KeyCode.Mouse0)) && m_FireInterval >= .25f)
        {
            Transform projectile = Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            projectile.GetComponent<Rigidbody>().AddForce(transform.forward * 100, ForceMode.Impulse);
            m_FireInterval = 0;
        }

        m_FireInterval += Time.deltaTime;
    }
}
