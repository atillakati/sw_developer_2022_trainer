using System;

namespace Vererbung_GL.VehicleTypes
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

	}
}