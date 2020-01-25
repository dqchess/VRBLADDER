using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinationManager : MonoBehaviour
{
    public Animator catheter;
    public Animator urineSea;
    public Animator bacteria;
    public Animator biofilm;

    int state;

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
        yield return new WaitForSeconds(5.0f);

        yield return new WaitUntil(isSpacePressed);

        bacteria.SetBool("start", true);
        yield return new WaitForSeconds(5.0f);

        yield return new WaitUntil(isSpacePressed);

        biofilm.SetBool("start", true);

    }

    bool isSpacePressed()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

}
