using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetIndicator : MonoBehaviour
{
    public Transform target;
    public float hideDistance = 15f;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 characterScale = transform.localRotation.eulerAngles;
        var direction = target.position - transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (direction.magnitude < hideDistance)
        {
            setChildrenActivity(false);
        }

        if(player.transform.localScale.x > 0) {
            setChildrenActivity(true);
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        } else{
            setChildrenActivity(true);
            transform.rotation = Quaternion.AngleAxis(angle + 180, Vector3.forward);
        }
    }

    void setChildrenActivity(bool active) {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(active);
        }
    }
}