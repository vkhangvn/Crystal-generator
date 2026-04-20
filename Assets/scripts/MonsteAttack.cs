using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsteAttack : MonoBehaviour
{
    [SerializeField] private Animator monsterAttack;
    public GameObject monster;
    public GameObject blueParticle;
    public GameObject blueParticle2;

    public GameObject redParticle;
    public GameObject redParticle2;
    public GameObject greenParticle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void TaskOnClick()
    {
        StartCoroutine(attacking());
    }

    public void blueBurst()
    {
        StartCoroutine(blueparticle());
    }

    public void blueBurst2()
    {
        StartCoroutine(blueparticle2());
    }

    public void redBurst()
    {
        StartCoroutine(redparticle());
    }

    public void redBurst2()
    {
        StartCoroutine(redparticle2());
    }

    public void greenBurst()
    {
        StartCoroutine(greenparticle());
    }




    IEnumerator attacking()
    {
        monster.SetActive(true);
        monsterAttack.SetBool("Monster Attack", true);
        yield return new WaitForSeconds(1f);
        monsterAttack.SetBool("Monster Attack", false);
        monster.SetActive(false);
    }

    IEnumerator blueparticle()
    {
        blueParticle.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        blueParticle.SetActive(false);
    }

    IEnumerator blueparticle2()
    {
        blueParticle2.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        blueParticle2.SetActive(false);
    }

    IEnumerator redparticle()
    {
        redParticle.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        redParticle.SetActive(false);
    }

    IEnumerator redparticle2()
    {
        redParticle2.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        redParticle2.SetActive(false);
    }

    IEnumerator greenparticle()
    {
        greenParticle.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        greenParticle.SetActive(false);
    }
}
