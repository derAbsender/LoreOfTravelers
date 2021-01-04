using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 
	 https://forum.unity.com/threads/solved-best-way-to-script-elemental-damage-fire-earth-water.262622/
	 USER : Senshi
	 DATE : 21.10.2014
	 Number : #17 
	 
	 */


public enum Element { Bestial, Individual, Constructual, Botanical, Insectal, Animal, Yellow, Red, Blue, Purple, Green, Orange, White, Black, None };

public class Elements : MonoBehaviour
{
	Dictionary<Element, Element[]> doubleDamage = new Dictionary<Element, Element[]>();
	Dictionary<Element, Element[]> tripleDamage = new Dictionary<Element, Element[]>();
	Dictionary<Element, Element[]> halfDamage = new Dictionary<Element, Element[]>();
	Dictionary<Element, Element[]> oneAndHalfDamage = new Dictionary<Element, Element[]>();


	// Start is called before the first frame update
	void Start()
	{
		doubleDamage.Add(Element.Bestial, new Element[] { Element.Yellow, Element.Individual, Element.Animal, Element.Black });
		halfDamage.Add(Element.Bestial, new Element[] { Element.Orange, Element.Purple, Element.Constructual, Element.Botanical });

		doubleDamage.Add(Element.Individual, new Element[] { Element.Constructual, Element.Green, Element.Black });
		halfDamage.Add(Element.Individual, new Element[] { Element.Yellow, Element.Purple, Element.Insectal });

		doubleDamage.Add(Element.Constructual, new Element[] { Element.Yellow, Element.Purple, Element.Animal, Element.Black });
		halfDamage.Add(Element.Constructual, new Element[] { Element.Red, Element.Blue, Element.Orange, Element.Green, Element.Individual });

		doubleDamage.Add(Element.Botanical, new Element[] { Element.Red, Element.Orange, Element.Bestial, Element.Black });
		halfDamage.Add(Element.Botanical, new Element[] { Element.Yellow, Element.Insectal, Element.Animal });

		doubleDamage.Add(Element.Insectal, new Element[] { Element.Blue, Element.Black, Element.Botanical });
		halfDamage.Add(Element.Insectal, new Element[] { Element.Red, Element.Green, Element.Constructual });

		doubleDamage.Add(Element.Animal, new Element[] { Element.Orange, Element.Black, Element.Botanical });
		halfDamage.Add(Element.Animal, new Element[] { Element.Blue, Element.Purple, Element.Bestial });

		doubleDamage.Add(Element.Yellow, new Element[] { Element.Red, Element.Black, Element.None, Element.Bestial, Element.Botanical, Element.Insectal });
		halfDamage.Add(Element.Yellow, new Element[] { Element.Blue, Element.Orange });
		oneAndHalfDamage.Add(Element.Yellow, new Element[] { Element.Constructual });
		tripleDamage.Add(Element.Yellow, new Element[] { Element.Individual, Element.Animal });

		doubleDamage.Add(Element.Red, new Element[] { Element.Blue, Element.Black, Element.None, Element.Individual, Element.Bestial, Element.Insectal, Element.Animal });
		halfDamage.Add(Element.Red, new Element[] { Element.Yellow, Element.Purple });
		oneAndHalfDamage.Add(Element.Red, new Element[] { Element.Botanical });
		tripleDamage.Add(Element.Red, new Element[] { Element.Constructual });

		doubleDamage.Add(Element.Blue, new Element[] { Element.Yellow, Element.Black, Element.None, Element.Animal, Element.Bestial, Element.Constructual, Element.Botanical, Element.Insectal });
		halfDamage.Add(Element.Blue, new Element[] { Element.Red, Element.Green });
		tripleDamage.Add(Element.Blue, new Element[] { Element.Individual });

		doubleDamage.Add(Element.Purple, new Element[] { Element.Yellow, Element.Red, Element.Purple, Element.Black, Element.None, Element.Botanical, Element.Insectal });
		halfDamage.Add(Element.Purple, new Element[] { Element.Orange });
		oneAndHalfDamage.Add(Element.Purple, new Element[] { Element.Constructual });
		tripleDamage.Add(Element.Purple, new Element[] { Element.Bestial, Element.Individual, Element.Animal });

		doubleDamage.Add(Element.Green, new Element[] { Element.Blue, Element.Red, Element.Green, Element.Black, Element.None, Element.Individual, Element.Bestial, Element.Insectal, Element.Animal });
		halfDamage.Add(Element.Green, new Element[] { Element.Purple });
		tripleDamage.Add(Element.Green, new Element[] { Element.Constructual, Element.Botanical });

		doubleDamage.Add(Element.Orange, new Element[] { Element.Yellow, Element.Blue, Element.Orange, Element.Black, Element.None, Element.Constructual, Element.Botanical });
		halfDamage.Add(Element.Orange, new Element[] { Element.Green });
		tripleDamage.Add(Element.Orange, new Element[] { Element.Individual, Element.Bestial, Element.Insectal, Element.Animal });

		doubleDamage.Add(Element.Black, new Element[] { Element.Yellow, Element.Red, Element.Purple, Element.Black, Element.Blue, Element.Green, Element.Orange, Element.None });
		oneAndHalfDamage.Add(Element.Black, new Element[] { Element.White });
		tripleDamage.Add(Element.Black, new Element[] { Element.Bestial, Element.Constructual, Element.Individual, Element.Botanical, Element.Animal, Element.Insectal });

		oneAndHalfDamage.Add(Element.White, new Element[] { Element.Black, Element.Constructual, Element.Individual, Element.Bestial, Element.Animal, Element.Botanical, Element.Insectal });
	}

	// Update is called once per frame
	void Update()
	{

	}

	public float CalculateDamage(Element[] userElements, Element sourceElement, Element[] targetElements)
	{
		float multiplier = 1f;
		foreach (Element elem in targetElements)
		{
			if (doubleDamage.ContainsKey(sourceElement))
			{
				for (int i = 0; i < doubleDamage[sourceElement].Length; i++)
				{
					if (doubleDamage[sourceElement][i] == elem)
					{
						Debug.Log("NO");
						multiplier *= 2;
					}
				}
			}

			if (tripleDamage.ContainsKey(sourceElement))
			{
				for (int i = 0; i < tripleDamage[sourceElement].Length; i++)
				{
					if (tripleDamage[sourceElement][i] == elem)
					{
						multiplier *= 3;
					}
				}
			}

			if (halfDamage.ContainsKey(sourceElement))
			{
				for (int i = 0; i < halfDamage[sourceElement].Length; i++)
				{
					if (halfDamage[sourceElement][i] == elem)
					{
						multiplier *= 0.5f;
					}
				}
			}
			if (oneAndHalfDamage.ContainsKey(sourceElement))
			{
				for (int i = 0; i < oneAndHalfDamage[sourceElement].Length; i++)
				{
					if (oneAndHalfDamage[sourceElement][i] == elem)
					{
						multiplier *= 1.5f;
					}
				}
			}
		}

		foreach (var element in userElements)
		{
			if (element != Element.None && element == sourceElement)
			{
				
				multiplier *= 2;
			}
		}

		return multiplier;
	}
}
