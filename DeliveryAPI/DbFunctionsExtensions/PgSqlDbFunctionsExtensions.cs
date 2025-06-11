using Microsoft.EntityFrameworkCore;

namespace DeliveryAPI.DbFunctionsExtensions
{
    public static class PgSqlDbFunctionsExtensions
    {
        [DbFunction("to_char", IsBuiltIn = true)]
        public static string ToChar(DateTime date, string format)
            => throw new NotSupportedException(); // только для SQL-перевода
    }
}
