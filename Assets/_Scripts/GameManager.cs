using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using System;
using JetBrains.Annotations;
using UnityEngine.UIElements;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> tilePictures;
    public List<Vector3> takenPositions;
    public GameObject lastGameObject;
    public Camera cam;
    public int pointCounter;
    public Texts getPoints;
    public LastImage lastImage;
    int random = -1;

    private void Start()
    {
        GenerateTile();
    }

    public void GenerateTile()
    {
        random = UnityEngine.Random.Range(0, tilePictures.Count);
        lastImage.GetTile(tilePictures[random].GetComponent<SpriteRenderer>().sprite);
        
    }

    private void Update()
    {

        Vector3 cursorPostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float rayLength = 100.0f;
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayLength))
        {
            if (hit.collider != null)
            {
                    if (Input.GetKeyDown(KeyCode.Space))
                    { 
                        GameObject randomTile = tilePictures[random];
                        randomTile.transform.localScale = new Vector3((float)1.5, (float)1.5, 0);
                        Vector3 cursorPosition = new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y, -3);
                        if (!(takenPositions.Contains(cursorPosition)))
                        {
                            lastGameObject = Instantiate(randomTile);
                            lastGameObject.transform.position = new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y, -3);
                            takenPositions.Add(new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y, -3));

                            pointCounter += 1;
                            getPoints.GetUserPoints(pointCounter);
                            tilePictures.Remove(randomTile);

                            GenerateTile();
                        }
                        else
                        {
                            Console.WriteLine("The tile is taken");
                        }
                    }
            }
        }

    }
}
