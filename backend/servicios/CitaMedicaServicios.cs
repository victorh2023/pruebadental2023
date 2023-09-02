using System.Data;
using backend.connection;
using backend.entidades;
using Dapper;

namespace backend.servicios
{
    public static class CitaMedicaServicios
    {
        public static IEnumerable<T> ObtenerTodo<T>()
        {
            const string sql = "select top 5 * from cita_medica where estado_registro = 1 order by id desc";
            return BDManager.GetInstance.GetData<T>(sql);//Dapper
        }

        public static T ObtenerById<T>(int id)
        {
            const string sql = "select * from cita_medica where ID = @Id and estado_registro = 1";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int64);

            var result = BDManager.GetInstance.GetDataWithParameters<T>(sql, parameters);

            return result.FirstOrDefault();
        }



        public static int InsertCitaMedica(CitaMedica citaMedica)
        {
            const string sql = "INSERT INTO [dbo].[CITA_MEDICA]([NOMBRE]) VALUES (@nombre) ";

            var parameters = new DynamicParameters();
            parameters.Add("nombre", citaMedica.Nombre, DbType.String);

            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }

        public static int UpdateCitaMedica(CitaMedica citaMedica)
        {
            const string sql = "UPDATE [CITA_MEDICA] SET [NOMBRE] = @nombre where [ID] = @id ";
            var parameters = new DynamicParameters();
            
            parameters.Add("nombre", citaMedica.Nombre, DbType.String);
            parameters.Add("id", citaMedica.Id, DbType.Int64);
            
            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }  

        public static int DeleteCitaMedica(int id)
        {
            const string sql = "DELETE FROM CITA_MEDICA where ID = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int64);
            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        } 
    }
}