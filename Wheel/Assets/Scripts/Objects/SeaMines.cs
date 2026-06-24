using System.Collections;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class SeaMine
{    
    public GameObject seaMine;
    public float timeToReturn;

    [HideInInspector]
    public float timeBtwMove;
    [HideInInspector]
    public Animator anim;
}

public class SeaMines : MonoBehaviour
{
    public bool CanMove = true;
    public float baseTimeBtwMove;
    public float timeMultiplierValue;
    public float timeToWait;

    public SeaMine[] mines;

    void Start()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        SeaMine lastMine = mines.Last();

        foreach(SeaMine m in mines)
        {
            m.anim = m.seaMine.GetComponent<Animator>();
        }

        while (CanMove)
        {
            for (int i = 0; i < mines.Length; i++)
            {
                mines[i].timeBtwMove = baseTimeBtwMove + (i * timeMultiplierValue);

                StartCoroutine(SeaMineMove(mines[i].anim, mines[i].timeBtwMove, mines[i].timeToReturn));

                if (i + 1 == mines.Length)
                {
                    yield return new WaitForSeconds(mines[i].timeBtwMove + mines[i].timeToReturn + timeToWait);
                }
            }

            yield return null;
        }         
    }

    IEnumerator SeaMineMove(Animator anim, float timeBtwMove, float timeToReturn)
    {
        yield return new WaitForSeconds(timeBtwMove);
        anim.SetTrigger("Move");

        yield return new WaitForSeconds(timeToReturn);
        anim.SetTrigger("Return");
    }
}