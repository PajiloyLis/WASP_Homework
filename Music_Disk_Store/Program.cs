using System;

namespace music_disc_store
{
    interface IStoreItem
    {
        public double Price { get; set; }
        public void DiscountPrice(int percent);
    }
    class Disk : IStoreItem
    {
        protected string _name;
        protected string _genre;
        protected int _burnCount;
        public int BurnCount { get { return _burnCount; } }
        public string Name { get { return _name; } }
        public Disk(string name, string genre)
        {
            _name = name;
            _genre = genre;
            _burnCount = 1;
        }

        public double Price { get; set; }
        public virtual int DiskSize { get; set; }

        public void DiscountPrice(int percent)
        {
            Price *= percent;
        }

        public virtual void Burn(params string[] values){ }
        public override bool Equals(object? obj)
        {
            if (obj is Disk disk)
            {
                return _name == disk._name && _genre == disk._genre;
            }
            else
            {
                return false;
            }
        }
    }

    class Audio : Disk
    {
        private string _artist;
        private string _recordStudio;
        private int _songsNumder;
        public Audio(string name, string genre, string artist, 
            string recordStudio, int songsNumder) : base(name, genre)
        {
            _artist = artist;
            _recordStudio = recordStudio;
            _songsNumder= songsNumder;
        }
        public override int DiskSize
        {
            get
            {
                return _songsNumder * 8;
            }
        }
        public override void Burn(params string[] values){
            _name = values[0];
            _genre = values[1];
            _artist = values[2];
            _recordStudio = values[3];
            _songsNumder = Convert.ToInt32(values[4]);
            _burnCount += 1;
        }
        public override string ToString()
        {
            return $"Название альбома {_name}, жанр {_genre} исполнитель {_artist}, " +
                $"студия {_recordStudio}, " +
                $"количество песен {_songsNumder}, количество прожигов {_burnCount}";
        }
        public override bool Equals(object? obj) 
        {
            if (obj is Audio audio)
            {
                return base.Equals(obj) && _artist == audio._artist && 
                    _recordStudio == audio._recordStudio && _songsNumder == audio._songsNumder;
            }
            else
            {
                return false;
            }
        }
    }

    class DVD : Disk
    {
        private string _producer;
        private string _filmCompany;
        private int _minutesCount;
        public DVD(string name, string genre, string producer, 
            string filmCompany, int minutesCount) : base(name, genre)
        {
            _producer = producer;
            _filmCompany = filmCompany;
            _minutesCount = minutesCount;
        }
        public override int DiskSize
        {
            get
            {
                return (_minutesCount / 64) * 2;
            }
        }
        public override void Burn(params string[] values)
        {
            _name = values[0];
            _genre = values[1];
            _producer = values[2];
            _filmCompany = values[3];
            _minutesCount = Convert.ToInt32(values[4]);
            _burnCount += 1;
        }
        public override string ToString()
        {
            return $"Название {_name}, жанр {_genre}, режиссер {_producer}," +
                $" кинокомпания {_filmCompany}, количество минут {_minutesCount}," +
                $" количество прожигов {_burnCount}";
        }
        public override bool Equals(object? obj)
        {
            if (obj is DVD dvd)
            {
                return base.Equals(obj) && _producer == dvd._producer &&
                    _filmCompany == dvd._filmCompany && _minutesCount == dvd._minutesCount;
            }
            else
            {
                return false;
            }
        }
    }
    class Store
    {
        private string _storeName;
        private string _address;
        private List<Audio> _audios;
        private List<DVD> _dvds;
        public List<Audio> Audios
        {
            get
            {
                return _audios;
            }
            set
            {
                _audios = value;
            }
        }
        public List<DVD> DVDs
        {
            get
            {
                return _dvds;
            }
            set
            {
                _dvds = value;
            }
        }
        public Store(string storeName, string address)
        {
            _storeName = storeName;
            _address = address;
            _audios = new List<Audio>();
            _dvds = new List<DVD>();
        }
        public static List<Audio> operator +(Store firstArg, Audio secondArg)
        {
            List<Audio> result = new List<Audio>(firstArg._audios) {secondArg};
            return result;
        }
        public static List<Audio> operator -(Store firstArg, Audio secondArg)
        {
            if (firstArg._audios.Contains(secondArg))
            {
                List<Audio> result = new List<Audio> (firstArg._audios);
                result.Remove(secondArg);
                return result;
            }
            else
            {
                return firstArg._audios;
            }
        }
        public static List<DVD> operator +(Store firstArg, DVD secondArg)
        {
            List<DVD> result = new List<DVD>(firstArg._dvds) { secondArg };
            return result;
        }
        public static List<DVD> operator -(Store firstArg, DVD secondArg)
        {
            if (firstArg._dvds.Contains(secondArg))
            {
                List<DVD> result = new List<DVD>(firstArg._dvds);
                result.Remove(secondArg);
                return result;
            }
            else
            {
                return firstArg._dvds;
            }
        }
        public override string ToString()
        {
            string result= "";
            foreach(Audio audio in _audios)
            {
                result += (audio.ToString() + '\n');
            }
            foreach(DVD dvd in _dvds)
            {
                result += (dvd.ToString() + '\n');
            }
            return result;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store("Music store", "Chehov street");
            store.Audios = store + new Audio("Nevermind", "grange", "Nirvana", "DGC", 13);
            store.Audios = store + new Audio("Mutter", "industrial", "Rammstein", "Motor", 11);
            store.Audios = store + new Audio("Metallica", "heavy-metal", "Metallica", "Elektra", 12);
            store.DVDs = store + new DVD("Rush", "drama", "Hovard", "Working Titles", 123);
            store.DVDs = store + new DVD("StarTrek", "science fiction", "Abrams", "Bad Robot", 127);
            store.DVDs = store + new DVD("Dune", "epic fiction", "Villeneuve", "Legendary", 156);
            Console.WriteLine(store.ToString());
            store.Audios[0].Burn("Black Album", "Russian rock", "Kino", "Moroz", "8");
            foreach(Audio audio in store.Audios)
            {
                Console.WriteLine(audio.Name + " -> " + audio.BurnCount);
            }
            foreach(DVD dvd in store.DVDs)
            {
                Console.WriteLine(dvd.Name + " -> " + dvd.BurnCount);
            }

        }
    }
}