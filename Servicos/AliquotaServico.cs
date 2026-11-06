using DesafioBTG.Configuracoes;
using DesafioBTG.Entidades;
using DesafioBTG.Mapper;
using DesafioBTG.Requisicao;
using DesafioBTG.Respostas;
using Microsoft.EntityFrameworkCore;

namespace DesafioBTG.Servicos
{
    public class AliquotaServico : IAliquotaServico
    {
        private readonly ApplicationDbContext _context;
        public AliquotaServico(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AplicacaoDto> Aplicar(Requisicoes requisicoes)
        {
            if (requisicoes.Valor <= 0)
                throw new ArgumentException("O valor da aplicação deve ser maior que zero.");
            
            var cliente = await _context.Clientes.Include(c => c.Aplicacoes)
                                            .FirstOrDefaultAsync(c => c.Id == requisicoes.ClienteId);

            if(cliente is null)
                throw new ArgumentException("Cliente não encontrado.");

            var fundo = await _context.Fundos.FindAsync(requisicoes.NumeroFundo);
            
            if(fundo is null)
                throw new ArgumentException("Fundo não encontrado.");

            await _context.Entry(fundo).Collection(f => f.Aplicacoes).LoadAsync();

            var aplicacao = new Aplicacao(requisicoes.Valor, requisicoes.NumeroFundo, requisicoes.ClienteId);

            fundo.Aplicacoes.Add(aplicacao);
            cliente.Aplicacoes.Add(aplicacao);

            _context.Aplicacoes.Add(aplicacao);
            await _context.SaveChangesAsync();

            return new AplicacaoDto(aplicacao.Id, aplicacao.Valor, aplicacao.DataAplicacao);
        }


        public async Task<ResgateDto> Resgatar(Requisicoes requisicoes)
        {
            if(requisicoes.Valor <= 0)
                throw new ArgumentException("O valor do resgate deve ser maior que zero.");

            var cliente = await _context.Clientes
                       .Include(c => c.Aplicacoes)
                       .Include(c => c.Resgates)
                       .FirstOrDefaultAsync(c => c.Id == requisicoes.ClienteId);

            if (cliente is null)
                throw new ArgumentException("Cliente não encontrado.");

            var fundo = await _context.Fundos.FindAsync(requisicoes.NumeroFundo);
            
            if(fundo is null)
                throw new ArgumentException("Fundo não encontrado.");

            await _context.Entry(fundo).Collection(f => f.Resgates).LoadAsync();

            var aplicacao = fundo.ObterAplicacao(requisicoes.AplicacaoId);

            if(aplicacao.Valor < requisicoes.Valor)
                throw new ArgumentException("O valor do resgate não pode ser maior que o valor da aplicação.");

            aplicacao.RetirarValor(requisicoes.Valor);

            var resgate = new Resgate(requisicoes.Valor, aplicacao);
            resgate.ClienteId = requisicoes.ClienteId;
            resgate.FundoId = requisicoes.NumeroFundo;

            _context.Aplicacoes.Update(aplicacao);
            _context.Fundos.Update(fundo);

            _context.Resgates.Add(resgate);
            await _context.SaveChangesAsync();

            return new ResgateDto(resgate.Id, requisicoes.Valor, resgate.DataResgate, resgate.ImpostoDeRenda, resgate.ValorLiquido);
        }
        public async Task<List<FundoDetalhesDto>> Listar()
        {
            var fundos = await _context.Fundos
                .Include(f => f.Aplicacoes)
                .Include(f => f.Resgates)
                .ToListAsync();

            var fundosDto = fundos.Select(x => x.MapearParaDto()).ToList();

            return fundosDto;

        }
    }
}
