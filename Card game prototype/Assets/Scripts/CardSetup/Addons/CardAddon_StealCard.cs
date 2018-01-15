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
            if (myHolder.side == CardHolder.Side.Enemy)
            {
                //Debug.Log("test");
                CurrentDeck playerDeck = FightManager.instance.myDeck;

                int randomCardToSteal = Random.Range(0, playerDeck.inHand.Count);
                Card toSteal = playerDeck.inHand[randomCardToSteal];

                GameObject toStealObject = playerDeck.inhandie[randomCardToSteal];

                playerDeck.inhandie[randomCardToSteal].GetComponent<Animator>().SetBool("Steal", true);
                playerDeck.inhandie[randomCardToSteal].GetComponent<Animator>().SetTrigger("Highlighted");
                yield return new WaitForSeconds(playerDeck.inhandie[randomCardToSteal].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
                yield return new WaitForSeconds(1f);

                playerDeck.inHand.Remove(toSteal);
                playerDeck.inhandie.Remove(toStealObject);
                Object.Destroy(toStealObject);

                FightManager.instance.enemyCurrentDeck.GetSpecificCard(toSteal);
            }
            else if (myHolder.side == CardHolder.Side.Player)
            {
                //Debug.Log("test2");
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
}
