using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SceneGenerator : MonoBehaviour
{

	public Color[] lightColors;
	public Light light;
	public GameObject camera;
	public GameObject scene;
	public float sceneRange;
	public GameObject rock;
	public int maxRockCnt;
	public GameObject sandRock;
	public int maxSandRockCnt;
	public GameObject bubbles;
	public int maxBubblesCnt;
	public GameObject fishes;
	public int maxFishesCnt;
	public GameObject target;
	public float minTargetZ;
	public float maxTargetZCoef;
	public bool fixTargetSize;

	void genObjects(int cnt, GameObject obj, float depth = 3.0f, float minZ = 5.0f, float maxZCoef = 2.0f, bool fix = false) {
		for (int i = 0; i < cnt; i++) {
			GameObject currentObj = Instantiate(obj);
			if (!fix) {
				currentObj.transform.localScale = new Vector3(Random.Range(0.3f, 1.0f), Random.Range(0.3f, 1.0f), Random.Range(0.3f, 1.0f));
			}
			currentObj.transform.parent = scene.transform;
			currentObj.transform.localPosition = new Vector3(Random.Range(-sceneRange, sceneRange), depth, Random.Range(minZ, sceneRange * maxZCoef));
        }
	}

    void Start() {
    	light.color = lightColors[Random.Range(0, lightColors.Length)];
        camera.transform.localEulerAngles = new Vector3(30.0f, Random.Range(-180.0f, 180.0f), 0.0f);
        genObjects(Random.Range(1, 3), target, 7, minTargetZ, maxTargetZCoef, fixTargetSize);
        genObjects(Random.Range(0, maxRockCnt), rock);
        genObjects(Random.Range(0, maxSandRockCnt), sandRock);
        genObjects(Random.Range(0, maxBubblesCnt), bubbles);
        genObjects(Random.Range(0, maxFishesCnt), fishes);
    }
}
