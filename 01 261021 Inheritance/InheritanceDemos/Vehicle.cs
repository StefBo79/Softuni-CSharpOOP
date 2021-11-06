using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemos
{
    // Base class

    // TODO: public, protected, private, internal, protected internal, internal protected
    public class MotorVehicle : Object
    {
        public MotorVehicle()
        {
            maxTransmission = 6;
        }

        public MotorVehicle(int maxTransmission)
        {
            Console.WriteLine(" MotorVehicle(int maxTransmission)");
            this.maxTransmission = maxTransmission;
        }

        public int Transmission { get; set; }
        private int maxTransmission;
        public virtual void Move()
        {
            Console.WriteLine("Base class move...");
            // ...
        }
        public void GearUp()
        {
            Transmission++;
            if (Transmission > maxTransmission)
            {
                Transmission = maxTransmission;
            }
        }
        public void GearDown()
        {
            Transmission--;
            if (Transmission < 0)
            {
                Transmission = 0;
            }
        }
    }

    public class Engine
    { }


    public class Car : MotorVehicle // Car IS-A MotorVehicle
    {
        public Car()
        {
        }

        // Car HAS-A Engine
        public Engine Engine { get; set; }

        public Car(int maxTransmission)
            : base(maxTransmission)
        {
            
            Console.WriteLine(" Car(int maxTransmission) : base(maxTransmission)");
        }

        public void OpenDoor()
        {
            if (Transmission == 0)
            {
                // TODO: Open
            }
        }

        public override string ToString()
        {
            return "I am car...";
        }

        public override sealed void Move()
        {
            Console.WriteLine("Move all 4 tires...");
        }
    }

    class Motobike : MotorVehicle
    {
    }

    class Truck : MotorVehicle
    {
        private int capacity = 6;
        private Stack<string> items;

        void Load(string item)
        {
            if (capacity > items.Count)
            {
                items.Push(item);
            }
        }

        string Unload()
        {
            return items.Pop();
        }

        public override void Move()
        {
            Console.WriteLine("Move 16 tires...");
        }
    }
}
