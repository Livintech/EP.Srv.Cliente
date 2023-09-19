using EP.Srv.Cliente.Application.Interfaces;
using EP.Srv.Cliente.Domain.Entities;
using EP.Srv.Cliente.Domain.Responses;
using EP.Srv.Cliente.Infrastructure.Interfaces;

namespace EP.Srv.Cliente.Application.Services
{
    public class FormaPagamentoService : IFormaPagamentoService
    {
        private readonly IFormaPagamentosRepository _formaPagamentosRepository;

        public FormaPagamentoService(IFormaPagamentosRepository formaPagamentosRepository)
        {
            _formaPagamentosRepository = formaPagamentosRepository;
        }

        public async Task<BaseResponse> AtualizaPagamentoAsync(FormaPagamento formaPagamento)
        {
            var baseResponse = new BaseResponse();
            try
            {
                var response = await _formaPagamentosRepository.AtualizaPagamentoAsync(formaPagamento);
                baseResponse.Data = response;
                baseResponse.Success = true;
                baseResponse.Message = "Forma de pagamento atualizado com sucesso.";
            }
            catch (Exception ex)
            {
                baseResponse.Success = false;
                baseResponse.Message = ex.Message;
            }

            return baseResponse;
        }

        public async Task<BaseResponse> CadastrarAsync(FormaPagamento formaPagamento)
        {
            var baseResponse = new BaseResponse();
            try
            {
                var response = await _formaPagamentosRepository.CadastrarAsync(formaPagamento);
                baseResponse.Data = response;
                baseResponse.Success = true;
                baseResponse.Message = "Forma de pagamento cadastrado com sucesso.";
            }
            catch (Exception ex)
            {
                baseResponse.Success = false;
                baseResponse.Message = ex.Message;
            }

            return baseResponse;
        }

        public async Task<BaseResponse> ListarFormasPagamentosAsync(string empresaId)
        {
            var baseResponse = new BaseResponse();
            try
            {
                var response = await _formaPagamentosRepository.ListarFormasPagamentosAsync();

                if (!string.IsNullOrEmpty(empresaId))
                {
                    response = response.Where(c => c.EmpresaId == int.Parse(empresaId)).ToList();
                }

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
