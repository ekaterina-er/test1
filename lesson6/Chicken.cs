using System;

namespace Lesson6
{
    internal class Chicken : Bird
    {
        public Chicken()
        {
            MeatAmount = 1; // количество мяса для курицы
        }

        public int ProduceEggs()
        {
            if (!IsAlive || !IsForEggs) return 0; 

            int eggs = level switch
            {
                HungryLevel.Full => 2,  
                HungryLevel.Overfed => 1, 
                _ => 0                   
            };

            // После откладывания яиц курица становится голодной
            level = HungryLevel.Hungry;
            return eggs;
        }
    }
}
