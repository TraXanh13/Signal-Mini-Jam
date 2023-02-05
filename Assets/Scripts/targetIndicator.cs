using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetIndicator : MonoBehaviour
{
    public Transform target;
    public float hideDistance = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var direction = target.position - transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (direction.magnitude < hideDistance)
        {
            setChildrenActivity(false);
        }
        else
        {
            setChildrenActivity(true);
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

    }

    void setChildrenActivity(bool active) {
        print("setting children activity to " + active);
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(active);
        }
    }
}