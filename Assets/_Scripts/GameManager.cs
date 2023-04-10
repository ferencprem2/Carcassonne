using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using System;
using JetBrains.Annotations;
using UnityEngine.UIElements;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public List<GameObject> tilePictures;
    public List<Vector3> takenPositions;
    public GameObject lastGameObject;
    public Camera cam;

    private void Update()
    {
        Vector3 cursorPostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float rayLength = 100.0f;
        RaycastHit hit;
        

		try
		{
            if (Physics.Raycast(ray, out hit, rayLength))
            {
                if (hit.collider != null)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        int random = UnityEngine.Random.Range(0, tilePictures.Count);
                        GameObject randomTile = tilePictures[random];
                        randomTile.transform.localScale = new Vector3((float)1.5, (float)1.5, 0);
                        Vector3 cursorPosition = new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y, -3);
                        if (!(takenPositions.Contains(cursorPosition)))
                        {
                            lastGameObject = Instantiate(randomTile);

                            lastGameObject.transform.position = new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y, -3);
                            takenPositions.Add(new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y, -3));

                            tilePictures.Remove(randomTile);
                        }
                        else
                        {
                            Console.WriteLine("The tile is taken");
                        }
                    }
                }
            }
            
        }
		catch (Exception e)
		{
            Console.WriteLine(e.Message);
            throw;
		}
    }


}
