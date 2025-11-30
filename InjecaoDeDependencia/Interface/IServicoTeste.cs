namespace InjecaoDeDependencia.Interface;

public interface IServicoTeste
{
    (int scopedCont, int transientCont) Executar();

}