using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public enum PositionType { flight, spawn, normal, illegitimate };

public class BattlePosition : MonoBehaviour
{
	//public string TESTFIELD = "";




	[SerializeField]
	public Text CoordDisplay;


	private bool isLegitimateField;

	public bool IS_LEGITIMATEFIELD
	{
		get { return isLegitimateField; }
		set { isLegitimateField = value; }
	}	

	private PositionType positionType;

	public PositionType POS_TYPE
	{
		get { return positionType; }
		set { positionType = value; }
	}

	[SerializeField]
	private int columnCoordinate;

	public int COL_COORD
	{
		get { return columnCoordinate; }
		set { columnCoordinate = value; }
	}
	[SerializeField]
	private int rowCoordinate;
	
	public int ROW_COORD
	{
		get { return rowCoordinate; }
		set { rowCoordinate = value; }
	}

	[SerializeField]
	private bool isAlly;

	public bool IS_ALLY
	{
		get { return isAlly; }
		set { isAlly = value; }
	}

	[SerializeField]
	private string id;

	public string PositionID
	{
		get { return id; }
		set { id = value; }
	}

	[SerializeField]
	private bool isNeighboring;

	public bool IS_NEIGHBORING
	{
		get { return isNeighboring; }
		set { isNeighboring = value; }
	}



	[SerializeField]
	private Combatant figure;

	public Combatant FIGURE
	{
		get { return figure; }
		set { figure = value; }
	}

	[SerializeField]
	Image positionImage;

	[SerializeField]
	private bool isFront;

	public bool IS_FRONT
	{
		get { return isFront; }
		set { isFront = value; }
	}



	[SerializeField]//für spätere Fomrationsmöglichkeiten?
	Vector3 positionVector;

	[SerializeField]
	private bool currentlyOccupied;

	public bool CURRENTLY_OCCUPIED
	{
		get { return currentlyOccupied; }
		set { currentlyOccupied = value; }
	}

	[SerializeField]
	private BattlePosition emptyPosition;

	[SerializeField]
	private List<BattlePosition> borderingTiles;

	public List<BattlePosition> BORDERING_TILES
	{
		get { return borderingTiles; }
		set { borderingTiles = value; }
	}

	[SerializeField]
	private List<BattlePosition> furtherBorderingTiles;

	public List<BattlePosition> FURTHER_BORDERING_TILES
	{
		get { return furtherBorderingTiles; }
		set { furtherBorderingTiles = value; }
	}

	[SerializeField]
	private BattlePosition Top;

	public BattlePosition TOP
	{
		get { return Top; }
		set { Top = value; }
	}
	[SerializeField]
	private BattlePosition Bottom;

	public BattlePosition BOTTOM
	{
		get { return Bottom; }
		set { Bottom = value; }
	}
	[SerializeField]
	private BattlePosition DownMonitorRight;

	public BattlePosition DOWN_RIGHT
	{
		get { return DownMonitorRight; }
		set { DownMonitorRight = value; }
	}
	[SerializeField]
	private BattlePosition UpMonitorRight;

	public BattlePosition UP_RIGHT
	{
		get { return UpMonitorRight; }
		set { UpMonitorRight = value; }
	}
	[SerializeField]
	private BattlePosition UpMonitorLeft;

	public BattlePosition UP_LEFT
	{
		get { return UpMonitorLeft; }
		set { UpMonitorLeft = value; }
	}
	[SerializeField]
	private BattlePosition DownMonitorLeft;

	public BattlePosition DOWN_LEFT
	{
		get { return DownMonitorLeft; }
		set { DownMonitorLeft = value; }
	}
	[SerializeField]
	private BattlePosition MonitorLeftExtend;

	public BattlePosition MONITOR_LEFT_EXTEND
	{
		get { return MonitorLeftExtend; }
		set { MonitorLeftExtend = value; }
	}
	[SerializeField]
	private BattlePosition MonitorRightExtend;

