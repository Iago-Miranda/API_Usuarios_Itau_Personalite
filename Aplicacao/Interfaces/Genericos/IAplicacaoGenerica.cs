using System.Threading.Tasks;

namespace Aplicacao.Interfaces.Genericos
{
    public interface IAplicacaoGenerica <in T> where T :  class
    {
        public Task Adicionar(T Objeto);
    }
}
