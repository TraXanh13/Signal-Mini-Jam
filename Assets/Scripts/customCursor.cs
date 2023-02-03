using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customCursor : MonoBehaviour
{
    Vector2 cursorSpot;
    public GameObject block;
    private List<GameObject> blocks = new List<GameObject>();
    [SerializeField] private int maxBlocks;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        cursorSpot = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorSpot;

        if (Input.GetMouseButtonDown(0))
        {
            spawnBlock();
        }
    }

    private void spawnBlock()
    {
        if(blocks.Count < maxBlocks){
            blocks.Add(Instantiate(block, cursorSpot, Quaternion.identity));
        } else {
            Destroy(blocks[0]);
            blocks.RemoveAt(0);
            blocks.Add(Instantiate(block, cursorSpot, Quaternion.identity));
        }
    }
}
