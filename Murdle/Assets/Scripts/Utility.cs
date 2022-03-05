using System.Collections.Generic;
using System.IO;
using static System.Convert;

public class Utility
{
    
    /**
     * Extracts Weapon Information from a Specified .csv File
     *
     * Returns List of Tuples of Form: (img_filename, effectiveness, mass, activeness, sharpness)
     */
    public static List<Weapon> getWeaponsFromCSV(string filename)
    {
        List<Weapon> weaponList = new List<Weapon>();
        
        using(var reader = new StreamReader(filename))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                
                // Create New Weapon Object from CSV Properties
                Weapon weapon = new Weapon(values[0],
                    ToDouble(values[1]),
                    ToDouble(values[2]),
                    ToDouble(values[3]),
                    ToDouble(values[4])
                );

                weaponList.Add(weapon);
            }
        }

        return weaponList;
    }
    
    /**
     * Extracts Suspect Information from a Specified .csv File
     *
     * Returns List of Tuples of Form: (...)
     */
    public static List<Suspect> getSuspectsFromCSV(string filename)
    {
        List<Suspect> suspectList = new List<Suspect>();
        
        using(var reader = new StreamReader(filename))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                
                // Create New Weapon Object from CSV Properties
                Suspect suspect = new Suspect();

                suspectList.Add(suspect);
            }
        }

        return suspectList;
    }
    
    
    /**
     * Extracts Motivation Information from a Specified .csv File
     *
     * Returns List of Tuples of Form: (...)
     */
    public static List<Motivation> getMotivationsFromCSV(string filename)
    {
        List<Motivation> motivationList = new List<Motivation>();
        
        using(var reader = new StreamReader(filename))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                
                // Create New Motivation Object from CSV Properties
                Motivation motivation = new Motivation();

                motivationList.Add(motivation);
            }
        }

        return motivationList;
    }

    //public List<T> getSubsetOf(List<T> objectList, int maxSize)
    //{
    //    return objectList;
    //}
    
    
}