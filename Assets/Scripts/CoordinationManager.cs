using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinationManager : MonoBehaviour
{
    public Animator catheter;
    public Animator urineSea;
    public Animator bacteria;
    public Animator biofilm;

    public float urineSeaTime = 32.0f;
    public float bacteriaTime = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Coordinate());
    }


    IEnumerator Coordinate()
    {
        yield return new WaitUntil(isSpacePressed);

        catheter.SetBool("start", true);
        yield return new WaitForSeconds(1.0f);
        urineSea.SetBool("start", true);
        yield return new WaitForSeconds(urineSeaTime);

        yield return new WaitUntil(isSpacePressed);

        bacteria.SetBool("start", true);
        yield return new WaitForSeconds(bacteriaTime);

        yield return new WaitUntil(isSpacePressed);

        biofilm.SetBool("start", true);

    }

    bool isSpacePressed()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

}
