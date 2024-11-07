namespace Lesson6
{
    // Перечисление уровней голода
    enum HungryLevel
    {
        Hungry,   
        Full,     
        Overfed   
    }

    // Основной класс Bird, представляющий птицу
    internal class Bird
    {
        // Флаг, указывающий на то, жива ли птица
        public bool IsAlive { get; set; } = true;
        public HungryLevel level = HungryLevel.Hungry;

        // Флаг, указывающий на то, предназначена ли птица для яиц (true) или для мяса (false)
        public bool IsForEggs { get; set; }

        // Количество мяса, которое можно получить от данной птицы, если она не предназначена для яиц
        public int MeatAmount { get; protected set; }

        // Метод для обновления уровня голода птицы
        public void UpdateHunger()
        {
            if (!IsAlive) return;

            // Изменяем уровень голода птицы в зависимости от текущего состояния
            if (level == HungryLevel.Hungry)
            {
                level = HungryLevel.Full; // Голодная птица становится сытой
            }
            else if (level == HungryLevel.Full)
            {
                level = HungryLevel.Overfed; // Сытая птица становится перекормленной
            }
        }

        // Метод для получения мяса
        public int GetMeat()
        {
            return !IsForEggs && !IsAlive ? MeatAmount : 0;
        }
    }
}
