using System;

namespace Lesson6
{
    internal class Chicken : Bird
    {
        public Chicken()
        {
            MeatAmount = 1; // ���������� ���� ��� ������
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

            // ����� ������������ ��� ������ ���������� ��������
            level = HungryLevel.Hungry;
            return eggs;
        }
    }
}
