using EP.Srv.Cliente.Application.Interfaces;
using EP.Srv.Cliente.Domain.Entities;
using EP.Srv.Cliente.Domain.Interfaces;
using EP.Srv.Cliente.Domain.Responses;
using EP.Srv.Cliente.Infrastructure.Interfaces;
using EP.Srv.Cliente.Infrastructure.Repositories;

namespace EP.Srv.Cliente.Application.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IUserIdentity _userIdentity;

        public EmpresaService(IEmpresaRepository empresaRepository, IUserIdentity userIdentity)
        {
            _empresaRepository = empresaRepository;
            _userIdentity = userIdentity;
        }

        public async Task<BaseResponse> AtualizarEmpresaAsync(Empresa empresa)
        {
            var baseResponse = new BaseResponse();
            try
            {
                var response = await _empresaRepository.AtualizarEmpresaAsync(empresa);
                baseResponse.Success = true;
                baseResponse.Data = response;
                baseResponse.Message = "Empresa atualizado com sucesso!";
            }
            catch (Exception ex)
            {
                baseResponse.Message = ex.Message;
                baseResponse.Success = false;
            }

            return baseResponse;
        }

        public async Task<BaseResponse> CadastrarEmpresaAsync(Empresa empresa)
        {
            var baseResponse = new BaseResponse();
            try
            {
                var response = await _empresaRepository.CadastrarAsync(empresa);
                baseResponse.Success = true;
                baseResponse.Data = response;
                baseResponse.Message = "Cadastro efetuado com sucesso!";
            }
            catch (Exception ex)
            {
                baseResponse.Message = ex.Message;
                baseResponse.Success = false;
            }

            return baseResponse;
        }

        public async Task<BaseResponse> ListarEmpresasAsync(string codigoEmpresa)
        {
            var baseResponse = new BaseResponse();
            try
            {
                var response = await _empresaRepository.ListarTodosAsync();

                if (!string.IsNullOrEmpty(codigoEmpresa))
                {
                    response = response.Where(e => e.Id == int.Parse(codigoEmpresa)).ToList();
                }

                baseResponse.Data = response;
                baseResponse.Success = true;
            }
            catch (Exception ex)
            {
                baseResponse.Message = ex.Message;
                baseResponse.Success = false;
            }

            return baseResponse;
        }
    }
}
