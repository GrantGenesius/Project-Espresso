using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_Ingredients : MonoBehaviour
{
    #region parameter setting variables
    int rawMaxValue = 9999;
    int rawHalfValue = 5000;
    int processedMaxValue = 999;
    int processedHalfValue = 500;
    int rareMaxValue = 99;
    int rareHalfValue = 50;
    int MinValue = 1;
    int ZeroValue = 0;
    #endregion

    #region ingredients variables
    //only obtainable
    [ContextMenuItem("Set All Raw to Max", "Raw_Ingredients_ToMax")]
    [ContextMenuItem("Set All Raw to Min", "Raw_Ingredients_ToMin")]
    [ContextMenuItem("Set All Raw to Zero", "Raw_Ingredients_ToZero")]
    [ContextMenuItem("Set All Raw to Half", "Raw_Ingredients_ToHalf")]
    [ContextMenuItem("Set All Raw to Random", "Raw_Ingredients_ToRandom")]
    [Header("Raw Ingredients")]
    [Range(0,9999)]
    public int coffeeSeeds;
    [Range(0, 9999)]
    public int teaLeaves;
    [Range(0, 9999)]
    public int milk;
    [Range(0, 9999)]
    public int sugar;
    [Range(0, 9999)]
    public int water;
    [Range(0, 9999)]
    public int cocoa;

    //craftable and obtainable
    [ContextMenuItem("Set All Processed to Max", "Processed_Ingredients_ToMax")]
    [ContextMenuItem("Set All Processed to Min", "Processed_Ingredients_ToMin")]
    [ContextMenuItem("Set All Processed to Zero", "Processed_Ingredients_ToZero")]
    [ContextMenuItem("Set All Processed to Half", "Processed_Ingredients_ToHalf")]
    [ContextMenuItem("Set All Processed to Random", "Processed_Ingredients_ToRandom")]
    [Header("\t Coffee")]
    [Header("Processed Ingredients")]
    [Range(0, 999)]
    public int espressoShot;
    [Range(0, 999)]
    public int coffeePowder;

        [Header("\t Water")]
    [Range(0, 999)]
    public int iceCubes;
    [Range(0, 999)]
    public int fancyWater;
    [Range(0, 999)]
    public int hotWater;

        [Header("\t Tea")]
    [Range(0, 999)]
    public int chamomileTeaLeaves;
    [Range(0, 999)]
    public int jasmineTeaLeaves;
    [Range(0, 999)]
    public int earlGreyTeaLeaves;
    [Range(0, 999)]
    public int choiTeaLeaves;
    [Range(0, 999)]
    public int mintTeaLeaves;
    [Range(0, 999)]
    public int blackTeaLeaves;
    [Range(0, 999)]
    public int greenTeaLeaves;
    [Range(0, 999)]
    public int englishTeaLeaves;
    [Range(0, 999)]
    public int matchaPowder;

        [Header("\t Chocolate")]
    [Range(0, 999)]
    public int chocolateChips;
    [Range(0, 999)]
    public int chocolatePowder;

        [Header("\t Sugar")]
    [Range(0, 999)]
    public int caramel;
    [Range(0, 999)]
    public int simpleSyrup;
    [Range(0, 999)]
    public int vanillaSyrup;
    [Range(0, 999)]
    public int hazelnutSyrup;
    [Range(0, 999)]
    public int chocolateSyrup;
    [Range(0, 999)]
    public int fruitSyrup;

        [Header("\t Dairy")]
    [Range(0, 999)]
    public int steamedMilk;
    [Range(0, 999)]
    public int milkFoam;
    [Range(0, 999)]
    public int cream;
    [Range(0, 999)]
    public int whippedCream;

    //only obtainable
    [ContextMenuItem("Set All Rare to Max", "Rare_Ingredients_ToMax")]
    [ContextMenuItem("Set All Rare to Min", "Rare_Ingredients_ToMin")]
    [ContextMenuItem("Set All Rare to Zero", "Rare_Ingredients_ToZero")]
    [ContextMenuItem("Set All Rare to Half", "Rare_Ingredients_ToHalf")]
    [ContextMenuItem("Set All Rare to Random", "Rare_Ingredients_ToRandom")]
        [Header("Rare Ingredients")]
    [Range(0, 99)]
    public int oreoCookies;
    [Range(0, 99)]
    public int dolceThingy;
    [Range(0, 99)]
    public int juicePowder;
    #endregion

    #region Sprites
    public Sprite[] ingredientSprites;
    public Sprite[] drinkSprites;
    #endregion

    //brewing ingredients array
    public int[] BrewIngredientsList;

    public static DB_Ingredients instance;

    //singleton code here
    void Awake() 
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        _OnLoadData_Ingredients();
        CreateBrewIngredientArray();
    }

    void OnApplicationQuit() {
        _OnSaveData_Ingredients();
    }

    //called everytime the array value changes via other scenes
    //make context menu here for testing
    [ContextMenu("Update_IngredientArray")]
    public void UpdateIngredientArray() {
        coffeeSeeds         = BrewIngredientsList[0];
        teaLeaves           = BrewIngredientsList[1];
        milk                = BrewIngredientsList[2];
        sugar               = BrewIngredientsList[3];
        water               = BrewIngredientsList[4];
        cocoa               = BrewIngredientsList[5];
        espressoShot        = BrewIngredientsList[6];
        coffeePowder        = BrewIngredientsList[7];
        iceCubes            = BrewIngredientsList[8];
        fancyWater          = BrewIngredientsList[9];
        hotWater            = BrewIngredientsList[10];
        chamomileTeaLeaves  = BrewIngredientsList[11];
        jasmineTeaLeaves    = BrewIngredientsList[12];
        earlGreyTeaLeaves   = BrewIngredientsList[13];
        choiTeaLeaves       = BrewIngredientsList[14];
        mintTeaLeaves       = BrewIngredientsList[15];
        blackTeaLeaves      = BrewIngredientsList[16];
        greenTeaLeaves      = BrewIngredientsList[17];
        englishTeaLeaves    = BrewIngredientsList[18];
        matchaPowder        = BrewIngredientsList[19];
        chocolateChips      = BrewIngredientsList[20];
        chocolatePowder     = BrewIngredientsList[21];
        caramel             = BrewIngredientsList[22];
        simpleSyrup         = BrewIngredientsList[23];
        vanillaSyrup        = BrewIngredientsList[24];
        hazelnutSyrup       = BrewIngredientsList[25];
        chocolateSyrup      = BrewIngredientsList[26];
        fruitSyrup          = BrewIngredientsList[27];
        steamedMilk         = BrewIngredientsList[28];
        milkFoam            = BrewIngredientsList[29];
        cream               = BrewIngredientsList[30];
        whippedCream        = BrewIngredientsList[31];
        oreoCookies         = BrewIngredientsList[32];
        dolceThingy         = BrewIngredientsList[33];
        juicePowder         = BrewIngredientsList[34];
    }

    [ContextMenu("Create_IngredientArray")]
    public void CreateBrewIngredientArray() { 
        BrewIngredientsList = new int[35];
        //raw
        BrewIngredientsList[0] = coffeeSeeds;
        BrewIngredientsList[1] = teaLeaves;
        BrewIngredientsList[2] = milk;
        BrewIngredientsList[3] = sugar;
        BrewIngredientsList[4] = water;
        BrewIngredientsList[5] = cocoa;
        //coffee
        BrewIngredientsList[6] = espressoShot;
        BrewIngredientsList[7] = coffeePowder;
	    //water
        BrewIngredientsList[8] = iceCubes;
        BrewIngredientsList[9] = fancyWater;
        BrewIngredientsList[10] = hotWater;
	    //tea
        BrewIngredientsList[11] = chamomileTeaLeaves;
        BrewIngredientsList[12] = jasmineTeaLeaves;
        BrewIngredientsList[13] = earlGreyTeaLeaves;
        BrewIngredientsList[14] = choiTeaLeaves;
        BrewIngredientsList[15] = mintTeaLeaves;
        BrewIngredientsList[16] = blackTeaLeaves;
        BrewIngredientsList[17] = greenTeaLeaves;
        BrewIngredientsList[18] = englishTeaLeaves;
        BrewIngredientsList[19] = matchaPowder;
	    //chocolate
        BrewIngredientsList[20] = chocolateChips;
        BrewIngredientsList[21] = chocolatePowder;
	    //sugar
        BrewIngredientsList[22] = caramel;
        BrewIngredientsList[23] = simpleSyrup;
        BrewIngredientsList[24] = vanillaSyrup;
        BrewIngredientsList[25] = hazelnutSyrup;
        BrewIngredientsList[26] = chocolateSyrup;
        BrewIngredientsList[27] = fruitSyrup;
	    //dairy
        BrewIngredientsList[28] = steamedMilk;
        BrewIngredientsList[29] = milkFoam;
        BrewIngredientsList[30] = cream;
        BrewIngredientsList[31] = whippedCream;
        //rare
        BrewIngredientsList[32] = oreoCookies;
        BrewIngredientsList[33] = dolceThingy;
        BrewIngredientsList[34] = juicePowder;
    }

    #region savedata functions
    //done
    [ContextMenu("Ingredients_Save")]
    public void _OnSaveData_Ingredients() {
        SaveSystem.SaveData_Ingredients(this);
    }

    //done, not tested
    [ContextMenu("Ingredients_Load")]
    public void _OnLoadData_Ingredients() {
        SavedData savedData = SaveSystem.LoadData_Ingredients();

        //load saved raw ingredients
        //raw 
        coffeeSeeds = savedData.coffeeSeeds;
        teaLeaves   = savedData.teaLeaves;
        milk        = savedData.milk;
        sugar       = savedData.sugar;
        water       = savedData.water;
        cocoa       = savedData.cocoa;

        //processed
	    //coffee
        espressoShot = savedData.espressoShot;
        coffeePowder = savedData.coffeePowder;
	    //water
        iceCubes    = savedData.iceCubes;
        fancyWater  = savedData.fancyWater;
        hotWater    = savedData.hotWater;
	    //tea
        chamomileTeaLeaves  = savedData.chamomileTeaLeaves;
        jasmineTeaLeaves    = savedData.jasmineTeaLeaves;
        earlGreyTeaLeaves   = savedData.earlGreyTeaLeaves;
        choiTeaLeaves       = savedData.choiTeaLeaves;
        mintTeaLeaves       = savedData.mintTeaLeaves;
        blackTeaLeaves      = savedData.blackTeaLeaves;
        greenTeaLeaves      = savedData.greenTeaLeaves;
        englishTeaLeaves    = savedData.englishTeaLeaves;
        matchaPowder        = savedData.matchaPowder;
	    //chocolate
        chocolateChips  = savedData.chocolateChips;
        chocolatePowder = savedData.chocolatePowder;
	    //sugar
        caramel         = savedData.caramel;
        simpleSyrup     = savedData.simpleSyrup;
        vanillaSyrup    = savedData.vanillaSyrup;
        hazelnutSyrup   = savedData.hazelnutSyrup;
        chocolateSyrup  = savedData.chocolateSyrup;
        fruitSyrup      = savedData.fruitSyrup;
	    //dairy
        steamedMilk     = savedData.steamedMilk;
        milkFoam        = savedData.milkFoam;
        cream           = savedData.cream;
        whippedCream    = savedData.whippedCream;

        //rare
        oreoCookies = savedData.oreoCookies;
        dolceThingy = savedData.dolceThingy;
        juicePowder = savedData.juicePowder;
    }
    #endregion

    //a function that takes 2 int parameters, randoms a number between those 2 parameters, and returns an int value
    int randomNumber(int y, int z) {
        int x;
        x = Random.Range(y, z);
        return x;
    }

    #region variable setting functions

    [ContextMenu("Set all ingredients to max value")]
    public void All_Ingredients_ToMax() 
    {
        Raw_Ingredients_ToMax();
        Processed_Ingredients_ToMax();
        Rare_Ingredients_ToMax();
    }
    [ContextMenu("Set all ingredients to min value")]
    public void All_Ingredients_ToMin()
    {
        Raw_Ingredients_ToMin();
        Processed_Ingredients_ToMin();
        Rare_Ingredients_ToMin();
    }
    [ContextMenu("Set all ingredients to zero value")]
    public void All_Ingredients_ToZero()
    {
        Raw_Ingredients_ToZero();
        Processed_Ingredients_ToZero();
        Rare_Ingredients_ToZero();
    }
    [ContextMenu("Set all ingredients to half value")]
    public void All_Ingredients_ToHalf()
    {
        Raw_Ingredients_ToHalf();
        Processed_Ingredients_ToHalf();
        Rare_Ingredients_ToHalf();
    }
    [ContextMenu("Set all ingredients to random value")]
    public void All_Ingredients_ToRandom()
    {
        Raw_Ingredients_ToRandom();
        Processed_Ingredients_ToRandom();
        Rare_Ingredients_ToRandom();
    }

    ////////////////////////////////////////////////////////////Raw ingredients function
    public void Raw_Ingredients_ToMax()
    {
        coffeeSeeds = rawMaxValue;
        teaLeaves   = rawMaxValue;
        sugar       = rawMaxValue;
        cocoa       = rawMaxValue;
        water       = rawMaxValue;
        milk        = rawMaxValue;
    }
    public void Raw_Ingredients_ToMin()
    {
        coffeeSeeds = MinValue;
        teaLeaves   = MinValue;
        sugar       = MinValue;
        cocoa       = MinValue;
        water       = MinValue;
        milk        = MinValue;
    }
    public void Raw_Ingredients_ToZero()
    {
        coffeeSeeds = ZeroValue;
        teaLeaves   = ZeroValue;
        sugar       = ZeroValue;
        cocoa       = ZeroValue;
        water       = ZeroValue;
        milk        = ZeroValue;
    }
    public void Raw_Ingredients_ToHalf()
    {
        coffeeSeeds = rawHalfValue;
        teaLeaves   = rawHalfValue;
        sugar       = rawHalfValue;
        cocoa       = rawHalfValue;
        water       = rawHalfValue;
        milk        = rawHalfValue;
    }
    public void Raw_Ingredients_ToRandom()
    {
        coffeeSeeds = randomNumber(MinValue,rawMaxValue);
        teaLeaves   = randomNumber(MinValue,rawMaxValue);
        sugar       = randomNumber(MinValue,rawMaxValue);
        cocoa       = randomNumber(MinValue,rawMaxValue);
        water       = randomNumber(MinValue,rawMaxValue);
        milk        = randomNumber(MinValue,rawMaxValue);
    }

    /////////////////////////////////////////////////////////////////////processed ingredients functions
    public void Processed_Ingredients_ToMax()
    {
        espressoShot = processedMaxValue;
        coffeePowder = processedMaxValue;
        iceCubes = processedMaxValue;
        fancyWater = processedMaxValue;
        hotWater = processedMaxValue;
        mintTeaLeaves = processedMaxValue;
        jasmineTeaLeaves = processedMaxValue;
        greenTeaLeaves = processedMaxValue;
        englishTeaLeaves = processedMaxValue;
        earlGreyTeaLeaves = processedMaxValue;
        choiTeaLeaves = processedMaxValue;
        chamomileTeaLeaves = processedMaxValue;
        blackTeaLeaves = processedMaxValue;
        matchaPowder = processedMaxValue;
        chocolateChips = processedMaxValue;
        chocolatePowder = processedMaxValue;
        caramel = processedMaxValue;
        simpleSyrup = processedMaxValue;
        chocolateSyrup = processedMaxValue;
        fruitSyrup = processedMaxValue;
        hazelnutSyrup = processedMaxValue;
        vanillaSyrup = processedMaxValue;
        milkFoam = processedMaxValue;
        steamedMilk = processedMaxValue;
        cream = processedMaxValue;
        whippedCream = processedMaxValue;
    }
    public void Processed_Ingredients_ToMin()
    {
        espressoShot    = MinValue;
        coffeePowder    = MinValue;
        iceCubes        = MinValue;
        fancyWater      = MinValue;
        hotWater        = MinValue;
        mintTeaLeaves       = MinValue;
        jasmineTeaLeaves    = MinValue;
        greenTeaLeaves      = MinValue;
        englishTeaLeaves    = MinValue;
        earlGreyTeaLeaves   = MinValue;
        choiTeaLeaves       = MinValue;
        chamomileTeaLeaves  = MinValue;
        blackTeaLeaves      = MinValue;
        matchaPowder        = MinValue;
        chocolateChips  = MinValue;
        chocolatePowder = MinValue;
        caramel         = MinValue;
        simpleSyrup     = MinValue;
        chocolateSyrup  = MinValue;
        fruitSyrup      = MinValue;
        hazelnutSyrup   = MinValue;
        vanillaSyrup    = MinValue;
        milkFoam        = MinValue;
        steamedMilk     = MinValue;
        cream           = MinValue;
        whippedCream    = MinValue;
    }
    public void Processed_Ingredients_ToZero()
    {
        espressoShot    = ZeroValue;
        coffeePowder    = ZeroValue;
        iceCubes        = ZeroValue;
        fancyWater      = ZeroValue;
        hotWater        = ZeroValue;
        mintTeaLeaves       = ZeroValue;
        jasmineTeaLeaves    = ZeroValue;
        greenTeaLeaves      = ZeroValue;
        englishTeaLeaves    = ZeroValue;
        earlGreyTeaLeaves   = ZeroValue;
        choiTeaLeaves       = ZeroValue;
        chamomileTeaLeaves  = ZeroValue;
        blackTeaLeaves      = ZeroValue;
        matchaPowder        = ZeroValue;
        chocolateChips  = ZeroValue;
        chocolatePowder = ZeroValue;
        caramel         = ZeroValue;
        simpleSyrup     = ZeroValue;
        chocolateSyrup  = ZeroValue;
        fruitSyrup      = ZeroValue;
        hazelnutSyrup   = ZeroValue;
        vanillaSyrup    = ZeroValue;
        milkFoam        = ZeroValue;
        steamedMilk     = ZeroValue;
        cream           = ZeroValue;
        whippedCream    = ZeroValue;
    }
    public void Processed_Ingredients_ToHalf()
    {
        espressoShot    = processedHalfValue;
        coffeePowder    = processedHalfValue;
        iceCubes        = processedHalfValue;
        fancyWater      = processedHalfValue;
        hotWater        = processedHalfValue;
        mintTeaLeaves       = processedHalfValue;
        jasmineTeaLeaves    = processedHalfValue;
        greenTeaLeaves      = processedHalfValue;
        englishTeaLeaves    = processedHalfValue;
        earlGreyTeaLeaves   = processedHalfValue;
        choiTeaLeaves       = processedHalfValue;
        chamomileTeaLeaves  = processedHalfValue;
        blackTeaLeaves      = processedHalfValue;
        matchaPowder        = processedHalfValue;
        chocolateChips  = processedHalfValue;
        chocolatePowder = processedHalfValue;
        caramel         = processedHalfValue;
        simpleSyrup     = processedHalfValue;
        chocolateSyrup  = processedHalfValue;
        fruitSyrup      = processedHalfValue;
        hazelnutSyrup   = processedHalfValue;
        vanillaSyrup    = processedHalfValue;
        milkFoam        = processedHalfValue;
        steamedMilk     = processedHalfValue;
        cream           = processedHalfValue;
        whippedCream    = processedHalfValue;
    }
    public void Processed_Ingredients_ToRandom()
    {
        espressoShot    = randomNumber(MinValue,processedMaxValue);
        coffeePowder    = randomNumber(MinValue,processedMaxValue);
        iceCubes        = randomNumber(MinValue,processedMaxValue);
        fancyWater      = randomNumber(MinValue,processedMaxValue);
        hotWater        = randomNumber(MinValue,processedMaxValue);
        mintTeaLeaves       = randomNumber(MinValue,processedMaxValue);
        jasmineTeaLeaves    = randomNumber(MinValue,processedMaxValue);
        greenTeaLeaves      = randomNumber(MinValue,processedMaxValue);
        englishTeaLeaves    = randomNumber(MinValue,processedMaxValue);
        earlGreyTeaLeaves   = randomNumber(MinValue,processedMaxValue);
        choiTeaLeaves       = randomNumber(MinValue,processedMaxValue);
        chamomileTeaLeaves  = randomNumber(MinValue,processedMaxValue);
        blackTeaLeaves      = randomNumber(MinValue,processedMaxValue);
        matchaPowder        = randomNumber(MinValue,processedMaxValue);
        chocolateChips  = randomNumber(MinValue,processedMaxValue);
        chocolatePowder = randomNumber(MinValue,processedMaxValue);
        caramel         = randomNumber(MinValue,processedMaxValue);
        simpleSyrup     = randomNumber(MinValue,processedMaxValue);
        chocolateSyrup  = randomNumber(MinValue,processedMaxValue);
        fruitSyrup      = randomNumber(MinValue,processedMaxValue);
        hazelnutSyrup   = randomNumber(MinValue,processedMaxValue);
        vanillaSyrup    = randomNumber(MinValue,processedMaxValue);
        milkFoam        = randomNumber(MinValue,processedMaxValue);
        steamedMilk     = randomNumber(MinValue,processedMaxValue);
        cream           = randomNumber(MinValue,processedMaxValue);
        whippedCream    = randomNumber(MinValue,processedMaxValue);
    }

    //////////////////////////////////////////////////////////rare ingredients functions
    public void Rare_Ingredients_ToMax()
    {
        oreoCookies = rareMaxValue;
        dolceThingy = rareMaxValue;
        juicePowder = rareMaxValue;
    }
    public void Rare_Ingredients_ToMin()
    {
        oreoCookies = MinValue;
        dolceThingy = MinValue;
        juicePowder = MinValue;
    }
    public void Rare_Ingredients_ToZero()
    {
        oreoCookies = ZeroValue;
        dolceThingy = ZeroValue;
        juicePowder = ZeroValue;
    }
    public void Rare_Ingredients_ToHalf()
    {
        oreoCookies = rareHalfValue;
        dolceThingy = rareHalfValue;
        juicePowder = rareHalfValue;
    }
    public void Rare_Ingredients_ToRandom()
    {
        oreoCookies = randomNumber(MinValue, rareMaxValue);
        dolceThingy = randomNumber(MinValue, rareMaxValue);
        juicePowder = randomNumber(MinValue, rareMaxValue);
    }
    #endregion
}
