using System;

namespace Vererbung_GL
{
    public class Radio
    {
        private string _model;
        private string _stationName;
        private RadioPowerState _powerState;

        public Radio(string model) 
            : this(model, "Default music station")
        {            
        }

        public Radio(string model, string defaultStationName)
        {
            _model = model;
            _stationName = defaultStationName;

            _powerState = RadioPowerState.Off;
        }

        
        public RadioPowerState PowerState
        {
            get { return _powerState; }
        }

        public string StationName
        {
            get { return _stationName; }
            set { _stationName = value; }
        }

        public string Model
        {
            get { return _model; }
        }


        public void MakeNoise()
        {
            if (_powerState == RadioPowerState.On)
            {
                Console.WriteLine($"{_model} empfängt den Sender '{_stationName}'.");
            }
        }

        public void ChangePowerState(RadioPowerState newState)
        {
            if(_powerState != newState)
            {
                _powerState = newState;
            }
        }

    }
}