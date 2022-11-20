namespace Autopark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Autopark First = new Autopark("First", new List<Car>());
            First.AddCar(new PassengerCar("Regout", 1000, 1995, 2, new Dictionary<string, int>()));
            First.AddCar(new Truck("Volvo", 1500, 1990, 15000, "Michael", new Dictionary<string, int>()));
            First.AddCar(new PassengerCar("Mercedes", 1300, 2003, 5, new Dictionary<string, int>()));
            First.AddCar(new Truck("MAN", 2100, 2006, 20000, "John", new Dictionary<string, int>()));
            First.AddCar(new Car("Renault", 900, 2000));
            Console.WriteLine(First.ToString());
        }
    }
    class Car
    {
        protected string _mark;
        protected int _power, _year;
        public Car(string mark, int power, int year)
        {
            _mark = mark;
            _power = power;
            _year = year;
        }
        public string Mark { get { return _mark; } }
        public int Power
        {
            get { return _power; }
            set
            {
                if (value >= 0)
                    _power = value;
                else
                {
                    Console.WriteLine("Power must be positive");
                }
            }
        }
        public int Year { get { return _year; } }
        public override string ToString()
        {
            return $"Car mark - {Mark}, power = {Power}, made in {Year}"; 
        }
    }

    class PassengerCar : Car
    {
        //private const Dictionary<string, int> _constDict = new Dictionary<string, int>();
        private int _seats;
        private Dictionary<string, int> _repaired;
        public PassengerCar(string mark, int power, int year, int seats, 
            Dictionary<string, int> repaired)
            : base(mark, power, year)
        {
            _seats = seats;
            _repaired = repaired;
        }
        public int Seats { get { return _seats; } }
        public Dictionary<string, int> Repaired { get { return _repaired; } }
        public void DetailsAppend(string detail, int year)
        {
            _repaired[detail] = year;
        }
        public int GetYear(string detail)
        {
            return _repaired[detail];
        }
        public void RepairedPrint()
        {
            foreach(KeyValuePair<string, int> pair in _repaired)
            {
                Console.WriteLine($"{pair.Key} {pair.Value}");
            }
            return;
        }
        public override string ToString()
        {
            return $"Car mark - {Mark}, power = {Power}, made in {Year}, count of seats {Seats}";
        }
    }

    class Truck : Car
    {
        private int _capacity;
        private string _name;
        private Dictionary<string, int> _cargoList;
        public Truck(string mark, int power, int year, int capacity, string name,
            Dictionary<string, int> cargo)
            : base(mark, power, year)
        {
            _capacity = capacity;
            _name = name;
            _cargoList = cargo;
        }
        public string Name { set; get; }
        public int Capacity { get { return _capacity; } }
        public Dictionary<string, int> CargoList { get { return _cargoList; } }
        public void AddCargo(string cargo, int weight)
        {
            if (_cargoList.ContainsKey(cargo))
            {
                _cargoList[cargo] += weight;
            }
            else
            {
                _cargoList[cargo] = weight;
            }
            return;
        }
        public void DellCargo(string cargo, int weight)
        {
            if (_cargoList.ContainsKey(cargo))
            {
                if (_cargoList[cargo] >= weight)
                {
                    _cargoList[cargo] -= weight;
                }
                else
                {
                    Console.WriteLine($"Contains insufficient amount of {cargo}");
                }
            }
            else
            {
                Console.WriteLine($"Does not contain {cargo}");
            }
        }
        public void CargoListPrint()
        {
            foreach (KeyValuePair<string, int> pair in _cargoList)
            {
                Console.WriteLine($"{pair.Key} {pair.Value}");
            }
            return;
        }
        public override string ToString()
        {
            return $"Car mark - {Mark}, power = {Power}, made in {Year}," +
                $"maximal capacity {_capacity}, name of driver {_name}";
        }
    }

    class Autopark
    {
        private string _title;
        private List<Car> _carsList;
        public Autopark(string title, List<Car> carsList)
        {
            _title = title;
            _carsList = carsList;
        }
        public string Title { set; get; }
        public List<Car> CarsList { get { return _carsList; } }
        public void AddCar(Car car)
        {
            _carsList.Add(car);
        }
        public void RemoveCar(Car car)
        {
            if (_carsList.Contains(car))
            {
                _carsList.Remove(car);
            }
            else
            {
                Console.WriteLine($"{car} does not exist in list");
            }
        }
        public override string ToString()
        {
            string _autoparkInfo = "";
            foreach(Car car in _carsList)
            {
                if (car is PassengerCar passengerCar)
                {
                     _autoparkInfo += passengerCar.ToString() + '\n';
                }
                else if(car is Truck truck)
                {
                    _autoparkInfo += truck.ToString() + '\n';
                }
                else
                {
                    _autoparkInfo += car.ToString() +'\n';
                }
            }
            return _autoparkInfo;
        }
    }
}