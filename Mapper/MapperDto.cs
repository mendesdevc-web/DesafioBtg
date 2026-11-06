using DesafioBTG.Entidades;
using DesafioBTG.Respostas;

namespace DesafioBTG.Mapper
{
    public static class MapperDto
    {
        public static FundoDetalhesDto MapearParaDto(this Fundo fundo)
        {
            return new FundoDetalhesDto(
                fundo.IdFundo,
                fundo.Nome,
                fundo.Aplicacoes.Select(x => new AplicacaoDto(x.Id, x.Valor, x.DataAplicacao)).ToList(),
                fundo.Resgates.Select(x =>
                        new ResgateDto(x.Id, x.ValorResgate, x.DataResgate, x.ImpostoDeRenda, x.ValorLiquido)).ToList()); 
        }
    }
}
