using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {

	public int NUM_OBJECTS;
	public int NUM_LAYERS;
	public Transform obj;
	public Transform camera;

	private Transform[] objs;

	float trans = 0;


	// Use this for initialization
	void Start () {

		objs = new Transform[NUM_OBJECTS*NUM_LAYERS];
		for(int i = 0; i < NUM_LAYERS; i++){
			for(int j=0; j < NUM_OBJECTS; j++){
				float size = Random.Range(1, 200)
					, posX = Random.Range(1, 2000)
				    , posY = Random.Range(1, 2000)
				    , posZ = Random.Range(1, 200);
				Transform g = Instantiate (obj, new Vector3(posX-500, (i+1)*1000+posZ, posY-500), Quaternion.identity) as Transform; 
				g.localScale = new Vector3(size, size, size);
				objs[j+i*NUM_LAYERS] = g;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		trans += 1;
		if(camera.position.y > 15)
		    camera.Translate(0, -trans/50, 0);
		else{
			camera.position = new Vector3(0, 10, 0);
		}
		if (Input.GetKeyDown(KeyCode.F))
			Screen.fullScreen = !Screen.fullScreen;
	}
}
