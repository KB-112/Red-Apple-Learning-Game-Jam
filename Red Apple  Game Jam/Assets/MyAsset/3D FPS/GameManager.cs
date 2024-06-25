using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public MenuComponent menuComponent;
    public PlayerComponents playerComponents;
    public EnemyComponents enemyComponents;
    public SoundComponents soundComponents;
}

[System.Serializable]
public class PlayerComponents
{
    public GameObject player;

    public float playerSpeed ;
    public float playerJumpSpeed;
    public float playerGravity;
    public float rotationSpeed ;

    public float playerHealth;
    public float playerGetDamage;
    public float playerCanDamage;
    public Slider playerHealthSlider;


    public PlayerComponents(GameObject player, float playerSpeed, float playerJumpSpeed, float playerGravity, float rotationSpeed, float playerHealth, float playerGetDamage, float playerCanDamage, Slider playerHealthSlider)
    {
        this.player = player;
        this.playerSpeed = playerSpeed;
        this.playerJumpSpeed = playerJumpSpeed;
        this.playerGravity = playerGravity;
        this.rotationSpeed = rotationSpeed;
        this.playerHealth = playerHealth;
        this.playerGetDamage = playerGetDamage;
        this.playerCanDamage = playerCanDamage;
        this.playerHealthSlider = playerHealthSlider;
    }
}

[System.Serializable]
public class EnemyComponents
{
    public float enemySpeed;
    public float enemyRotSpeed;
    public float enemyHealth;
    public float enemyGetDamage;
    public float enemyCanDamage;

    public GameObject enemyPrefab;
    public float prefabSpawnTime;

    public EnemyComponents(float enemySpeed, float enemyRotSpeed, float enemyHealth, float enemyGetDamage, float enemyCanDamage, GameObject enemyPrefab, float prefabSpawnTime)
    {
        this.enemySpeed = enemySpeed;
        this.enemyRotSpeed = enemyRotSpeed;
        this.enemyHealth = enemyHealth;
        this.enemyGetDamage = enemyGetDamage;
        this.enemyCanDamage = enemyCanDamage;
        this.enemyPrefab = enemyPrefab;
        this.prefabSpawnTime = prefabSpawnTime;
    }
}

[System.Serializable]
public class SoundComponents
{
    public AudioSource playerGetDamage;
    public AudioSource enemyGetDamage;

    public SoundComponents(AudioSource playerGetDamage, AudioSource enemyGetDamage)
    {
        this.playerGetDamage = playerGetDamage;
        this.enemyGetDamage = enemyGetDamage;
    }
}

[System.Serializable]
public class MenuComponent
{
    public GameObject[] menuandGameOver;
    public GameObject[] buttonsObj;
    public Button[] buttons;
    public bool StartGame = true;

    public MenuComponent(GameObject[] menuandGameOver, GameObject[] buttonsObj, Button[] buttons)
    {
        this.menuandGameOver = menuandGameOver;
        this.buttonsObj = buttonsObj;
        this.buttons = buttons;
    }
}
