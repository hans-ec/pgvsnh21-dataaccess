namespace _01_DataAccess_SqlClient.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}



/*  
    C#              SQL
    -----------------------------------------------------
    int             tinyint, smallint, int
    long            bigint
    Guid            uniqueidentifier
    bool            bit    
    float           float, real
    decimal         decimal, money, (float)
    double          decimal, (float)
    DateTime        datetime, datetime2, date, time, smalldatetime
    string          char, nchar, varchar, nvarchar, text, ntext
    byte[]          varbinary 
*/
