using System;

namespace KapselungBeispiel
{
    public class Vehicle
    {
		private int _speed;
		private int _maxSpeed;
		private string _brand;
		private VehicleType _type;
		private ConsoleColor _color;
		

		public Vehicle(string brand, VehicleType type, int maxSpeed, ConsoleColor color)
		{			
			_maxSpeed = maxSpeed;
			_brand = brand;
			_type = type;
			_color = color;

            _speed = 0;
        }

        public Vehicle(string brand, int maxSpeed)
        {
            _maxSpeed = maxSpeed;
            _brand = brand;

            _type = VehicleType.Sedan;
            _color = ConsoleColor.White;
            _speed = 0;
        }


        public ConsoleColor Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public VehicleType Type
		{
			get { return _type; }			
		}

		public string Brand
		{
			get { return _brand; }			
		}

		public int MaxSpeed
		{
			get { return _maxSpeed; }			
		}

		public int Speed
		{
			get { return _speed; }			
		}


		public void SpeedUp(int delta)
		{
			if(delta + _speed > _maxSpeed || delta + _speed < 0)
			{
				return;
			}

			_speed += delta;
		}

		public string DisplayStats()
		{
			string tmp =  $"{_brand} - Car Body Style: {_type.ToString().ToUpper()} - Color: {_color}\n";
			tmp += $"Current Speed: {_speed} km/h Max: {_maxSpeed} km/h\n";

			return tmp;
		}



	}
}