using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform2 : MonoBehaviour {

    private Vector3 pos1;

    private Vector3 pos2;

    private Vector3 nexPos;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform childTransform;

    [SerializeField]
    private Transform transform2;

	// Use this for initialization
	void Start () {
        pos1 = childTransform.localPosition;
        pos2 = transform2.localPosition;
        nexPos = pos2;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    private void Move()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nexPos, speed * Time.deltaTime);

        if(Vector3.Distance(childTransform.localPosition,nexPos) <= 0.1)
        {
            ChangeDestination();
        }
    }
    private void ChangeDestination()
    {
        nexPos = nexPos != pos1 ? pos1 : pos2;
    }
}
