namespace AdventOfCode_1
{
    public static class BasementTracker
    {
        static private bool basementFound = false;

        static public bool basementHasBeenFound()
            { return basementFound; }

        static public void foundBasement()
            { basementFound = true; }

        static private uint basementPosition = 0;

        static public uint getBasementPosition()
            { return basementPosition;  }

        static public void incBasementPosition()
            { basementPosition++; }

        static public void reset()
        {
            basementFound = false;
            basementPosition = 0;
        }

    }
}