using DesafioBTG.Requisicao;
using DesafioBTG.Respostas;

namespace DesafioBTG.Servicos
{
    public interface IAliquotaServico
    {
        Task<AplicacaoDto> Aplicar(Requisicoes requisicoes);
        Task<ResgateDto> Resgatar(Requisicoes requisicoes);
        Task<List<FundoDetalhesDto>> Listar();
    }
}
