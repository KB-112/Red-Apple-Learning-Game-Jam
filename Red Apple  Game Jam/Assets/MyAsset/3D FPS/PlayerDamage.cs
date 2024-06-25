using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private void Start()
    {
        Initialization();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter");
        if (other.CompareTag("DamageDealer"))
        {
            PlayerDamageTaken();
        }
    }

    void PlayerDamageTaken()
    {
        if (Player().playerHealth > 0)
        {
            Player().playerHealth -= Player().playerGetDamage;
            Player().playerHealthSlider.value = Player().playerHealth;
            GameManager.Instance.soundComponents.playerGetDamage.Play();

            if (Player().playerHealth <= 0)
            {
                GameOver(true);
               
            }
        }
    }

    void Initialization()
    {
        Player().playerHealth = 10f;
        Player().playerHealthSlider.maxValue = Player().playerHealth;
        Player().playerGetDamage = 1f;
    }

    public PlayerComponents Player()
    {
        return GameManager.Instance.playerComponents;
    }

    void GameOver(bool state)
    {
        var inst = GameManager.Instance.menuComponent;

        inst.menuandGameOver[0].SetActive(state);
        inst.menuandGameOver[2].SetActive(state);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.CompareTag("DamageDealer"))
        {
            Vector3 direction = transform.position - collision.transform.position;
            direction.y = 0;
            collision.transform.position += direction.normalized * 0.1f;
        }
    }
}
