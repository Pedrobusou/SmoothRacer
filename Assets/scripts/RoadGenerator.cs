using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour {
    public GameObject roadContainerGO;
    public GameObject[] roads;

    public bool engineOn = false;
    public float speed = 15;

    public int roadCounter = 0;
    public int roadNumberSelector;

    public GameObject prevRoad;
    public float prevRoadSize;

    public Vector3 screenLimit;
    public bool outOfScreen = true;

    void Start() {
        searchRoads();
        generateRoad();
        getScreenSize();
    }

    void searchRoads() {
        roadContainerGO = GameObject.Find("roadContainer");
        roads = GameObject.FindGameObjectsWithTag("road");

        for (int i = 0; i < roads.Length; i++) {
            roads[i].gameObject.transform.parent = roadContainerGO.transform;
            roads[i].gameObject.SetActive(false);
            roads[i].gameObject.name = "roadTemplate_" + i;
        }
    }

    void generateRoad() {
        roadCounter++;
        roadNumberSelector = Random.Range(0, roads.Length);
        GameObject newRoad = Instantiate(roads[roadNumberSelector]);
        newRoad.SetActive(true);
        newRoad.name = "road_" + roadCounter;
        newRoad.transform.parent = gameObject.transform;

        setRoadPosition(newRoad);
    }

    void setRoadPosition(GameObject newRoad) {
        prevRoad = GameObject.Find("road_" + (roadCounter - 1));
        prevRoadSize = getRoadSize(prevRoad);
        newRoad.transform.position = new Vector3(prevRoad.transform.position.x, prevRoad.transform.position.y + prevRoadSize, 0);

        outOfScreen = false;
    }

    float getRoadSize(GameObject road) {
        float roadSize = 0;
        for (int i = 0; i < road.transform.childCount; i++) {
            roadSize += road.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
        }
        return roadSize;
    }

    void getScreenSize() {
        screenLimit = new Vector3(0, GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(new Vector3(0, 0, 0)).y - 0.5f, 0);
    }

    void Update() {
        if (engineOn) {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        if (!outOfScreen && prevRoad.transform.position.y + prevRoadSize < screenLimit.y) {
            outOfScreen = true;
            Destroy(prevRoad);
            generateRoad();
        }
    }
}