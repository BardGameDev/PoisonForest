using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int playerHealth;//called by Poison Fog, once the playerHealth hits 0 the game should restart
	public bool gameWon;
	private string pickUpID;

    public int armor;
    public int spawnPlatform;
    private GameObject player;

    private ButtonController curr_button_script;
    private GameObject curr_button_puzzle;

    private string timerID;
    private bool startTimer; // is there a timer active
    private float timeLeft;
    private float timeHeld;

    private GameObject platformsToAppear1;
    private GameObject platformsToAppear2;

    private bool lFanState;
    private bool rFanState;

    private Vector3 spawnPos;
     // when the player pushes a button, this platform or set of platforms will appear

    void Start()
    {
		gameWon = false;
        armor = 5;
        playerHealth = 100;
        player = GameObject.FindWithTag("Player");
		spawnPos = player.transform.position;
        spawnPlatform = 0;
//        platformsToAppear1 = GameObject.FindWithTag("PlatToAppear"); //Get a reference to the collection of paltforms
//        platformsToAppear1.SetActive(false); //Then immediately deactivate it... you can't reference an inactive object from the get-go
//        platformsToAppear2 = GameObject.FindWithTag("PlatToAppear2");
//        platformsToAppear2.SetActive(false);
    }

    void Update()
    {
		if (startTimer)
        {
            timeLeft -= Time.deltaTime;
            print("timeleft: " + timeLeft.ToString());
			if (timeLeft <= 0)
            {
                timerDone(timerID);
            }
        }
    }

    public void dropTrigger(string id, GameObject missingChild)
    {
      if (id.Equals("RightFan") && missingChild.GetComponent<PickUpController>().id.Equals("RBattery")){
        missingChild.SetActive(false);
        GameObject.Find("FanObject R").GetComponent<BladeRotation>().active = true;
        lFanState = true;
        destroyFog();
        }
      if (id.Equals("LeftFan") && missingChild.GetComponent<PickUpController>().id.Equals("LBattery")){
        missingChild.SetActive(false);
        GameObject.Find("FanObject L").GetComponent<BladeRotation>().active = true;
        rFanState = true;
        destroyFog();
      }
    }

    public void destroyFog()
    {
      GameObject Fog1 = GameObject.Find("Poison Fog 1");
      GameObject Fog2 = GameObject.Find("Poison Fog 2");
      GameObject Fog3 = GameObject.Find("Poison Fog 3");
      if (lFanState && rFanState){
        Fog1.SetActive(false);
      }
      if (lFanState && Fog3 != null){
        Fog3.SetActive(false);
      }
      if (rFanState && Fog2 != null){
        Fog2.SetActive(false);
      }
    }
    //Called by PickUpController
    public void pickUpObject(string id, GameObject pickUp)
    {

    }

    //Called by ButtonController
    public void buttonPressed(string id, bool beenClicked, GameObject button, GameObject puzzle)
    {
//        if (id.Equals("plat_contain1"))
//        {
//          platformsToAppear1.SetActive(true); //if you hit the button responsible for the platforms, activate the platforms whether they're active, already, or not
//        }
//        else if (id.Equals("plat_contain2")){
//          platformsToAppear2.SetActive(true);
//        }
		if (id.Equals ("Win")) {
			//curr_button_script.ToggleClicked();
			StartCoroutine (delay());
		}
    }

	IEnumerator delay ()
	{
		spawnPlatform = 0;
		gameWon = true;
		respawn ();

		yield return new WaitForSeconds (5f);

		gameWon = false;
		//curr_button_script.ToggleClicked();
	}

    public void buttonActivate (string id, GameObject button, GameObject puzzle)
	{
		timerID = id;
		curr_button_puzzle = puzzle;
		curr_button_script = button.GetComponent<ButtonController> ();
		if (id.Equals ("ArrowDeactivate")) {
			//curr_button_script.ToggleClicked();
			timeLeft = 3;
			startTimer = true;
		}

		if (id.Equals ("Win")) {
			//curr_button_script.ToggleClicked();
			StartCoroutine (delay());
			timeLeft = 5;
			startTimer = true;
		}
	}

    public void buttonDeactivate(string id, GameObject puzzle){
    }

	public void buttonCount(string id, float timer, bool beenClicked, GameObject button, GameObject puzzle)
    {
        timerID = id;
        timeLeft = timer;
        curr_button_script = button.GetComponent<ButtonController>();
        curr_button_puzzle = puzzle;
  
		startTimer = beenClicked;
		if (id.Equals ("Win")) {
			//curr_button_script.ToggleClicked();
			StartCoroutine (delay());
		}
    }

    void timerDone(string id)
    {
        startTimer = false;
        if (id.Equals("ArrowDeactivate")){
          curr_button_puzzle.SetActive(false);
        }
    }

    //Called by cPad controller
    public void cPadUsed(string id, string direction, GameObject puzzle)
    {
    }

    public void setSpawn(GameObject spawn)
    {
        if (spawn.name == "1SP1"){
            spawnPlatform = 1;
        }
        else if (spawn.name == "1SP2"){
            spawnPlatform = 2;
        }
    }
	public void respawn ()
	{
		armor = 5;
		playerHealth = 100;

		player.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		player.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;

		if (spawnPlatform == 0) {
			player.transform.position = spawnPos;
		}
		if (spawnPlatform == 1) {
			player.transform.position = GameObject.Find ("1SP1").transform.position + new Vector3 (0.0f, 1.0f, 0.0f);
		}
		if (spawnPlatform == 2) {
			player.transform.position = GameObject.Find ("1SP2").transform.position + new Vector3 (0.0f, 1.0f, 0.0f);
		}
	}

    //called by the Poison Fog to check the level health for every moment the player is in the fog. If the health is 0 or below, reset the game.
    public void damageChecking(string id)
    {
        if (id[0] == '1')
        { // check that trigger is in level 1
            id = id.Substring(1);//Remove level prefix from id
            if (id.Equals("poisonfog")){
                if (playerHealth <= 0){
                    respawn();
                }
            }
            else if (id.Equals("arrow")){
                if (armor <= 0){
                    respawn();
                }
            }
        }
    }
}

