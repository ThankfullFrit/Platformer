using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    public Transform attackPos; //�ffentliche Variable die die Angriffs Position angibt
    public LayerMask enemies; //Schichtmaske der Gegner
    public float attackrange; //Angriffsradius wird definiert
    public int damage; //Schadensvariable

    private Animator anim; //private Animator-Variable wird definiert um beim Schlagen eine Animation durchzuf�hren

    
    void Start()
    {
        anim = GetComponent<Animator>(); //Animator wird aufgerufen
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //wenn die linke Maustaste gedr�ckt wird
        {
            anim.SetBool("IsAttacking", true); //wird "IsAttacking" auf wahr gesetzt und eine Angriffs Animation wird durchgef�hrt
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackrange, enemies); //Eine Kollisionsabfrage wird durchgef�hrt
                                                                                                                 //und alle Objekte die den Tag "Enemy" haben werden als enemiesToDamage gespeichert 
                                                                                                                
            for (int i = 0; i < enemiesToDamage.Length; i++) //for schleife um alle getroffenen Feinde zu durchlaufen
            {
                enemiesToDamage[i].GetComponent<Enemy>().enemyhealth -= damage; //die Gesundheit der Gegner wird um den Schaden reduziert
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; //Farbe = rot
        Gizmos.DrawWireSphere(attackPos.position, attackrange); //Kugel welche den Angriffsradius sowie den Angriffspunkt zeigt
    }
}
