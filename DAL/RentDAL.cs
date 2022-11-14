using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RentDAL
    {
        CarRentalEntities context = null;
        
        public RentDAL()
        {
            context = new CarRentalEntities();

        }
            public bool rent(CarRent r)
            {
            try
            {
                context.CarRents.Add(r);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            }
        
            public void Return(int id, CarRent rent)
            {
                List<CarRent> rents = context.CarRents.ToList();
                CarRent r = rents.Find(x => x.RentId == id);
                context.CarRents.Remove(r);
                context.SaveChanges();
            context.CarRents.Add(rent);
                context.SaveChanges();

            }
        public void Cancel(int id)
        {
            List<CarRent> rents = context.CarRents.ToList();
            CarRent r = rents.Find(x => x.RentId == id);
            context.CarRents.Remove(r);
            context.SaveChanges();
        }
            public CarRent find(int id)
            {
                List<CarRent> rents = context.CarRents.ToList();
                CarRent r = rents.Find(x => x.RentId == id);
                return r;
            }
           public  List<CarRent> rentlist()
        {
            return context.CarRents.ToList();
        }
        
            public Tuple<int, double> charges(CarRent r)
            {
                double charge = 0;
                CarDAL cdal = new CarDAL();
                DateTime d = Convert.ToDateTime(r.ReturnDate); 
                DateTime d1 = Convert.ToDateTime(r.RentOrderDate);
                TimeSpan s = d - d1;
                int day = s.Days;
                Car c = cdal.find(Convert.ToInt32(r.CarId));
                int charge1 = 0;
                if (day > 0)
                {
                    charge1 = Convert.ToInt32(c.PerDayCharge) * day;
                }
                var kms = r.ReturnOdoReading - r.OdoReading;
                int km = Convert.ToInt32(kms);
                charge = Convert.ToInt32(c.ChargePerKm) * km;
                string typ = c.CarType;
                int type = 0;
                switch (typ)
                {
                    case "Luxury":
                        type = 5;
                        break;

                    case "SUV":
                        type = 4;
                        break;
                    case "Suden":
                        type = 3;
                        break;
                    case "Compact":
                        type = 2;
                        break;
                }
                charge = charge * type;
                charge = charge + charge1;
               
                Tuple<int, double> k1 = Tuple.Create(km,charge);
                return k1;
            }
        }
    }

    

