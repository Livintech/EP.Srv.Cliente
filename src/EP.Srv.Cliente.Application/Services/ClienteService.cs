using EP.Srv.Cliente.Application.Interfaces;
using EP.Srv.Cliente.Domain.Interfaces;
using EP.Srv.Cliente.Domain.Responses;
using EP.Srv.Cliente.Infrastructure.Interfaces;

namespace EP.Srv.Cliente.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IUserIdentity _userIdentity;

        public ClienteService(IClienteRepository clienteRepository, IUserIdentity userIdentity, IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
            _clienteRepository = clienteRepository;
            _userIdentity = userIdentity;
        }

        public async Task<BaseResponse> AtualizarClienteAsync(Domain.Entities.Cliente cliente)
        {
            var baseResponse = new BaseResponse();

            try
            {
                var response = await _clienteRepository.AtualizaClienteAsync(cliente);
                baseResponse.Success = true;
                baseResponse.Data = response;
                baseResponse.Message = "Cliente atualizado com sucesso!";
            }
            catch (Exception ex)
            {
                baseResponse.Message = ex.Message;
                baseResponse.Success = false;
            }

            return baseResponse;
        }

        public async Task<BaseResponse> CadastrarAsync(Domain.Entities.Cliente cliente)
        {
            var baseResponse = new BaseResponse();
            
            try
            {
                var response = await _clienteRepository.CadastrarAsync(cliente);
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

        public async Task<BaseResponse> LiatarClientesAsync(string codigoEmpresa)
        {
            var baseResponse = new BaseResponse();

            try
            {
                //var codigoEmpresa = _userIdentity.Perfil != "Master" ? _userIdentity.CodigoEmpresa.Substring(0, 5) : null;
                var clientes = await _clienteRepository.ListarTodosAsync();

                if(!string.IsNullOrEmpty(codigoEmpresa)) 
                {
                    clientes = clientes.Where(c => c.CodigoEmpresa == codigoEmpresa).ToList();
                }

                baseResponse.Data = clientes;
                baseResponse.Success = true;
            }
            catch (Exception ex)
            {
                baseResponse.Message = ex.Message;
                baseResponse.Success = false;
            }

            return baseResponse;
        }

        public async Task<BaseResponse> LiatarEmpresasAsync()
        {
            var baseResponse = new BaseResponse();

            try
            {
                var clientes = await _empresaRepository.ListarTodosAsync();
                baseResponse.Data = clientes.ToList();
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
