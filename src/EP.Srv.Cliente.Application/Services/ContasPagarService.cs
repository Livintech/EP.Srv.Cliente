using DocumentFormat.OpenXml.Office2010.Excel;
using EP.Srv.Cliente.Application.Interfaces;
using EP.Srv.Cliente.Domain.Entities;
using EP.Srv.Cliente.Domain.Responses;
using EP.Srv.Cliente.Infrastructure.Interfaces;
using EP.Srv.Cliente.Infrastructure.Repositories;

namespace EP.Srv.Cliente.Application.Services
{
    public class ContasPagarService : IContasPagarService
    {
        private readonly IContasPagarRepository _contasPagarRepository;

        public ContasPagarService(IContasPagarRepository contasPagarRepository)
        {
            _contasPagarRepository = contasPagarRepository;
        }

        public async Task<BaseResponse> AtualizarLancamentoAsync(ContasPagar contasPagar)
        {
            var baseResponse = new BaseResponse();
            try
            {
                var response = await _contasPagarRepository.AtualizarLancamentoAsync(contasPagar);
                baseResponse.Data = response;
                baseResponse.Success = true;
                baseResponse.Message = "Lançamento atualizado com sucesso.";
            }
            catch (Exception ex)
            {
                baseResponse.Success = false;
                baseResponse.Message = ex.Message;
            }

            return baseResponse;
        }

        public async Task<BaseResponse> CadastrarLancamentoAsync(ContasPagar contasPagar)
        {
            var baseResponse = new BaseResponse();
            try
            {
                var response = await _contasPagarRepository.CadastrarLancamentoAsync(contasPagar);
                baseResponse.Data = response;
                baseResponse.Success = true;
                baseResponse.Message = "Lançamento cadastrado com sucesso.";
            }
            catch (Exception ex)
            {
                baseResponse.Success = false;
                baseResponse.Message = ex.Message;
            }

            return baseResponse;
        }

        public async Task<BaseResponse> ListarLancamentosAsync()
        {
            var baseResponse = new BaseResponse();
            try
            {
                var response = await _contasPagarRepository.ListarLancamentosAsync();
                baseResponse.Data = response;
                baseResponse.Success = true;
            }
            catch (Exception ex)
            {
                baseResponse.Success = false;
                baseResponse.Message = ex.Message;
            }

            return baseResponse;
        }
    }
}
