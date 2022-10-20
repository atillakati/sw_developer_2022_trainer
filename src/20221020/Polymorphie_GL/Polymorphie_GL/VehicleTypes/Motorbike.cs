using System;

namespace Polymorphie_GL.VehicleTypes
{
	public class Motorbike : Vehicle
	{
		private int _seatCount;

		public Motorbike(string brand, int maxSpeed, ConsoleColor color)
			: base(brand, VehicleType.Chopper, maxSpeed, color)
		{
			_seatCount = 1;
		}

		public int SeatCount
		{
			get { return _seatCount; }
		}

		public override string DisplayStats()
		{
			var text = $"Seat count: {_seatCount}\n";
			text += base.DisplayStats();

			return text;
		}

		public override void Drive()
		{
			throw new NotImplementedException();
		}
	}
}