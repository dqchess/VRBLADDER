using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class GunController : MonoBehaviour
{
    public GameObject antibiotic;
    public bool canShoot =  false;
    public float speed;
    public float multiplier = 3.0f;
    public float range =3.0f;
    public Transform[] targets;
    public GameObject bullet;

    //Input
    public SteamVR_Action_Boolean trigger;
    public SteamVR_Input_Sources handType;
    // Start is called before the first frame update
    void Start()
    {
        trigger.AddOnStateDownListener(ShootLauncher, handType);
    }



    public void ShootLauncher(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        print("Click was triggered");
        StartCoroutine(Shoot());
    }

    public IEnumerator Shoot()
    {
        bullet = Instantiate(antibiotic, this.transform.position, Quaternion.AngleAxis(Random.Range(0.0f, 360.0f), new Vector3(1.0f, 1.0f, 1.0f)));
        float distance = 1.0f;
        float step = speed * Time.deltaTime;
        while(distance > 0.01f)
        {
            distance = Vector3.Distance(bullet.transform.position, targets[0].position);
            bullet.transform.position = Vector3.MoveTowards(bullet.transform.position, targets[0].position, step);
            yield return new WaitForSeconds(Time.deltaTime);
        }

        //Reached the target
        Vector3 randTarget = transform.position + Random.insideUnitSphere * range;
        distance = 1.0f;
        step *= multiplier;
        while (distance > 0.001f)
        {
            distance = Vector3.Distance(bullet.transform.position, randTarget);
            bullet.transform.position = Vector3.MoveTowards(bullet.transform.position, randTarget, step);
            yield return new WaitForSeconds(Time.deltaTime);
        }

    }
}
