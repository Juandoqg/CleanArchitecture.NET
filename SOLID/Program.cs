IRepository<string> equipoData = new LimitedEquipoData(1);
equipoData.Add("Barcelona");
equipoData.Add("Real Madrid");
var equipoGeneratorHTML = new EquiposGeneratorHTML(equipoData);
var equipoGenerator = new EquiposGenerator(equipoData);
var report = new Report();
var data = equipoGenerator.Generate();
report.save(equipoGenerator, "equipos.txt");
report.save(equipoGeneratorHTML, "equipos.html");

public interface IRepository<T>
{
    public void Add(T item);
    public List<T> Get();
}
public interface IReportGenerator { 
    public string Generate();
}
public class EquipoData : IRepository<string>
{
    protected List<string> _equipos;

    public EquipoData()
    {
        _equipos = new List<string>();
    }

    public virtual void Add(string equipo)
    {
        _equipos.Add(equipo);
    }

    public List<string> Get()
        => _equipos;

}


public class EquiposGenerator : IReportGenerator
{
    private IRepository<string> _equipos;
    public EquiposGenerator(IRepository<string> equipoData)
    {
        _equipos = equipoData;
    }

    public string Generate()
    {
        string data = "";
        foreach (var equipo in _equipos.Get())
        {
           data += equipo.ToString();
        }
        return data;
    }
}
//open closed 
public class EquiposGeneratorHTML : IReportGenerator
{
    private IRepository<string> _equipos;
    public EquiposGeneratorHTML(IRepository<string> equipoData)
    {
        _equipos = equipoData;
    }

    public string Generate()
    {
        string data = "<div>";
        foreach (var equipo in _equipos.Get())
        {
            data += "<b>" + equipo + "<b></br>";
        }
        data += "</div>";
        return data;
    }
}

public class Report()
{
    public void save(IReportGenerator reportGenerator, string filepath)
    {
        using (var writer = new StreamWriter(filepath))
        {
            string data = reportGenerator.Generate();
            writer.WriteLine(data); 

        }
    }
}

//clase hija para liskov
// aqui rompe liskov
public class LimitedEquipoData : EquipoData
{
    private int _limit;

    public LimitedEquipoData(int limit)
    { this._limit = limit; }

    public override void Add(string equipo)
    {   if (_equipos.Count >= _limit)
        {
            throw new InvalidOperationException("Limite alcanzado");
        }
        base.Add(equipo);
    }
}

public class LimitedEquipoData2 
{   
    private IRepository<string> _equipos;

    private int _limit;
    private int _count = 0;
    public LimitedEquipoData2(int limit, IRepository<string> equipoData)
    { 
      this._limit = limit; 
      this._equipos = equipoData;
    }

    public void Add(string equipo)
    {
        if (_count >= _limit)
        {
            throw new InvalidOperationException("Limite alcanzado");
        }
        _equipos.Add(equipo);
        _count++;
    }
}