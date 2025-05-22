using UnityEngine;
using System.Collections;

public class MunculinVirus : MonoBehaviour
{
    public GameObject virus;
    public float waktuMinimal, waktuMaximal;
    public float posisiMinimal, posisiMaximal;

    void Start()
    {
        StartCoroutine(MunculVirus());
    }

   IEnumerator MunculVirus()
    {
        Instantiate(virus, transform.position + Vector3.right * Random.Range(posisiMinimal, posisiMaximal), Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(waktuMinimal, waktuMaximal));
        StartCoroutine(MunculVirus());
    }
}