	public BattlePosition MONITOR_RIGHT_EXTEND
	{
		get { return MonitorRightExtend; }
		set { MonitorRightExtend = value; }
	}
	[SerializeField]
	private BattlePosition MonitorleftUpExtend;

	public BattlePosition MONITOR_LEFTUP_EXTEND
	{
		get { return MonitorleftUpExtend; }
		set { MonitorleftUpExtend = value; }
	}
	[SerializeField]
	private BattlePosition MonitorleftDownExtend;

	public BattlePosition MONITOR_LEFDOWN_EXTEND
	{
		get { return MonitorleftDownExtend; }
		set { MonitorleftDownExtend = value; }
	}
	[SerializeField]
	private BattlePosition MonitoRightUExtend;

	public BattlePosition MONITOR_RIGHTUP_EXTEND
	{
		get { return MonitoRightUExtend; }
		set { MonitoRightUExtend = value; }
	}
	[SerializeField]
	private BattlePosition MonitorRightDownExtend;

	public BattlePosition MONITOR_RIGHTDOWN_EXTEND
	{
		get { return MonitorRightDownExtend; }
		set { MonitorRightDownExtend = value; }
	}

	[SerializeField]
	BattlePosition battlePositionConvert;

	[SerializeField]
	private bool isCenter;

	public bool IS_CENTER
	{
		get { return isCenter; }
		set { isCenter = value; }
	}


	[SerializeField]
	private List<List<BattlePosition>> areaTiles = new List<List<BattlePosition>>();

	public List<List<BattlePosition>> AREA_TILES
	{
		get { return areaTiles; }
		set { areaTiles = value; }
	}

	[SerializeField]
	private List<BattlePosition> temporarySingleAreaField;

	public List<BattlePosition> TEMP_SING_AREA_FIELD
	{
		get { return temporarySingleAreaField; }
		set { temporarySingleAreaField = value; }
	}

	[SerializeField]
	private List<List<BattlePosition>> impactTiles = new List<List<BattlePosition>> ();

	public List<List<BattlePosition>> IMPACT_TILES
	{
		get { return impactTiles; }
		set { impactTiles = value; }
	}


	// Start is called before the first frame update
	void Start()
    {

		currentlyOccupied = false;
		isLegitimateField = true;
		positionType = PositionType.spawn;
		isNeighboring = false;



		//foreach (var item in BattleMaster.instance.INDIPOS)
		//{
		//	spotBorderingTiles(this, item);
		//}	

		//id = name;
		positionVector = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

		//self = new Coordinate(id);

		//Here I may be able to manipulate the starting position in the fight
		//via id and positionVector
	}

