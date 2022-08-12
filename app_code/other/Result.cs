using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

/// <summary>
/// Summary description for Results
/// </summary>
public class Results
{
	public Results()
	{
	}
    public static IEnumerable<Dictionary<string, object>> Serialize(SqlDataReader reader)
    {
        var results = new List<Dictionary<string, object>>();
        var cols = new List<string>();
        for (var i = 0; i < reader.FieldCount; i++)
            cols.Add(reader.GetName(i));
        try
        {

            while (reader.Read())
                results.Add(SerializeRow(cols, reader));
        }
        catch (Exception eee)
        {
        }
        return results;
    }
    private static Dictionary<string, object> SerializeRow(IEnumerable<string> cols,
                                                    SqlDataReader reader)
    {
        var result = new Dictionary<string, object>();
        foreach (var col in cols)
        {
            try
            {
                result.Add(col, reader[col]);
            }
            catch (Exception eee)
            {

            }
        }
        return result;
    }
    public static List<T> DataReaderMapToList<T>(IDataReader dr)
    {
        List<T> list = new List<T>();
        T obj = default(T);

        DataTable dt= dr.GetSchemaTable();

        obj = Activator.CreateInstance<T>();
        string[] fields = new string[dr.FieldCount];
        for (int i = 0; i < dr.FieldCount; i++)
        {
            foreach (PropertyInfo prop in obj.GetType().GetProperties())
            {
                if (dr.GetName(i).Equals(prop.Name, StringComparison.InvariantCultureIgnoreCase))
                {
                    fields[i] = prop.Name;
                }
            }
        }

                while (dr.Read())
        {


            obj = Activator.CreateInstance<T>();
            foreach (PropertyInfo prop in obj.GetType().GetProperties())
            {
                
                if (fields.FirstOrDefault(x=>x==prop.Name)==prop.Name&& !object.Equals(dr[prop.Name], DBNull.Value))
                        {
                            prop.SetValue(obj, dr[prop.Name], null);
                        }

                    }
            list.Add(obj);
        }

            
            
        
        return list;
    }
}

