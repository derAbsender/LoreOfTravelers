using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoyalRush : EffectHub
{
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void royalRushEffect(BattlePosition target)
	{
		if (Random.Range(0,100) < 24)
		{			
			target.FIGURE.SWARMED = true;
		}
	}
}
