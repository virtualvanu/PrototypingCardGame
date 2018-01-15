using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "OLDCards/StealCard")]
public class Card_StealCard : Card
{

    public override void Setup(CardHolder myHolder)
    {
        base.Setup(myHolder);

        //myHolder.CreateAttribute(CardAttribute.Type.Damage, damage);
    }

    public override void Use(CardHolder myHolder)
    {
        base.Use(myHolder);

        FightManager.instance.StartCoroutine(StealCard());
    }

    private IEnumerator StealCard()
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
        Destroy(toStealObject);

        FightManager.instance.myDeck.GetSpecificCard(toSteal);
    }
}
