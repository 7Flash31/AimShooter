using System.Collections;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameObject goodSphere;
    [SerializeField] private GameObject badSphere;
    [SerializeField] private GameObject superSphere;

    [SerializeField] private float timeGood;
    [SerializeField] private float timeBad;
    [SerializeField] private float timeSuper;

    public IEnumerator SpawnGoodSphere()
    {
        while(true)
        {
            Vector3 pos = new Vector3(Random.Range(2.3f, 17.5f), Random.Range(3f, 6.5f), Random.Range(15f, 17f));
            Instantiate(goodSphere, pos, Quaternion.identity);

            yield return new WaitForSeconds(timeGood);
        }
    }

    public IEnumerator SpawnBadSphere()
    {
        while(true)
        {
            Vector3 pos = new Vector3(Random.Range(2.3f, 17.5f), Random.Range(3f, 6.5f), Random.Range(15f, 17f));
            Instantiate(badSphere, pos, Quaternion.identity);

            yield return new WaitForSeconds(timeBad);
        }
    }

    public IEnumerator SpawnSuperSphere()
    {
        while(true)
        {
            Vector3 pos = new Vector3(Random.Range(2.3f, 17.5f), Random.Range(3f, 6.5f), Random.Range(15f, 17f));
            Instantiate(superSphere, pos, Quaternion.identity);

            yield return new WaitForSeconds(timeSuper);
        }
    }
}
