using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioSrcSpawn : MonoBehaviour
{
    public float spawnThreshold = 0.003f;
    public int frequency = 128;
    public FFTWindow fftWindow;
    public GameObject prefab;
    public float debugValue;    
    public float delay = 0.5f;
    private float lastSpawnTime = 0f;    

    private List<GameObject> blocks = new List<GameObject>();
    [SerializeField] private int maxBlocks;

    private float[] samples = new float[1024];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lastSpawnTime += Time.deltaTime;
        AudioListener.GetSpectrumData(samples, 0, fftWindow);
        print("Delta Time: " + Time.deltaTime);
        print("'Last Spawn Time: '" + lastSpawnTime);
        print("'Delay: '" + delay);
        print("'Samples: '" + samples[128]);

        if (lastSpawnTime > delay && samples[frequency] > spawnThreshold)
        {
            spawnObjectOnMouse();
            lastSpawnTime = 0f;
        }

        if(Input.GetMouseButtonDown(0)) {
            spawnObjectOnMouse();
        }
    }

    void spawnObjectOnMouse() {
        Vector2 cursorSpot = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        reduceOpacity();
        if(blocks.Count < maxBlocks){
            blocks.Add(Instantiate(prefab, cursorSpot, Quaternion.identity));
        } else {
            Destroy(blocks[0]);
            blocks.RemoveAt(0);
            blocks.Add(Instantiate(prefab, cursorSpot, Quaternion.identity));
        }
    }

    void reduceOpacity() {
        foreach (GameObject block in blocks)
        {
            Color color = block.GetComponent<SpriteRenderer>().color;
            color.a = color.a * 0.5f;
            block.GetComponent<SpriteRenderer>().color = color;
        }
    }
}
