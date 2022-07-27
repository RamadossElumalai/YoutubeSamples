using System;
public class GenericTypes
{
    static void Main(string[] args)
    {
        Console.WriteLine(FindType<string>("Test"));
        Console.WriteLine(GetResponse<DellLaptop>(new DellLaptop()));
    }

    private static string FindType<T>(T inputType)
    {
       if(inputType is int)
        {
            return $"Integer Type";
        }

        return $"Not found Type";
    }

    private static string GetResponse<TResponseType>(TResponseType inputValue) where TResponseType : BaseLaptop
    {
        return typeof(TResponseType).ToString();
    }
}

public abstract class BaseLaptop
{
    public Guid ModelNumber { get; set; }
    public string ManufacturedDate { get; set; }
    public string ManufacturedBy { get; set; }
   
    //It's not mantory to have abstract method in the abstract class, it can have or not also it will compile
    public abstract string Configuration { get; set; }
}

public class DellLaptop : BaseLaptop
{
    public override string Configuration { get; set; }
}
public class HpLaptop : BaseLaptop
{
    public override string Configuration { get; set; }
}
