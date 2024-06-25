using UnityEditor;
using UnityEngine.Events;
using UnityEngine;
using Unity.VisualScripting;

[CustomEditor(typeof(Layout))]
public class PlayerController : Editor
{
    #region Serialized Property
  SerializedProperty playerType;
  SerializedProperty  walkSpeed;
  SerializedProperty  runSpeed;

  SerializedProperty jumpHeight;
  SerializedProperty canJump;

  SerializedProperty currentHealth;
  SerializedProperty maxHealth;

  SerializedProperty currenxtMana;
  SerializedProperty maxMana;
  SerializedProperty spellDamage;

  SerializedProperty currentStamina;
  SerializedProperty maxStamina;
  SerializedProperty swordDamage;

  SerializedProperty deathEvent;

    bool playerSpeedGroup ,playerJumpGroup,playerHealthGroup,
         playerDeathEvent,warriorGroup,wizardGroup= false;

    #endregion

    private void OnEnable()
    {
        playerType = serializedObject.FindProperty("playerType");
        walkSpeed = serializedObject.FindProperty("walkSpeed");
        runSpeed = serializedObject.FindProperty("runSpeed");

        jumpHeight = serializedObject.FindProperty("jumpHeight"); 
        canJump = serializedObject.FindProperty("canJump"); 

        currentHealth = serializedObject.FindProperty("currentHealth"); 
        maxHealth = serializedObject.FindProperty("maxHealth"); 

        currenxtMana = serializedObject.FindProperty("currenxtMana"); 
        maxMana = serializedObject.FindProperty("maxMana"); 
        spellDamage = serializedObject.FindProperty("spellDamage"); 

        currentStamina = serializedObject.FindProperty("currentStamina");
        maxStamina = serializedObject.FindProperty("maxStamina"); 
        swordDamage = serializedObject.FindProperty("swordDamage"); 

        deathEvent = serializedObject.FindProperty("deathEvent"); 
    }
    public override void OnInspectorGUI()
    {
        Layout layout = (Layout)target;
        serializedObject.Update();
        EditorGUILayout.PropertyField(playerType);

        if(layout.playerType == Layout.PlayerType.Worrior)
        {
            warriorGroup = EditorGUILayout.BeginFoldoutHeaderGroup(warriorGroup, "Warrior Group");
            if (warriorGroup)
            {
                EditorGUILayout.PropertyField(maxStamina);
                EditorGUILayout.PropertyField(currentStamina);
                EditorGUILayout.PropertyField(swordDamage);
            }
            EditorGUILayout.EndFoldoutHeaderGroup();

        }
        if (layout.playerType == Layout.PlayerType.Wizard)
        {
            wizardGroup = EditorGUILayout.BeginFoldoutHeaderGroup(wizardGroup, "Wizard Group");
            if (wizardGroup)
            {
                EditorGUILayout.PropertyField(maxMana);
                EditorGUILayout.PropertyField(currenxtMana);
                EditorGUILayout.PropertyField(spellDamage);
            }
            EditorGUILayout.EndFoldoutHeaderGroup();

        }




        EditorGUILayout.LabelField("Test");
        EditorGUILayout.Space(5);

        playerSpeedGroup = EditorGUILayout.BeginFoldoutHeaderGroup(playerSpeedGroup,"Player Speed Group");
        if(playerSpeedGroup)
        {
            EditorGUILayout.PropertyField(walkSpeed);
            EditorGUILayout.PropertyField(runSpeed);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        playerJumpGroup = EditorGUILayout.BeginFoldoutHeaderGroup(playerJumpGroup, "PlayerJumpGroup");
        if (playerJumpGroup)
        {
            
            EditorGUILayout.PropertyField(canJump);
            if (layout.canJump)
            {
                EditorGUILayout.PropertyField(jumpHeight);

            }

        }

        EditorGUILayout.EndFoldoutHeaderGroup();



        playerHealthGroup = EditorGUILayout.BeginFoldoutHeaderGroup(playerHealthGroup, "Player Health Group");
        if (playerHealthGroup)
        {
            EditorGUILayout.PropertyField(currentHealth);
            EditorGUILayout.PropertyField(maxHealth);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        playerDeathEvent = EditorGUILayout.BeginFoldoutHeaderGroup(playerDeathEvent, "Player Death Event");
        if (playerDeathEvent)
        {
            EditorGUILayout.PropertyField(deathEvent);
            
        }
        EditorGUILayout.EndFoldoutHeaderGroup();


        serializedObject.ApplyModifiedProperties();
    }
}
