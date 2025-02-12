namespace lib_miniHW1
{
    public class Zoo : IAnimalManager, IFoodCalculator, IPettingZoo, IInventoryPrinter
    {
        private readonly List<Animal> _animals = new();
        private readonly List<Thing> _things = new();
        private readonly IVeterinaryClinic _veterinaryClinic;

        public Zoo(IVeterinaryClinic veterinaryClinic)
        {
            _veterinaryClinic = veterinaryClinic;
        }

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

        public void AddThing(Thing thing)
        {
            _things.Add(thing);
            Console.WriteLine($"Вещь добавлена в зоопарк: {thing.Name}");
        }

        public double GetTotalFoodConsumption()
        {
            return _animals.Sum(a => a.FoodConsumption);
        }

        public IEnumerable<Animal> GetAnimalsForPettingZoo()
        {
            return _animals.Where(a => a.CanInteractWithVisitors());
        }

        public void PrintInventory()
        {
            Console.WriteLine("Инвентаризация животных:");
            foreach (var animal in _animals)
            {
                Console.WriteLine($"Инвентарный номер: {animal.InventoryNumber}, Вид: {animal.GetType().Name}");
            }

            Console.WriteLine("\nИнвентаризация вещей:");
            foreach (var thing in _things)
            {
                thing.DisplayInfo();
            }
        }
    }
}
