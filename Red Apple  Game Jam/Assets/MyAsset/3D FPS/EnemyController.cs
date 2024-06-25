using System.Collections;
using UnityEngine;




public class EnemyController : MonoBehaviour
{






    void Update()
    {
        Vector3 targetPosition = Player().player.transform.position;
        targetPosition.y = transform.position.y; 

        transform.rotation = Quaternion.Slerp(transform.rotation,
                                              Quaternion.LookRotation(targetPosition - transform.position),
                                              Enemy().enemyRotSpeed * Time.deltaTime);

        transform.position += transform.forward * Enemy().enemySpeed * Time.deltaTime;
    }


    public PlayerComponents Player()
    {
        return GameManager.Instance.playerComponents;
    }

    public EnemyComponents Enemy()
    {
        return GameManager.Instance.enemyComponents;
    }

   
}