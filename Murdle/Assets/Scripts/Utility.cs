using System.Collections.Generic;
using System.IO;

namespace DefaultNamespace;

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

                weaponList.add(weapon);
            }
        }

        return weaponList;
    }

    public List<Object[]> getSuspectPropertiesFromCSV(string filename)
    {
        return null;
    }
    
}