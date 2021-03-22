using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamagochiManager : MonoBehaviour
{
    public GameObject CameraAR;
    public GameObject table;
    private Animator animator;
    private string[] nameAnim = new string[3] { "hello", "sitdown", "updown" };
    private GameObject targetObject;
    private float dist;
    // Start is called before the first frame update
    void Start()
    {
        targetObject = CameraAR;
        animator = GetComponent<Animator>();
        StartCoroutine(Active_Char());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - targetObject.transform.position, Vector3.up);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y - 180, 0);
    }

    

    IEnumerator Active_Char()
    {
        while (true)
        {
            animator.SetTrigger("hello");
            yield return new WaitForSeconds(1);
            animator.SetTrigger("hello");
            yield return new WaitForSeconds(9);
            animator.SetTrigger("sitdown");
            yield return new WaitForSeconds(1);
            animator.SetTrigger("sitdown");
            yield return new WaitForSeconds(9);
            animator.SetTrigger("updown");
            yield return new WaitForSeconds(1);
            animator.SetTrigger("updown");
            yield return new WaitForSeconds(9);
        }

    }

    public void TargetTable()
    {
        
        dist = Vector3.Distance(gameObject.transform.position, table.transform.position);
        if (dist > 0.18)
        {
            targetObject = table;
            StartCoroutine(Distance());
        }
        else targetObject = CameraAR;
    }

    IEnumerator Distance()
    {
        while(dist > 0.18)
        {
            transform.position = transform.forward * 3;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
