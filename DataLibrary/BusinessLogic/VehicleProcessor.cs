using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class VehicleProcessor
    {
        public static int CreateVehicle(int vehicleid, string vehicleBrand, string vehicleModel, int vehicleYear, int vehicleOdo,
            string vehicleColor, int vehiclEengine)
        {
            Vehiclemodel data = new Vehiclemodel()
            {
                CarId = vehicleid,
                Make = vehicleBrand,
                Model = vehicleModel,
                Year = vehicleYear,
                Odo = vehicleOdo,
                Color = vehicleColor,
                Engine = vehiclEengine

            };

            string sql = @"INSERT INTO dbo.Vehicle (CarId, Make, Model, Year, Odo, Color, Engine)
                            VALUES (@CarId, @Make, @Model, @Year, @Odo, @Color, @Engine);";
            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<Vehiclemodel> LoadVehicle()
        {
            string sql = @"select Id , CarId , Make , Model, Year, Odo, Color, Engine
                            from dbo.Vehicle where Deleted=0";

            return SqlDataAccess.LoadData<Vehiclemodel>(sql);
        }

        public static List<Vehiclemodel> LoadDeletedVehicle()
        {
            string sql = @"select Id , CarId , Make , Model, Year, Odo, Color, Engine
                            from dbo.Vehicle where Deleted=1";

            return SqlDataAccess.LoadData<Vehiclemodel>(sql);
        }


        public static int DeleteVehicle(int delId)
        {
            Vehiclemodel data = new Vehiclemodel()
            {
                Id = delId
            };
            string sql = @"UPDATE dbo.Vehicle
                           SET Deleted=1
                           WHERE Id = @Id;";
            
            return SqlDataAccess.DeleteData(sql, data);
        }

        public static int RecoverVehicle(int delId)
        {
            Vehiclemodel data = new Vehiclemodel()
            {
                Id = delId
            };
            string sql = @"UPDATE dbo.Vehicle
                           SET Deleted=0
                           WHERE Id = @Id;";

            return SqlDataAccess.DeleteData(sql, data);
        }


        public static List<Vehiclemodel> SelectVehicle(int selId)
        {
            Vehiclemodel data = new Vehiclemodel()
            {
                Id = selId
            };
            string sql = @"select * from dbo.Vehicle WHERE Id=@Id";

            return SqlDataAccess.SelectData<Vehiclemodel>(sql, data);
        }

        public static List<Vehiclemodel> UpdateVehicle(int selid,int vehicleid, string vehicleBrand, string vehicleModel, int vehicleYear, int vehicleOdo,
            string vehicleColor, int vehiclEengine)
        {
            Vehiclemodel data = new Vehiclemodel()
            {
                Id=selid,
                CarId = vehicleid,
                Make=vehicleBrand,
                Model=vehicleModel,
                Year=vehicleYear,
                Odo=vehicleOdo,
                Color=vehicleColor,
                Engine=vehiclEengine
            };
            string sql = @"UPDATE dbo.Vehicle
                           SET CarId = @CarId, Make = @Make, Model = @Model, Year = @Year, Odo = @Odo, Color = @Color, @Engine = Engine
                           WHERE Id = @Id;";

            return SqlDataAccess.SelectData<Vehiclemodel>(sql, data);
        }
    }
}
