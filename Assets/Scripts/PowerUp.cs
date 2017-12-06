using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    enum PowerUpEffects : int { Giant, Mouse, HighDamage, HighSpeed, IronManFlight};
    enum PowerUpTimers : int { Giant=10, Mouse=10, HighDamage=20, HighSpeed=20, IronManFlight=30};

    public GameObject pickupEffect;

    private GameObject player;

    private float timer;

    private float _powerUpTimer = 0;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            player = other.gameObject;
            PickUp();
        }

        timer += Time.deltaTime;
        if(timer >= _powerUpTimer)
        {
            DetachPowerUpEffectFromPlayer();
            timer = 0f;
        }
    }

    void PickUp()
    {
        Debug.Log("PowerUp picked up!");

        // Spawn cool effect
        Instantiate(pickupEffect, transform.position, transform.rotation);

        // Apply effect to the palyer
        ApplyPowerUpEffectOnPlayer((int) PowerUpEffects.Giant, (float) PowerUpTimers.Giant);

        // Remove PowerUp object
        Destroy(gameObject);
    }

    private void ApplyPowerUpEffectOnPlayer(int effect, float powerUpTimer)
    {
        // template power growth
        Debug.Log("Massive Hulk now!!!");
        _powerUpTimer = powerUpTimer;
        player.GetComponent<MeshRenderer>().material.color = Color.green;
        player.transform.localScale += Vector3.one*2.5f;
    }

    private void DetachPowerUpEffectFromPlayer()
    {
        // undo hulkmodus
        Debug.Log("Dr. Benner again!!!");
        player.GetComponent<MeshRenderer>().material.color = Color.white;
        player.transform.localScale = Vector3.one;
    }
}
