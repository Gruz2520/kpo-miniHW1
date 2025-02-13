namespace lib_miniHW1
{
    /// <summary>
    /// Класс, представляющий зоопарк.
    /// </summary>
    public class Zoo : IAnimalManager, IFoodCalculator, IPettingZoo, IInventoryPrinter
    {
        /// <summary>
        /// Список животных в зоопарке.
        /// </summary>
        private readonly List<Animal> _animals = new();

        /// <summary>
        /// Список вещей в зоопарке.
        /// </summary>
        private readonly List<Thing> _things = new();

        /// <summary>
        /// Ветеринарная клиника для проверки здоровья животных.
        /// </summary>
        private readonly IVeterinaryClinic _veterinaryClinic;

        /// <summary>
        /// Конструктор класса Zoo.
        /// </summary>
        /// <param name="veterinaryClinic">Объект ветеринарной клиники для проверки здоровья животных.</param>
        public Zoo(IVeterinaryClinic veterinaryClinic)
        {
            _veterinaryClinic = veterinaryClinic;
        }

        /// <summary>
        /// Добавляет животное в зоопарк, если оно здоровое.
        /// Если животное нездоровое, выводится сообщение об отказе.
        /// </summary>
        /// <param name="animal">Животное для добавления.</param>
        public void AddAnimal(Animal animal)
        {
            if (_veterinaryClinic.IsHealthy(animal))
            {
                _animals.Add(animal);
                Console.WriteLine($"Животное добавлено в зоопарк: {animal.GetType().Name}");
            }
            else
            {
                Console.WriteLine("Животное отклонено по состоянию здоровья.");
            }
        }

        /// <summary>
        /// Добавляет вещь в зоопарк.
        /// </summary>
        /// <param name="thing">Вещь для добавления.</param>
        public void AddThing(Thing thing)
        {
            _things.Add(thing);
            Console.WriteLine($"Вещь добавлена в зоопарк: {thing.Name}");
        }

        /// <summary>
        /// Вычисляет общее потребление еды всеми животными в зоопарке.
        /// </summary>
        /// <returns>Общее количество потребляемой еды (кг/сутки).</returns>
        public double GetTotalFoodConsumption()
        {
            return _animals.Sum(a => a.FoodConsumption);
        }

        /// <summary>
        /// Возвращает список животных, которые могут взаимодействовать с посетителями.
        /// </summary>
        /// <returns>Коллекция дружелюбных животных.</returns>
        public IEnumerable<Animal> GetAnimalsForPettingZoo()
        {
            return _animals.Where(a => a.CanInteractWithVisitors());
        }

        /// <summary>
        /// Выводит информацию об инвентаризации зоопарка: животные и вещи.
        /// </summary>
        public void PrintInventory()
        {
            Console.WriteLine("Инвентаризация животных:");
            foreach (var animal in _animals)
            {
                Console.WriteLine($"Инвентарный номер: {animal.InventoryNumber}, Вид: {animal.GetType().Name}");
            }

            Console.WriteLine($"{Environment.NewLine}Инвентаризация вещей:");
            foreach (var thing in _things)
            {
                thing.DisplayInfo();
            }
        }
    }
}