using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioSrcSpawn : MonoBehaviour
{
    public float spawnThreshold = 0.01f;
    public int frequency = 0;
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
        debugValue = samples[frequency];
        AudioListener.GetSpectrumData(samples, 0, fftWindow);

        if (lastSpawnTime > delay && samples[frequency] > spawnThreshold)
        {
            spawnObjectOnMouse();
            lastSpawnTime = 0f;
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
