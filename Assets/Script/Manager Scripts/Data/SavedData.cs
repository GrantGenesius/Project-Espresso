using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedData
{
    //raw 
    public int coffeeSeeds;
    public int teaLeaves;
    public int milk;
    public int sugar;
    public int water;
    public int cocoa;

    //processed
	    //coffee
    public int espressoShot;
    public int coffeePowder;
	    //water
    public int iceCubes;
    public int fancyWater;
    public int hotWater;
	    //tea
    public int chamomileTeaLeaves;
    public int jasmineTeaLeaves;
    public int earlGreyTeaLeaves;
    public int choiTeaLeaves;
    public int mintTeaLeaves;
    public int blackTeaLeaves;
    public int greenTeaLeaves;
    public int englishTeaLeaves;
    public int matchaPowder;
	    //chocolate
    public int chocolateChips;
    public int chocolatePowder;
	    //sugar
    public int caramel;
    public int simpleSyrup;
    public int vanillaSyrup;
    public int hazelnutSyrup;
    public int chocolateSyrup;
    public int fruitSyrup;
	    //dairy
    public int steamedMilk;
    public int milkFoam;
    public int cream;
    public int whippedCream;

    //rare
    public int oreoCookies;
    public int dolceThingy;
    public int juicePowder;

    public SavedData(DB_Ingredients dbi) 
    {
        //raw 
        coffeeSeeds = dbi.coffeeSeeds;
        teaLeaves   = dbi.teaLeaves;
        milk        = dbi.milk;
        sugar       = dbi.sugar;
        water       = dbi.water;
        cocoa       = dbi.cocoa;

        //processed
	    //coffee
        espressoShot = dbi.espressoShot;
        coffeePowder = dbi.coffeePowder;
	    //water
        iceCubes    = dbi.iceCubes;
        fancyWater  = dbi.fancyWater;
        hotWater    = dbi.hotWater;
	    //tea
        chamomileTeaLeaves  = dbi.chamomileTeaLeaves;
        jasmineTeaLeaves    = dbi.jasmineTeaLeaves;
        earlGreyTeaLeaves   = dbi.earlGreyTeaLeaves;
        choiTeaLeaves       = dbi.choiTeaLeaves;
        mintTeaLeaves       = dbi.mintTeaLeaves;
        blackTeaLeaves      = dbi.blackTeaLeaves;
        greenTeaLeaves      = dbi.greenTeaLeaves;
        englishTeaLeaves    = dbi.englishTeaLeaves;
        matchaPowder        = dbi.matchaPowder;
	    //chocolate
        chocolateChips  = dbi.chocolateChips;
        chocolatePowder = dbi.chocolatePowder;
	    //sugar
        caramel         = dbi.caramel;
        simpleSyrup     = dbi.simpleSyrup;
        vanillaSyrup    = dbi.vanillaSyrup;
        hazelnutSyrup   = dbi.hazelnutSyrup;
        chocolateSyrup  = dbi.chocolateSyrup;
        fruitSyrup      = dbi.fruitSyrup;
	    //dairy
        steamedMilk     = dbi.steamedMilk;
        milkFoam        = dbi.milkFoam;
        cream           = dbi.cream;
        whippedCream    = dbi.whippedCream;

        //rare
        oreoCookies = dbi.oreoCookies;
        dolceThingy = dbi.dolceThingy;
        juicePowder = dbi.juicePowder;
    }
}
