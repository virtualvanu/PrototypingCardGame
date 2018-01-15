using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardAddon_StealCard : CardAddon
{

    [Header("Steal Card Addon Attributes")]
    public int amountToSteal;

    public override void Setup()
    {
        base.Setup();
    }

    public override void Use()
    {
        FightManager.instance.StartCoroutine(StealCard());
    }

    private IEnumerator StealCard()
    {
        for (int i = 0; i < amountToSteal; i++)
        {
            CurrentDeck enemyDeck = FightManager.instance.enemyCurrentDeck;

            int randomCardToSteal = Random.Range(0, enemyDeck.inHand.Count);
            Card toSteal = enemyDeck.inHand[randomCardToSteal];

            GameObject toStealObject = enemyDeck.inhandie[randomCardToSteal];

            enemyDeck.inhandie[randomCardToSteal].GetComponent<Animator>().SetTrigger("Highlighted");
            yield return new WaitForSeconds(enemyDeck.inhandie[randomCardToSteal].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
            enemyDeck.inhandie[randomCardToSteal].GetComponent<Animator>().SetTrigger("Pressed");
            yield return new WaitForSeconds(1f);
            enemyDeck.inhandie[randomCardToSteal].GetComponent<Animator>().SetBool("Steal", true);
            yield return new WaitForSeconds(enemyDeck.inhandie[randomCardToSteal].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);

            enemyDeck.inHand.Remove(toSteal);
            enemyDeck.inhandie.Remove(toStealObject);
            Object.Destroy(toStealObject);

            FightManager.instance.myDeck.GetSpecificCard(toSteal);
        }
    }
}
