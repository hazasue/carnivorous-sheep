using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientPlacement : MonoBehaviour
{
	private static int DEFAULT_EFFECTIVE_INGREDIENT_COUNT = 4;
	private static int MAX_INGREDIENT_COUNT = 20;

	private static float DEFAULT_OBJECT_POS_X = -10.0f;
	private static float DEFAULT_OBJECT_POS_Y = 0.6f;
	private static float DEFAULT_OBJECT_POS_Z = -10.0f;
	private static float DEFAULT_OBJECT_INTERVAL = 5.0f;

	public GameObject instantiatePosition;
	
	public GameObject[] effectiveIngr = new GameObject[DEFAULT_EFFECTIVE_INGREDIENT_COUNT - 1];
	public GameObject basicIngr;
	
	private List<int> ingrPos;
	

    // Start is called before the first frame update
    void Awake()
    {
	    Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Init()
    {
	    List<int> randPos = new List<int>();
	    ingrPos = new List<int>();

	    for (int i = 0; i < MAX_INGREDIENT_COUNT; i++)
	    {
		    randPos.Add(i);
	    }

	    for (int i = 0; i < DEFAULT_EFFECTIVE_INGREDIENT_COUNT; i++)
	    {
		    int randNum = randPos[Random.Range(0, randPos.Count)];
		    randPos.Remove(randNum);
		    ingrPos.Add(randNum);
	    }

	    // Instantiate basic ingredients
	    for (int i = 0; i < randPos.Count; i++)
	    {
		    int xpos = randPos[i] / 5;
		    int zpos = randPos[i] % 5;

		    GameObject tempIngr = Instantiate(basicIngr, instantiatePosition.transform);
		    tempIngr.transform.position = new Vector3(DEFAULT_OBJECT_POS_X + (xpos * DEFAULT_OBJECT_INTERVAL),
			    DEFAULT_OBJECT_POS_Y,
			    DEFAULT_OBJECT_POS_Z + (zpos * DEFAULT_OBJECT_INTERVAL));
	    }
	    
	    for (int i = 0; i < DEFAULT_EFFECTIVE_INGREDIENT_COUNT; i++)
	    {
		    int xpos = ingrPos[i] / 5;
		    int zpos = ingrPos[i] % 5;

		    GameObject tempIngr = Instantiate(effectiveIngr[i % (DEFAULT_EFFECTIVE_INGREDIENT_COUNT - 1)], instantiatePosition.transform);
		    tempIngr.transform.position = new Vector3(DEFAULT_OBJECT_POS_X + (xpos * DEFAULT_OBJECT_INTERVAL),
			    DEFAULT_OBJECT_POS_Y,
			    DEFAULT_OBJECT_POS_Z + (zpos * DEFAULT_OBJECT_INTERVAL));
	    }
    }
}