//DEREK'S OLD LVLCONTROLLER BEFORE 5/4/17

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {
  public int playerHealth;//called by Poison Fog, once the playerHealth hits 0 the game should restart
  public string currentSceneName;

  public int hitByArrow;
  public int standingInFog = 5;
  public int spawnPlatform;
  private GameObject player;

	private bool[] binaryPuzzle;
	private bool[] binaryPuzzleAnswer;

	private string pickedUpName = "";
	private GameObject pickedUpObj;

	private bool gearFound;
	private bool weightFound;
	private bool binarySolved;
    void Start()
    {
    hitByArrow=0;
    playerHealth = 100;
    binarySolved = false;
		gearFound = false;
		weightFound = false;
    player = GameObject.FindGameObjectWithTag("Player");

		binaryPuzzle =  new bool[6];
		binaryPuzzleAnswer = new bool[6];
		binaryPuzzleAnswer [0] = true;
		binaryPuzzleAnswer [3] = true;
		binaryPuzzleAnswer [4] = true;
	}

	void Update(){
		if (binarySolved) {
			print ("lerp");
			//Vector3 final_pos = new Vector3(gameObject.transform.position.x, -11.5f,gameObject.transform.position.z);
			//GameObject.Find("Binary Platform").transform.position = Vector3.Lerp (gameObject.transform.position, final_pos, Time.deltaTime);
		}
	}

	bool binaryAnswerCheck(){
		for (int i = 0; i < 6; i++) {
			if (binaryPuzzleAnswer [i] != binaryPuzzle [i])
				return false;
		}
		return true;
	}

/// <summary>
//Below are the functions called by other scripts to communicate with LevelController
/// </summary>

    //The following function simply checks which platform to send the player back to upon death, and will send the player back and reset all related values, such as health,
    // as They were set upon initialization

  public void setSpawn(GameObject spawn){
    if (spawn.name == "1SP1"){
            spawnPlatform = 1;
            Debug.Log("Spawn set to 1");
      }
  }
  public void respawn(){
    if (spawnPlatform == 1){
      player.transform.position = GameObject.Find("1SP1").transform.position + new Vector3(0.0f,1.0f,0.0f);
    }
  }

  //called by the Poison Fog to check the level health for every moment the player is in the fog. If the health is 0 or below, reset the game.
  public void damageChecking(string id){
    if (id[0] == '1'){ // check that trigger is in level 1
      id = id.Substring(1);//Remove level prefix from id
      if (id.Equals("poisonfog")){
        if (playerHealth <= 0 ){
          SceneManager.LoadScene("GetTheGear");
        }
      }
      else if (id.Equals("arrow")){
        if (hitByArrow >= 3){
          respawn();
        }
      }
    }
  }

	//Called by DropTriggerController
	//Checks to see if the object currently held by the player matches the dropoff zone
	public void dropTrigger(string id, GameObject missingChild){
		if (id [0] == '1') { // trigger is in Level 1
			id = id.Substring(1); // Remove level prefix from id
			print("id");
			if(id.Equals(pickedUpName)) {
				pickedUpObj.GetComponent<PickUpController> ().off();
				missingChild.SetActive (true);
				if (id.Equals ("gear")) {
					gearFound = true;
				}
				else if (id.Equals("counterWeight")) {
					weightFound = true;
				}
			}
		}
	}
	//Called by PickUpController
	public void pickUpObject(string id, GameObject pickUp){
		if (id [0] == '1') { // pickUp is in Level 1
			id = id.Substring (1); // Remove level prefix from id
			pickedUpName = id;
			pickedUpObj = pickUp;
		}
	}

	//Called by ButtonController
	public void buttonPressed(string id, bool beenClicked, GameObject button, GameObject puzzle_obj){
		if (id [0] == '1') { //Button is in Level 1
			id = id.Substring(1); // Remove level prefix from id
			if (id [0] == 'B') { //Binary Buttons
				id = id.Substring(1); // Remove binary button prefix
				if (id.Equals("1")){
					binaryPuzzle [0] = binaryPuzzle [0] == false;
				}
				else if (id.Equals("4")){
					binaryPuzzle [2] = binaryPuzzle [2] == false;
				}
				else if (id.Equals("8")){
					binaryPuzzle [3] = binaryPuzzle [3] == false;
				}
				else if (id.Equals("16")){
					binaryPuzzle [4] = binaryPuzzle [4] == false;
				}
				else if (id.Equals("32")){
					binaryPuzzle [5] = binaryPuzzle [5] == false;
				}
				//Binary puzzle complete
				if (binaryAnswerCheck ()) {
					binarySolved = true;
					Vector3 temp = GameObject.Find ("CounterWeightPickUp").transform.position;
					temp.y = 2;
					GameObject.Find ("CounterWeightPickUp").transform.position = temp;
				}
			}
			else if (id.Equals("pad")) { // Bring CPad into view
				if (beenClicked) {
					puzzle_obj.transform.Translate (new Vector3 (0, 1.4f, 0));
				} else {
					puzzle_obj.transform.Translate (new Vector3 (0, -1.4f, 0));
				}
			}
			else if (id.Equals("gate")) { //can the gate open
				if(gearFound && weightFound){ // level is finished
					//raise gate, lower weights
				}
			}
			else if (id.Equals("platform")){
				button.GetComponent<Renderer>().material.color = Color.red;
				puzzle_obj.GetComponent<HoverObject> ().buttonPressed = true; // makes platform moveable
				puzzle_obj.GetComponent<Renderer>().material.color = Color.red;

			}
      else if (id.Equals("fogger")){
        button.GetComponent<Renderer>().material.color = Color.red;
        puzzle_obj.SetActive(false);
      }
		}
	}

	public void cPadUsed(string id, string direction, GameObject puzzle){
		if (id [0] == '1') { //CPad is in Level 1
			id = id.Substring(1); // Remove level prefix from id
			if(id.Equals("speedRotate")){
				if (direction.Equals ("counterClockwise")) {
					puzzle.transform.Rotate (new Vector3 (0, 10, 0) * Time.deltaTime);
				} else {
					puzzle.transform.Rotate(new Vector3 (0, -10,  0) * Time.deltaTime);
				}
			}
		}
	}
}*/
