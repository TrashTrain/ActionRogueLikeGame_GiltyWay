using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GrapplingHook : MonoBehaviour
{
    //[SerializeField] private float grappleLength;
    //[SerializeField] private LayerMask grappleLayer;
    //[SerializeField] private LineRenderer rope;

    //private Vector3 grapplePoint;
    //private DistanceJoint2D joint;

    public LineRenderer line;
    public Transform hook;
    Vector2 mousedir;
    

    public bool isHookActive;
    public bool isLineMax;
    public bool isAttach;

    void Start()
    {
        //joint = gameObject.GetComponent<DistanceJoint2D>();
        //joint.enabled = false;
        //rope.enabled = false;

        line.positionCount = 2;
        line.endWidth = line.startWidth = 0.05f;
        line.SetPosition(0, transform.position);
        line.SetPosition(1, hook.position);
        line.useWorldSpace = true;
        isAttach = false;

    }

    // Update is called once per frame
    void Update()
    {
        /*
        // 1¹ø ¹æ¹ý
        //if (Input.GetMouseButtonDown(1))
        //{
        //    RaycastHit2D hit = Physics2D.Raycast(
        //        origin: Camera.main.ScreenToWorldPoint(Input.mousePosition),
        //        direction: Vector2.zero,
        //        distance: Mathf.Infinity,
        //        layerMask: grappleLayer
        //        );

        //    if (hit.collider != null)
        //    {
        //        grapplePoint = hit.point;
        //        grapplePoint.z = 0;
        //        joint.connectedAnchor = grapplePoint;
        //        joint.enabled = true;
        //        joint.distance = grappleLength;
        //        rope.SetPosition(0, grapplePoint);
        //        rope.SetPosition(1, transform.position);
        //        rope.enabled = true;
        //    }

        //}

        //if (Input.GetMouseButtonUp(1))
        //{
        //    joint.enabled = false;
        //    rope.enabled = false;
        //}

        //if (rope.enabled == true)
        //{
        //    rope.SetPosition(1, transform.position);
        //}
        */

        line.SetPosition(0, transform.position);
        line.SetPosition(1, hook.position);

        if (Input.GetMouseButtonDown(1) && !isHookActive) 
        {
            hook.position = transform.position;
            mousedir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            isHookActive = true;
            isLineMax = false;
            hook.gameObject.SetActive(true);
        }

        if (isHookActive && !isLineMax && !isAttach)
        {
            if(mousedir.x < 0)
            {
                mousedir.x *= -1;
            }
            
            hook.Translate(mousedir.normalized * Time.deltaTime * 15);

            if (Vector2.Distance(transform.position, hook.position) > 5)
            {
                isLineMax = true;
            }
        }else if(isHookActive && isLineMax && !isAttach)
        {
            hook.position = Vector2.MoveTowards(hook.position, transform.position, Time.deltaTime * 15);
            if (Vector2.Distance(transform.position, hook.position) < 0.1f){
                isHookActive=false;
                isLineMax=false;
                hook.gameObject.SetActive(false);
            }
        }else if (isAttach)
        {

        }
    }

}
