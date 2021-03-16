using System;

namespace CodeWarsBattlefield
{
    public class Car : ICar
    {
        public IFuelTankDisplay fuelTankDisplay;

        private IEngine engine;

        private IFuelTank fuelTank;

        public Car() : this(20)
        {
        }

        public Car(double fuelLevel)
        {
            fuelTank = new FuelTank();
            Refuel(fuelLevel);
            fuelTankDisplay = new FuelTankDisplay(fuelTank);
            engine = new Engine(fuelTank);
        }

        public bool EngineIsRunning => engine.IsRunning;

        public void EngineStart()
        {
            if (fuelTank.FillLevel > 0)
            {
                engine.Start();
            }
        }

        public void EngineStop()
        {
            engine.Stop();
        }

        public void Refuel(double liters)
        {
            fuelTank.Refuel(liters);
        }

        public void RunningIdle()
        {
            if (!EngineIsRunning)
            {
                return;
            }
            
            if (fuelTank.FillLevel >= 0.0003)
            {
                fuelTank.Consume(0.0003);
            }
            else
            {
                EngineStop();
            }
        }
    }

    public class Engine : IEngine
    {
        private IFuelTank FuelTank;

        public Engine(IFuelTank FuelTank)
        {
            this.FuelTank = FuelTank;
        }

        public bool IsRunning { get; private set; }
        public void Consume(double liters)
        {
            FuelTank.Consume(liters);
        }

        public void Start()
        {
            IsRunning = true;
        }

        public void Stop()
        {
            IsRunning = false;
        }
    }

    public class FuelTank : IFuelTank
    {
        public double FillLevel { get; private set; }
        public bool IsOnReserve => FillLevel > 0 && FillLevel < 5;

        public bool IsComplete => FillLevel >= 60;
        public void Consume(double liters)
        {
            FillLevel -= liters;
            if (FillLevel < 0)
            {
                FillLevel = 0;
            }
        }

        public void Refuel(double liters)
        {
            FillLevel += liters > 0 ? liters : 0;
            if (IsComplete)
            {
                FillLevel = 60;
            }
        }
    }

    public class FuelTankDisplay : IFuelTankDisplay
    {
        public FuelTankDisplay(IFuelTank Source)
        {
            FuelTank = Source;
        }
        
        private IFuelTank FuelTank;
        public double FillLevel => Math.Round(FuelTank.FillLevel, 2);

        public bool IsOnReserve => FuelTank.IsOnReserve;
        public bool IsComplete => FillLevel >= 60;
    }
    
    
    //Given base
    
    public interface ICar
    {
        bool EngineIsRunning { get; }

        void EngineStart();

        void EngineStop();

        void Refuel(double liters);

        void RunningIdle();
    }

    public interface IEngine
    {
        bool IsRunning { get; }

        void Consume(double liters);

        void Start();

        void Stop();
    }

    public interface IFuelTank
    {
        double FillLevel { get; }

        bool IsOnReserve { get; }

        bool IsComplete { get; }

        void Consume(double liters);

        void Refuel(double liters);        
    }

    public interface IFuelTankDisplay
    {
        double FillLevel { get; }

        bool IsOnReserve { get; }

        bool IsComplete { get; }
    }
}