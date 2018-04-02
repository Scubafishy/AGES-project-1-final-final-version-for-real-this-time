using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileExplode : MonoBehaviour
{

    public LayerMask m_TankMask;                        // Used to filter what the explosion affects, this should be set to "Players".
    public ParticleSystem m_ExplosionParticles;         // Reference to the particles that will play on explosion.
    public AudioSource m_ExplosionAudio;                // Reference to the audio that will play on explosion.
    public float m_MaxDamage = 100f;                    // The amount of damage done if the explosion is centred on a tank.
    public float m_ExplosionForce = 100f;              // The amount of force added to a tank at the centre of the explosion.
    public float m_MaxLifeTime = 2f;                    // The time in seconds before the shell is removed.
    public float m_ExplosionRadius = 1f;                // The maximum distance away from the explosion tanks can be and are still affected.

   

    private void Start()
    {
        // If it isn't destroyed by then, destroy the shell after it's lifetime.
        Destroy(gameObject, m_MaxLifeTime);
    }
    private void Update()
    {
        

       
        
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    // Collect all the colliders in a sphere from the shell's current position to a radius of the explosion radius.
    //    Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius, m_TankMask);

    //    // Go through all the colliders...
    //    for (int i = 0; i < colliders.Length; i++)
    //    {
    //        Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();


    //        //targetRigidbody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);


    //        if (!targetRigidbody)
    //            continue;

    //        SubMovment targetHealth = targetRigidbody.GetComponent<SubMovment>();

    //        if (!targetHealth)
    //            continue;

    //        //SubStun.Stunned = true;


    //        Debug.Log("I hit");
    //    }

    //    //Unparent the particles from the shell.
    //      m_ExplosionParticles.transform.parent = null;

    //    //Play the particle system.
    //     m_ExplosionParticles.Play();

    //    //Play the explosion sound effect.
    //     m_ExplosionAudio.Play();

    //    //Once the particles have finished, destroy the gameobject they are on.
    //     ParticleSystem.MainModule mainModule = m_ExplosionParticles.main;
    //    Destroy(m_ExplosionParticles.gameObject, mainModule.duration);

    //    // Destroy the shell.
    //    Destroy(gameObject);
    //}


    private void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius, m_TankMask);
        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody targetRidgidbody = colliders[i].GetComponent<Rigidbody>();

            if (!targetRidgidbody)
                continue;

            //targetRidgidbody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);

            SubMovment targetHealth = targetRidgidbody.GetComponent<SubMovment>();

            if (!targetHealth)
                continue;


            targetHealth.Hit();

            //Unparent the particles from the shell.
            m_ExplosionParticles.transform.parent = null;

            //Play the particle system.
            m_ExplosionParticles.Play();

            //Play the explosion sound effect.
            m_ExplosionAudio.Play();

            //Once the particles have finished, destroy the gameobject they are on.
            ParticleSystem.MainModule mainModule = m_ExplosionParticles.main;
            Destroy(m_ExplosionParticles.gameObject, mainModule.duration);

            Destroy(gameObject);
        }

    }



    //private void OnTriggerEnter(Collider other)
    //{
    //    if (GameObject.FindGameObjectWithTag("Player"))
    //    {
    //        Debug.Log("I hit");
    //        SubStun.Stunned = true;
    //        Destroy(gameObject);
    //    }
    //}
}
