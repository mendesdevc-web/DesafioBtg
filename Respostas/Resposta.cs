namespace DesafioBTG.Respostas
{
    public record FundoDetalhesDto(
        int Id,
        string Nome,
        List<AplicacaoDto> Aplicacaos,
        List<ResgateDto> Resgates
    );

    public record AplicacaoDto(int Id, decimal Valor, DateTime DataAplicacao);

    public record ResgateDto(int Id, decimal Valor, DateTime DataResgate, decimal ImpostoDeRenda, decimal ValorLiquido);
}
