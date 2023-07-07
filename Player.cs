using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int health;

    public void ReceiveHealing()
    {
        if (health >= 100)
        {
            return;
        }

        StartCoroutine(HealingCoroutine());
    }

    private IEnumerator HealingCoroutine()
    {
        float elapsedTime = 0f;
        while (health < 100 && elapsedTime < 3f)
        {
            health += 5;
            if (health > 100)
            {
                health = 100;
            }
            yield return new WaitForSeconds(0.5f);
            elapsedTime += 0.5f;
        }
    }
}