static class QuestLogic
{
    public static bool CanFastAttack(bool knightIsAwake)
    {
        bool canFastAttack = knightIsAwake ? false : true;

        return canFastAttack;
    }

    public static bool CanSpy(bool knightIsAwake, bool archerIsAwake, bool prisonerIsAwake)
    {
        bool canSpy = (knightIsAwake || archerIsAwake || prisonerIsAwake) ? true : false;

        return canSpy;
    }

    public static bool CanSignalPrisoner(bool archerIsAwake, bool prisonerIsAwake)
    {
        bool canSignalPrisoner = (!archerIsAwake && prisonerIsAwake) ? true : false;

        return canSignalPrisoner;
    }

    public static bool CanFreePrisoner(bool knightIsAwake, bool archerIsAwake, bool prisonerIsAwake, bool petDogIsPresent)
    {
        bool canFreePrisoner;

        if(petDogIsPresent)
        {
            canFreePrisoner = !archerIsAwake ? true : false;
        }
        else
        {
            canFreePrisoner = (prisonerIsAwake && !knightIsAwake && !archerIsAwake) ? true : false;
        }

        return canFreePrisoner;
    }
}
