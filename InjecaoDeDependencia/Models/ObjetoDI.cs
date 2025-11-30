namespace InjecaoDeDependencia.Models;

public sealed class Scoped : Base
{
    public override void Contar()
    {
        Contador++;
    }
}
public sealed class Transient : Base
{
    public override void Contar()
    {
        Contador++;

    }
}
public sealed class Singleton : Base
{
    public override void Contar()
    {
        Contador++;
    }
}

public abstract class Base
{
    public int Contador { get; set; }
    public Guid Id { get; set; }

    protected Base()
    {
        Id = Guid.NewGuid();
    }

    public abstract void Contar();
}