using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour {
    public GameObject roadContainerGO;
    public GameObject[] roads;

    public float speed = 15;
    public bool engineOn;

    public int roadCounter = 0;
    public int roadNumberSelector;

    void Start() {
        searchRoads();
        generateRoad();
    }

    void searchRoads() {
        roadContainerGO = GameObject.Find("roadContainer");
        roads = GameObject.FindGameObjectsWithTag("road");

        for (int i = 0; i < roads.Length; i++) {
            roads[i].gameObject.transform.parent = roadContainerGO.transform;
            roads[i].gameObject.SetActive(false);
            roads[i].gameObject.name = "RoadOFF_" + i;
        }
    }

    void generateRoad() {
        roadNumberSelector = Random.Range(0, roads.Length);
        GameObject newRoad = Instantiate(roads[roadNumberSelector]);
        newRoad.SetActive(true);
        newRoad.name = "Road_" + roadCounter;
        newRoad.transform.parent = gameObject.transform;
        roadCounter++;

        setRoadPosition(newRoad);
    }

    void setRoadPosition(GameObject newRoad) {
        GameObject prevRoad = GameObject.Find("Road_" + (roadCounter - 1));
        newRoad.transform.position = new Vector3(prevRoad.transform.position.x, prevRoad.transform.position.y + getRoadSize(prevRoad), 0);
    }

    float getRoadSize(GameObject road) {
        float roadSize = 0;
        for (int i = 0; i < road.transform.childCount; i++) {
            roadSize += road.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
        }
        return roadSize;
    }

    void Update() {
        if (engineOn) {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }
}