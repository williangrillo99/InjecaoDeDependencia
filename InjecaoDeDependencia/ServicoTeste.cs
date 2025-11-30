using InjecaoDeDependencia.Interface;
using InjecaoDeDependencia.Models;

namespace InjecaoDeDependencia;

public class ServicoTeste(Scoped scoped, Transient transient) : IServicoTeste
{
    public (int scopedCont, int transientCont) Executar()
    {
        scoped.Contador++;
        transient.Contador++;

        return (scoped.Contador,  transient.Contador);
    }
}