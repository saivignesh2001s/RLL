using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CarDAL
    {
        CarRentalEntities context = null;
        public CarDAL()
        {
             context = new CarRentalEntities();
        }
        public List<Car> getcar()
        {
            List<Car> cars = context.Cars.ToList();
            return cars;
        }
        public bool addcar(Car c)
        {
            try
            {
                context.Cars.Add(c);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Car find(int id)
        {
            List<Car> cars = context.Cars.ToList();
            Car c = cars.Find(x => x.Carid == id);
            return c;
        }
        public bool delete(int id)
        {
            try
            {
                List<Car> cars = context.Cars.ToList();
                Car c = cars.Find(x => x.Carid == id);
                context.Cars.Remove(c);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void update(int id, Car c)
        {
            Car k = context.Cars.Find(id);
            k.Carid = c.Carid;
            k.Carname = c.Carname;
            k.PerDayCharge = c.PerDayCharge;
            k.ChargePerKm = c.ChargePerKm;
            k.Photo = c.Photo;
            k.CarType = c.CarType;
            k.Available = c.Available;
            context.SaveChanges();
        }
        public void locked(int id)
        {
            Car k = context.Cars.Find(id);
            k.Available = "No";
            context.SaveChanges();
        }
        public void unlocked(int id)
        {
            Car k = context.Cars.Find(id);
            k.Available = "Yes";
            context.SaveChanges();
        }
    }
}
