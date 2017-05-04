﻿//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class SpinnerTowerAttack : MonoBehaviour
//{
//    [Header("Attributes")]
//    public float slowRate = 0.5f;
//    public float attackRadius = 20f;      // Turret attack range
//    public float attackPulseRate = 1f;    // Rate that the laser ticks.
//    public float slowDuration = 3f;       // Duration of the slow debuff
//    public GameObject slowEffectPrefab;
//
//    private ParticleSystem areaEffectParticles;
//    GameObject enemy;
//    EnemyMovement enemyMovement;
//    // EnemyHealth enemyHealth;            // Enemy's health
//
//    float timer;
//    bool enemiesInRange;    
//	bool pulseOn;
//
//    void Awake ()
//    {	
//        areaEffectParticles = Instantiate(slowEffectPrefab).GetComponent<ParticleSystem> ();
//        areaEffectParticles.gameObject.SetActive (false);
//
//        enemiesInRange = false;
//        InvokeRepeating("ScanForEnemies", 0 , 0.5f);
//		areaEffectParticles.transform.position = transform.position;
//		areaEffectParticles.gameObject.SetActive (true);
//		areaEffectParticles.Play ();
//    }
//	void Start()
//	{
//		InvokeRepeating ("Pulse", 0f, 5f);
//	}
//
//    void Update ()
//    {
//        if (enemiesInRange)
//        {
//			pulseOn = true;
//        } else
//        {
//			pulseOn = false;
//            ScanForEnemies ();
//        }
//    }
//
//    void Pulse ()
//    {
//		if (pulseOn) {
//			
//
//			// Check the tower's radius for ALL enemies within range
//			Collider[] colliders = Physics.OverlapSphere (transform.position, attackRadius);
//			foreach (Collider collider in colliders) {
//				if (collider.CompareTag ("Enemy")) {
//					enemyMovement = collider.GetComponent<EnemyMovement> ();
//					enemyMovement.Slow (slowRate, slowDuration);
//				}
//			}
//		}
//    }
//
//    void ScanForEnemies ()
//    {
//        // Check the tower's radius for enemies within range
//        Collider[] colliders = Physics.OverlapSphere (transform.position, attackRadius);
//        foreach (Collider collider in colliders)
//        {
//          if (collider.CompareTag("Enemy"))
//          {	
////            Debug.Log ("Enemy detected!");
//            enemiesInRange = true;
//            break;
//          }
//        }
//        if (enemiesInRange)
//        {
//            return;
//        }
//        enemiesInRange = false;
//    }
//
//    void OnDrawGizmos()
//    {
//        Gizmos.color = Color.cyan; 
//        Gizmos.DrawWireSphere (transform.position, attackRadius);
//    }
//}