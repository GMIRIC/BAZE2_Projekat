using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DataAccess
    {
        private static DataAccess instance = null;
        public ModelContainer db;

        private DataAccess()
        {
            db = new ModelContainer();
        }

        public static DataAccess Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataAccess();
                }
                return instance;
            }
        }

        //CITY
        public void AddCity(City c)
        {
            db.CitySet.Add(c);
            db.SaveChanges();
        }
        public void RemoveCity(int id)
        {
            db.CitySet.Remove(db.CitySet.FirstOrDefault(x => x.CityId == id));
            db.SaveChanges();
        }
        public List<City> GetCities()
        {
            return db.CitySet.ToList();
        }
        public void EditCity(int id, City c)
        {
            db.CitySet.FirstOrDefault(x => x.CityId == id).Name = c.Name;
            db.CitySet.FirstOrDefault(x => x.CityId == id).Region = c.Region;
            db.CitySet.FirstOrDefault(x => x.CityId == id).Zipcode = c.Zipcode;
            db.SaveChanges();
        }

        //WINNARY
        public void AddWinnary(Winnary w, City c)
        {
            w.CityId = c.CityId;
            db.WinnarySet.Add(w);
            db.SaveChanges();
        }
        public void RemoveWinnary(int id)
        {
            db.WinnarySet.Remove(db.WinnarySet.FirstOrDefault(x => x.Id == id));
            db.SaveChanges();
        }
        public List<Winnary> GetWinnaries()
        {
            return db.WinnarySet.ToList();
        }
        public void EditWinnary(int id, Winnary w, City c)
        {
            w.CityId = c.CityId;
            db.WinnarySet.FirstOrDefault(x => x.Id == id).Name = w.Name;
            db.WinnarySet.FirstOrDefault(x => x.Id == id).Address = w.Address;
            db.WinnarySet.FirstOrDefault(x => x.Id == id).CityId = w.CityId;
            db.SaveChanges();
        }

        //EMPLOYEES
        public void AddPacker(Packer p, Winnary w)
        {
            p.WinnaryId = w.Id;
            db.EmployeesSet1.Add(p);
            db.SaveChanges();
        }
        public void AddSeller(Seller s, Winnary w)
        {
            s.WinnaryId = w.Id;
            db.EmployeesSet1.Add(s);
            db.SaveChanges();
        }
        public void RemoveEmployee(int id)
        {
            db.EmployeesSet1.Remove(db.EmployeesSet1.FirstOrDefault(x => x.EmployeesId == id));
            db.SaveChanges();
        }

        public List<Employees> GetEmployees()
        {
            return db.EmployeesSet1.ToList();
        }

        public List<Employees> GetPackers()
        {
            List<Employees> temp = new List<Employees>();

            foreach(var x in db.EmployeesSet1)
            {
                if(x is Packer)
                {
                    temp.Add(x);
                }
            }

            return temp;
        }
        public List<Employees> GetSellers()
        {
            List<Employees> temp = new List<Employees>();

            foreach (var x in db.EmployeesSet1)
            {
                if (x is Seller)
                {
                    temp.Add(x);
                }
            }

            return temp;
        }

        public void EditPacker(int id, Packer p, Winnary w)
        {
            p.WinnaryId = w.Id;
            db.EmployeesSet1.FirstOrDefault(x => x.EmployeesId == id).FirstName = p.FirstName;
            db.EmployeesSet1.FirstOrDefault(x => x.EmployeesId == id).LastName = p.LastName;
            db.EmployeesSet1.FirstOrDefault(x => x.EmployeesId == id).Salary = p.Salary;
            db.EmployeesSet1.FirstOrDefault(x => x.EmployeesId == id).WinnaryId = p.WinnaryId;
            db.SaveChanges();
        }
        public void EditSeller(int id, Seller s, Winnary w)
        {
            s.WinnaryId = w.Id;
            db.EmployeesSet1.FirstOrDefault(x => x.EmployeesId == id).FirstName = s.FirstName;
            db.EmployeesSet1.FirstOrDefault(x => x.EmployeesId == id).LastName = s.LastName;
            db.EmployeesSet1.FirstOrDefault(x => x.EmployeesId == id).Salary = s.Salary;
            db.EmployeesSet1.FirstOrDefault(x => x.EmployeesId == id).WinnaryId = s.WinnaryId;
            db.SaveChanges();
        }


        //WINE
        public void AddRed(RedVine rv, Winnary w)
        {
            rv.WinnaryId = w.Id;
            db.VineSet.Add(rv);
            db.SaveChanges();
        }
        public void AddWhite(WhiteVine wv, Winnary w)
        {
            wv.WinnaryId = w.Id;
            db.VineSet.Add(wv);
            db.SaveChanges();
        }
        public void RemoveWine(int id)
        {
            db.VineSet.Remove(db.VineSet.FirstOrDefault(x => x.VineId == id));
            db.SaveChanges();
        }

        public List<Vine> GetWine()
        {
            return db.VineSet.ToList();
        }

        public List<Vine> GetRed()
        {
            List<Vine> temp = new List<Vine>();

            foreach (var x in db.VineSet)
            {
                if (x is RedVine)
                {
                    temp.Add(x);
                }
            }

            return temp;
        }
        public List<Vine> GetWhite()
        {
            List<Vine> temp = new List<Vine>();

            foreach (var x in db.VineSet)
            {
                if (x is WhiteVine)
                {
                    temp.Add(x);
                }
            }

            return temp;
        }

        public void EditRed(int id, RedVine rv, Winnary w)
        {
            rv.WinnaryId = w.Id;
            db.VineSet.FirstOrDefault(x => x.VineId == id).Name = rv.Name;
            db.VineSet.FirstOrDefault(x => x.VineId == id).ProductionDate = rv.ProductionDate;
            db.VineSet.FirstOrDefault(x => x.VineId == id).WinnaryId = rv.WinnaryId;
            db.SaveChanges();
        }
        public void EditWhite(int id, WhiteVine wv, Winnary w)
        {
            wv.WinnaryId = w.Id;
            db.VineSet.FirstOrDefault(x => x.VineId == id).Name = wv.Name;
            db.VineSet.FirstOrDefault(x => x.VineId == id).ProductionDate = wv.ProductionDate;
            db.VineSet.FirstOrDefault(x => x.VineId == id).WinnaryId = wv.WinnaryId;
            db.SaveChanges();
        }


        //STOREHOUSE
        public void AddStorehouse(Storehouse s)
        {
            db.StorehouseSet.Add(s);
            db.SaveChanges();
        }
        public void RemoveStorehouse(int id)
        {
            db.StorehouseSet.Remove(db.StorehouseSet.FirstOrDefault(x => x.StorehouseId == id));
            db.SaveChanges();
        }
        public List<Storehouse> GetStorehouse()
        {
            return db.StorehouseSet.ToList();
        }
        public void EditStorehouse(int id, Storehouse s)
        {
            db.StorehouseSet.FirstOrDefault(x => x.StorehouseId == id).Capacity = s.Capacity;
            
            db.SaveChanges();
        }

        //TASTER
        public void AddTaster(Taster t)
        {
            db.TasterSet.Add(t);
            db.SaveChanges();
        }
        public void RemoveTaster(int id)
        {
            db.TasterSet.Remove(db.TasterSet.FirstOrDefault(x => x.TasterId == id));
            db.SaveChanges();
        }
        public List<Taster> GetTaster()
        {
            return db.TasterSet.ToList();
        }
        public void EditTaster(int id, Taster t)
        {
            db.TasterSet.FirstOrDefault(x => x.TasterId == id).FirstName = t.FirstName;
            db.TasterSet.FirstOrDefault(x => x.TasterId == id).LastName = t.LastName;

            db.SaveChanges();
        }

        //TASTING
        public void AddTasting(Taster t, WhiteVine v)
        {
            Tasting ta = new Tasting() { TasterTasterId = t.TasterId, WhiteVineVineId = v.VineId };

            db.TastingSet.Add(ta);
            db.SaveChanges();
        }
        public void RemoveTasting(int id)
        {
            db.TastingSet.Remove(db.TastingSet.FirstOrDefault(x => x.TastingId == id));
            db.SaveChanges();
        }

        public List<Tasting> GetTasting()
        {
            return db.TastingSet.ToList();
        }
        public List<WhiteVine> GetWhiteWine()
        {
            List<WhiteVine> temp = new List<WhiteVine>();

            foreach (var x in db.VineSet)
            {
                if (x is WhiteVine)
                {
                    temp.Add((WhiteVine)x);
                }
            }

            return temp;
        }

        public void EditTasting(int id, Taster t, WhiteVine v)
        {
            db.TastingSet.FirstOrDefault(x => x.TastingId == id).TasterTasterId = t.TasterId;
            db.TastingSet.FirstOrDefault(x => x.TastingId == id).WhiteVineVineId = v.VineId;

            db.SaveChanges();
        }

        //CHAMPAGNE
        public void AddChampagne(Champagne c)
        {
            db.ChampagneSet.Add(c);
            db.SaveChanges();
        }
        public void RemoveChampagne(int id)
        {
            db.ChampagneSet.Remove(db.ChampagneSet.FirstOrDefault(x => x.ChampagneId == id));
            db.SaveChanges();
        }

        public List<Champagne> GetChampagne()
        {
            return db.ChampagneSet.ToList();
        }
        
        public void EditChampagne(int id, Champagne c)
        {
            db.ChampagneSet.FirstOrDefault(x => x.ChampagneId == id).Name = c.Name;
            db.ChampagneSet.FirstOrDefault(x => x.ChampagneId == id).ProductionDate = c.ProductionDate;

            db.SaveChanges();
        }


        //TASTING_CHAMPAGNE
        public void AddTastingChampagne(Champagne c, Tasting t)
        {
            TastingChampagne tc = new TastingChampagne() { ChampagneChampagneId = c.ChampagneId, TastingTastingId = t.TastingId };

            db.TastingChampagneSet.Add(tc);
            db.SaveChanges();
        }
        public void RemoveTastingChampagne(int id)
        {
            db.TastingChampagneSet.Remove(db.TastingChampagneSet.FirstOrDefault(x => x.TastingChampagneId == id));
            db.SaveChanges();
        }

        public List<TastingChampagne> GetTastingChampagne()
        {
            return db.TastingChampagneSet.ToList();
        }
        

        public void EditTastingChampagne(int id, Champagne c, Tasting t)
        {
            db.TastingChampagneSet.FirstOrDefault(x => x.TastingChampagneId == id).ChampagneChampagneId = c.ChampagneId;
            db.TastingChampagneSet.FirstOrDefault(x => x.TastingChampagneId == id).TastingTastingId = t.TastingId;

            db.SaveChanges();
        }

        //TRANSPORT
        public void AddTransport(Storehouse s, RedVine v)
        {
            Transport tr = new Transport() { StorehouseStorehouseId = s.StorehouseId, RedVineVineId = v.VineId, Name = "Transport(" + s.StorehouseId.ToString() + "," + v.Name + ")" };

            db.TransportSet.Add(tr);
            db.SaveChanges();
        }
        public void RemoveTransport(int id)
        {
            db.TransportSet.Remove(db.TransportSet.FirstOrDefault(x => x.TransportId == id));
            db.SaveChanges();
        }

        public List<Transport> GetTransport()
        {
            return db.TransportSet.ToList();
        }
        public List<RedVine> GetRedWine()
        {
            List<RedVine> temp = new List<RedVine>();

            foreach (var x in db.VineSet)
            {
                if (x is RedVine)
                {
                    temp.Add((RedVine)x);
                }
            }

            return temp;
        }

        public void EditTransport(int id, Storehouse s, RedVine v)
        {
            db.TransportSet.FirstOrDefault(x => x.TransportId == id).StorehouseStorehouseId = s.StorehouseId;
            db.TransportSet.FirstOrDefault(x => x.TransportId == id).RedVineVineId = v.VineId;

            db.SaveChanges();
        }


        //PACKAGE
        public void AddPackage(Transport t, Packer p)
        {
            Package pa = new Package() { TransportTransportId = t.TransportId, PackerEmployeesId = p.EmployeesId, Name = "Package(" + t.Name + ", " + p.FirstName + ")" };

            db.PackageSet.Add(pa);
            db.SaveChanges();
        }
        public void RemovePackage(int id)
        {
            db.PackageSet.Remove(db.PackageSet.FirstOrDefault(x => x.PackageId == id));
            db.SaveChanges();
        }

        public List<Package> GetPackage()
        {
            return db.PackageSet.ToList();
        }
        public List<Packer> GetPacker()
        {
            List<Packer> temp = new List<Packer>();

            foreach (var x in db.EmployeesSet1)
            {
                if (x is Packer)
                {
                    temp.Add((Packer)x);
                }
            }

            return temp;
        }

        public void EditPackage(int id, Transport t, Packer p)
        {
            db.PackageSet.FirstOrDefault(x => x.PackageId == id).TransportTransportId = t.TransportId;
            db.PackageSet.FirstOrDefault(x => x.PackageId == id).PackerEmployeesId = p.EmployeesId;

            db.SaveChanges();
        }


    }
}
