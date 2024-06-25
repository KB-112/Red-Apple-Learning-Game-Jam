using UnityEngine;
using UnityEngine.Events;


public class Layout : MonoBehaviour
{
    public enum PlayerType {None , Worrior , Wizard,Archer,Rogue }
    public PlayerType playerType;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    [SerializeField] private float jumpHeight;
    public bool canJump;

    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth;

    [SerializeField] private float currenxtMana;
    [SerializeField] private float maxMana;
    [SerializeField] private int spellDamage;

    [SerializeField] private float currentStamina;
    [SerializeField] private float maxStamina;
    [SerializeField] private int swordDamage;

    [SerializeField] private UnityEvent deathEvent;
}
