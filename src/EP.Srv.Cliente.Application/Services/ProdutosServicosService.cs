using EP.Srv.Cliente.Application.Interfaces;
using EP.Srv.Cliente.Domain.Entities;
using EP.Srv.Cliente.Domain.Responses;
using EP.Srv.Cliente.Infrastructure.Interfaces;

namespace EP.Srv.Cliente.Application.Services
{
    public class ProdutosServicosService : IProdutosServicosService
    {
        private readonly IProdutosServicosRepository _produtosServicosRepository;

        public ProdutosServicosService(IProdutosServicosRepository produtosServicosRepository)
            => _produtosServicosRepository = produtosServicosRepository;

        public async Task<BaseResponse> AtualizarProdutosServicosAsync(ProdutosServicos produtosServicos)
        {
            var baseResponse = new BaseResponse();
            try
            {
                var response = await _produtosServicosRepository.AtualizarProdutosServicosAsync(produtosServicos);
                baseResponse.Data = response;
                baseResponse.Success = true;
                baseResponse.Message = "PRoduto/Serviço atualizado com sucesso.";
            }
            catch (Exception ex)
            {
                baseResponse.Success = false;
                baseResponse.Message = ex.Message;
            }

            return baseResponse;
        }

        public async Task<BaseResponse> GravarPRodutosServicosAsync(ProdutosServicos produtosServicos)
        {
            var baseResponse = new BaseResponse();
            try
            {
                var response = await _produtosServicosRepository.GravarPRodutosServicosAsync(produtosServicos);
                baseResponse.Data = response;
                baseResponse.Success = true;
                baseResponse.Message = "Produto/Serviço cadastrado com sucesso.";
            }
            catch (Exception ex)
            {
                baseResponse.Success = false;
                baseResponse.Message = ex.Message;
            }

            return baseResponse;
        }

        public async Task<BaseResponse> ListarProdutosServicosAsync(string empresaId)
        {
            var baseResponse = new BaseResponse();
            try
            {
                var response = await _produtosServicosRepository.ListarProdutosServicosAsync();
                baseResponse.Data = response.Where(a => a.EmpresaId == int.Parse(empresaId)).ToList();
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
