using UnityEngine;
using System.Collections;

public class BuildingAnimationController : MonoBehaviour {

    public ParticleSystem MainSmoke;
    public ParticleSystem BrokenPlanks;
    public GameObject[] BuildingObjects = new GameObject[3];

    public void OffSmoke()
    {
        MainSmoke.Stop();
    }

    public void BrokenPlanksEnable()
    {
        BrokenPlanks.gameObject.SetActive(true);
    }

    public void AnimatiionFinished()
    {
        StartCoroutine(OffAllObjects());
    }

    private IEnumerator OffAllObjects()
    {
        yield return new WaitForSeconds(3.0f);
        foreach (GameObject o in BuildingObjects)
        {
            o.SetActive(false);
            yield return null;
        }
    }

}
