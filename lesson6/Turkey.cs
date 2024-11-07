using System;

namespace Lesson6
{
    internal class Turkey : Bird
    {
        public Turkey()
        {
            MeatAmount = 2;
        }

        public int ProduceEggs()
        {
            if (!IsAlive || !IsForEggs) return 0;

            int eggs = level switch
            {
                HungryLevel.Full => 1,      
                HungryLevel.Overfed => 0,   
                _ => 0                      
            };

            // После откладывания яиц индюк становится голодным
            level = HungryLevel.Hungry;
            return eggs;
        }
    }
}