	public bool isContained(string key)
	{

		//Debug.Log(key);
		string[] coord = key.Split(',');
		int[] coordInt = new int[2];
		for (int i = 0; i < coord.Length; i++)
		{
			coord[i] = coord[i].Substring(3);
			int.TryParse(coord[i], out coordInt[i]);
		}
		if (coordInt[0] == ROW_COORD && coordInt[1] == COL_COORD)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public bool isOccupied()
	{
		if (gameObject.GetComponentInChildren<Combatant>())
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	public bool deleteCombatant()
	{
		//Debug.Log(id);

		if (CURRENTLY_OCCUPIED)
		{
			
			Destroy(gameObject.GetComponentInChildren<Combatant>().gameObject);
			return true;
		}
		else
		{
			
			return false;
		}
	}

	public void setID(int rc, int cc)
	{
		//Debug.Log(rc+","+cc);
		id = "RC_" + rc + ",CC_" + cc;
		ROW_COORD = rc;
		COL_COORD = cc;
	}


	public BattlePosition initializeEmptyPosition()
	{
		//emptyPosition = new BattlePosition();
		emptyPosition.IS_LEGITIMATEFIELD = true;
		emptyPosition.POS_TYPE = PositionType.illegitimate;
		emptyPosition.IS_NEIGHBORING = false;
		emptyPosition.CURRENTLY_OCCUPIED = false;
		emptyPosition.ROW_COORD = -1;
		emptyPosition.COL_COORD = -1;

		emptyPosition.id = "XXXXX";

		//Debug.Log(emptyPosition.id);

		return emptyPosition;
	}


	public void spotBorderingTiles(BattlePosition center, BattlePosition toSpot)
	{
		//Debug.Log(currentPosition.ROW_COORD);
		if (toSpot.ROW_COORD == center.ROW_COORD - 1 && toSpot.COL_COORD == center.COL_COORD)
		{
			borderingTiles.Add(toSpot);
			Top = toSpot;
			//StoSpot.TESTFIELD = "TOP";
			toSpot.IS_NEIGHBORING = true;

		}
		else if (toSpot.ROW_COORD == center.ROW_COORD + 1 && toSpot.COL_COORD == center.COL_COORD)
		{
			borderingTiles.Add(toSpot);
			Bottom = toSpot;

			toSpot.IS_NEIGHBORING = true;
		}
		else if (center.COL_COORD % 2 == 0)
		{
			if (toSpot.COL_COORD == center.COL_COORD + 1 && toSpot.ROW_COORD == center.ROW_COORD)
			{
				borderingTiles.Add(toSpot);
				DownMonitorRight = toSpot;

				toSpot.IS_NEIGHBORING = true;

			}
			else if (toSpot.COL_COORD == center.COL_COORD + 1 && toSpot.ROW_COORD == center.ROW_COORD - 1)
			{
				borderingTiles.Add(toSpot);
				UpMonitorRight = toSpot;
				//toSpot.TESTFIELD = "UPRIGHT";

				toSpot.IS_NEIGHBORING = true;

			}
			else if (toSpot.COL_COORD == center.COL_COORD - 1 && toSpot.ROW_COORD == center.ROW_COORD)
			{
				borderingTiles.Add(toSpot);
				DownMonitorLeft = toSpot;

				toSpot.IS_NEIGHBORING = true;

			}
			else if (toSpot.COL_COORD == center.COL_COORD - 1 && toSpot.ROW_COORD == center.ROW_COORD - 1)
			{
				borderingTiles.Add(toSpot);
				UpMonitorLeft = toSpot;
				//toSpot.TESTFIELD = "UPLEFT";

				toSpot.IS_NEIGHBORING = true;

			}
		}
		else
		{
			if (toSpot.COL_COORD == center.COL_COORD - 1 && toSpot.ROW_COORD == center.ROW_COORD)
			{
				borderingTiles.Add(toSpot);
				UpMonitorLeft = toSpot;
				//toSpot.TESTFIELD = "UPLEFT";

				toSpot.IS_NEIGHBORING = true;

			}
			else if (toSpot.COL_COORD == center.COL_COORD - 1 && toSpot.ROW_COORD == center.ROW_COORD + 1)
			{
				borderingTiles.Add(toSpot);
				DownMonitorLeft = toSpot;
				//toSpot.TESTFIELD = "DOWNLEFT";

				toSpot.IS_NEIGHBORING = true;

			}
			else if (toSpot.COL_COORD == center.COL_COORD + 1 && toSpot.ROW_COORD == center.ROW_COORD)
			{
				borderingTiles.Add(toSpot);
				UpMonitorRight = toSpot;
				//toSpot.TESTFIELD = "UPRIGHT";

				toSpot.IS_NEIGHBORING = true;

			}
			else if (toSpot.COL_COORD == center.COL_COORD + 1 && toSpot.ROW_COORD == center.ROW_COORD + 1)
			{
				borderingTiles.Add(toSpot);
				DownMonitorRight = toSpot;
				//toSpot.TESTFIELD = "DOWNRIGHT";

				toSpot.IS_NEIGHBORING = true;

			}
		}

	}

	public void spotFurtherBorderingTiles(BattlePosition center, BattlePosition toSpot)
	{


		if (toSpot.ROW_COORD == center.ROW_COORD && toSpot.COL_COORD == center.COL_COORD - 2)
		{
			furtherBorderingTiles.Add(toSpot);
			MonitorLeftExtend = toSpot;
		}
		else if (toSpot.ROW_COORD == center.ROW_COORD && toSpot.COL_COORD == center.COL_COORD + 2)
		{
			furtherBorderingTiles.Add(toSpot);
			MonitorRightExtend = toSpot;

		}

		if (center.COL_COORD % 2 == 0)
		{
			if (toSpot.ROW_COORD == center.ROW_COORD + 1 && toSpot.COL_COORD == center.COL_COORD - 1)
			{
				furtherBorderingTiles.Add(toSpot);
				MonitorleftDownExtend = toSpot;
			}
			else if (toSpot.ROW_COORD == center.ROW_COORD + 1 && toSpot.COL_COORD == center.COL_COORD + 1)
			{
				furtherBorderingTiles.Add(toSpot);
				MonitorRightDownExtend = toSpot;
			}
			else if (toSpot.ROW_COORD == center.ROW_COORD - 2 && toSpot.COL_COORD == center.COL_COORD + 1)
			{
				furtherBorderingTiles.Add(toSpot);
				MonitoRightUExtend = toSpot;

			}
			else if (toSpot.ROW_COORD == center.ROW_COORD - 2 && toSpot.COL_COORD == center.COL_COORD - 1)
			{
				furtherBorderingTiles.Add(toSpot);
				MonitorleftUpExtend = toSpot; ;
			}
		}
		else
		{
			if (toSpot.ROW_COORD == center.ROW_COORD + 2 && toSpot.COL_COORD == center.COL_COORD - 1)
			{
				furtherBorderingTiles.Add(toSpot);
				MonitorleftDownExtend = toSpot;
			}
			else if (toSpot.ROW_COORD == center.ROW_COORD + 2 && toSpot.COL_COORD == center.COL_COORD + 1)
			{
				furtherBorderingTiles.Add(toSpot);
				MonitorRightDownExtend = toSpot;
			}
			else if (toSpot.ROW_COORD == center.ROW_COORD - 1 && toSpot.COL_COORD == center.COL_COORD + 1)
			{
				furtherBorderingTiles.Add(toSpot);
				MonitoRightUExtend = toSpot;
			}
			else if (toSpot.ROW_COORD == center.ROW_COORD - 1 && toSpot.COL_COORD == center.COL_COORD - 1)
			{
				furtherBorderingTiles.Add(toSpot);
				MonitorleftUpExtend = toSpot;
			}
		}
		//}

	}

	public List<List<BattlePosition>> spotAreaFields(BattlePosition center)
	{
		center.areaTiles.Add(spotArea(center, center.MONITOR_RIGHT_EXTEND, center.DOWN_RIGHT, center.UP_RIGHT));
		center.areaTiles.Add(spotArea(center, center.MONITOR_LEFT_EXTEND, center.DOWN_LEFT, center.UP_LEFT));
		center.areaTiles.Add(spotArea(center, center.MONITOR_RIGHTUP_EXTEND, center.TOP, center.UP_RIGHT));
		center.areaTiles.Add(spotArea(center, center.MONITOR_LEFTUP_EXTEND, center.TOP, center.UP_LEFT));
		center.areaTiles.Add(spotArea(center, center.MONITOR_RIGHTDOWN_EXTEND, center.DOWN_RIGHT, center.BOTTOM));
		center.areaTiles.Add(spotArea(center, center.MONITOR_LEFDOWN_EXTEND, center.DOWN_LEFT, center.BOTTOM));

		return center.areaTiles;
	}

	
	public List<BattlePosition> spotArea(BattlePosition center, BattlePosition decider, BattlePosition close1, BattlePosition close2)
	{
		//Debug.Log(combatant.NAME + "CurPos:" + combatant.CURR_POS.PositionID + "spotRegularRightArea:");

		temporarySingleAreaField = new List<BattlePosition>();
		battlePositionConvert = new BattlePosition();
		
		//Debug.Log("temporarySingleArea:" + temporarySingleAreaField.Count);

		if (decider == null)
		{
			
			decider = battlePositionConvert;
			battlePositionConvert.POS_TYPE = PositionType.illegitimate;
			temporarySingleAreaField.Add(battlePositionConvert);
			//Debug.Log("TEMPID---------------------"+temporarySingleAreaField[0].PositionID);
		}
		else
		{
			temporarySingleAreaField.Add(decider);
		}

		if (close1 == null)
		{

			close1 = battlePositionConvert;
			battlePositionConvert.POS_TYPE = PositionType.illegitimate;
			temporarySingleAreaField.Add(battlePositionConvert);
			//Debug.Log("TEMPID---------------------"+temporarySingleAreaField[0].PositionID);
		}
		else
		{
			temporarySingleAreaField.Add(close1);
		}

		if (close2 == null)
		{

			close2 = battlePositionConvert;
			battlePositionConvert.POS_TYPE = PositionType.illegitimate;
			temporarySingleAreaField.Add(battlePositionConvert);
			//Debug.Log("TEMPID---------------------"+temporarySingleAreaField[0].PositionID);
		}
		else
		{
			temporarySingleAreaField.Add(close2);
		}
		return temporarySingleAreaField;
	}
	

	public List<BattlePosition> spotImpactZones(BattlePosition center)
	{
		temporarySingleAreaField = new List<BattlePosition>();

		center.BORDERING_TILES.Clear();

		//Debug.Log(center.PositionID);
		foreach (var tile in BattleMaster.instance.INDIPOS)
		{
			center.spotBorderingTiles(center, tile);			
		}

		//Debug.Log(center.PositionID);
		//Debug.Log(center.BORDERING_TILES.Count);

		if (center != null || center.POS_TYPE != PositionType.illegitimate)
		{
			temporarySingleAreaField.Add(center);
		}

		for (int i = 1; i < center.BORDERING_TILES.Count+1; i++)
		{
			temporarySingleAreaField.Add(center.BORDERING_TILES[i-1]);
			//Debug.Log(center.BORDERING_TILES[i].PositionID);
		}
		//if (center.BORDERING_TILES.Count < 7)
		//{
		//	for (int i = center.BORDERING_TILES.Count; i < 7; i++)
		//	{
				
		//		temporarySingleAreaField.Add(battlePositionConvert);
		//	}
		//}

		return temporarySingleAreaField;
	}

	public List<List<BattlePosition>> addImpactZones(BattlePosition center)
	{
		//string posId = center.PositionID;
		foreach (var extend in center.FURTHER_BORDERING_TILES)
		{
			//Debug.Log(extend.PositionID);
			center.impactTiles.Add(spotImpactZones(extend));
		}
		//center.PositionID = posId;
		return center.impactTiles;
	}

	public void spotSurroundings(BattlePosition center)
	{
		for (int i = 0; i < BattleMaster.instance.INDIPOS.Length; i++)
		{
			spotBorderingTiles(center, BattleMaster.instance.INDIPOS[i]);
			spotFurtherBorderingTiles(center, BattleMaster.instance.INDIPOS[i]);
		}
		spotAreaFields(center);
		addImpactZones(center);


	}

	private BattlePosition convertToBattlePosition(string coord)
	{

		foreach (var position in BattleMaster.instance.INDIPOS)
		{
			if (coord == "RC_" + position.ROW_COORD + ",CC_" + position.COL_COORD)
			{
				battlePositionConvert = position;
				break;
			}
		}

		return battlePositionConvert;
	}
}
