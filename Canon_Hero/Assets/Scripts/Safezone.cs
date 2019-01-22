using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safezone : MonoBehaviour
{
    public static bool isEnemyAttack;
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == Constants.Tag.PLAYERBULLET)
        {
           col.gameObject.SetActive(false);
            UIInGameManager.Instance.SetActiveText(0);
            isEnemyAttack = true; 
        }
    }
}
