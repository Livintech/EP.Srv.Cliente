using EP.Srv.Cliente.Application.Interfaces;
using EP.Srv.Cliente.Domain.Entities;
using EP.Srv.Cliente.Domain.Responses;
using EP.Srv.Cliente.Infrastructure.Interfaces;
using EP.Srv.Cliente.Infrastructure.Repositories;

namespace EP.Srv.Cliente.Application.Services
{
    public class CentroCustosService : ICentroCustosService
    {
        private readonly ICentroDeCustoRepository _centroDeCustoRepository;

        public CentroCustosService(ICentroDeCustoRepository centroDeCustoRepository)
            => _centroDeCustoRepository = centroDeCustoRepository;

        public async Task<BaseResponse> AtualizarCentroCustoAsync(CentroCustos centroCustos)
        {
            var baseResponse = new BaseResponse();
            try
            {
                var response = await _centroDeCustoRepository.AtualizaCentroCustoAsync(centroCustos);
                baseResponse.Data = response;
                baseResponse.Success = true;
                baseResponse.Message = "Centro de custo atualizado com sucesso.";
            }
            catch (Exception ex)
            {
                baseResponse.Success = false;
                baseResponse.Message = ex.Message;
            }

            return baseResponse;
        }

        public async Task<BaseResponse> GravarCentroCustoAsync(CentroCustos centroCustos)
        {
            var baseResponse = new BaseResponse();
            try
            {
                var response = await _centroDeCustoRepository.GravarCentroCustoAsync(centroCustos);
                baseResponse.Data = response;
                baseResponse.Success = true;
                baseResponse.Message = "Centro de custo cadastrado com sucesso.";
            }
            catch (Exception ex)
            {
                baseResponse.Success = false;
                baseResponse.Message = ex.Message;
            }

            return baseResponse;
        }

        public async Task<BaseResponse> ListarCentroCustoAsync()
            => new BaseResponse { Data = await _centroDeCustoRepository.ListarCentroCustoAsync(), Success = true };
    }
}
