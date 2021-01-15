using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasiManager : MonoBehaviour {

    [SerializeField]
    Animator anim1;
    [SerializeField]
    Animator anim2;
    [SerializeField]
    Animator anim3;
    [SerializeField]
    Animator anim4;

    [SerializeField]
    GameObject G1;
    [SerializeField]
    GameObject G2;
    [SerializeField]
    GameObject G3;
    [SerializeField]
    GameObject G4;

    public bool gasiOn = false;

    public void Start()
    {
        anim1 = G1.GetComponent<Animator>();
        anim2 = G2.GetComponent<Animator>();
        anim3 = G3.GetComponent<Animator>();
        anim4 = G4.GetComponent<Animator>();
        StartCoroutine("gasiAnim");
        
    }

    public IEnumerator gasiAnim()
    {
        while(true)
        {
            gasiOn = true;

            
            G1.SetActive(true);
            anim1.SetTrigger("Out");
            
            G2.SetActive(true);
            anim2.SetTrigger("Out");
            
            G3.SetActive(true);
            anim3.SetTrigger("Out");
          
            G4.SetActive(true);
            anim4.SetTrigger("Out");

            yield return new WaitForSeconds(2f);
            gasiOn = false;

            G1.SetActive(false);
            G2.SetActive(false);
            G3.SetActive(false);
            G4.SetActive(false);

            yield return new WaitForSeconds(4.0f);
        }
       

        
    }
}
