using Microsoft.Extensions.Options;
using EmployeeManagement.Models.entities;
using EmployeeManagement.Repositories;
using EmployeeManagement.Models.JWT;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace EmployeeManagement.Services.implementation
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository _empleadoRepository;
        //private readonly ICargoRepository _cargoRepository;
        private readonly IConfiguration _configuration;
        public EmpleadoService(IEmpleadoRepository empleadoRepository, IConfiguration configuration)
        {
            this._empleadoRepository = empleadoRepository;
            this._configuration = configuration;
        }

        public Empleado Authenticate(string username, string password)
        {
            var empleado = this._empleadoRepository.GetEmpleados().SingleOrDefault(e => e.Username == username && e.Pass == this.CalculateHash(password));
            if (empleado == null) return empleado!;


            var tokenHandler = new JwtSecurityTokenHandler();
            var strKey = this._configuration.GetValue<string>("JwtSettings:Key");
            var key = System.Text.Encoding.ASCII.GetBytes(strKey);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[] {
                        new Claim ("UserName", empleado.Username!),
                        new Claim ($"First Name", empleado.Name!),
                        new Claim(ClaimTypes.Role, "Administrador")
                    }
                ),
                Expires = DateTime.Now.AddHours(1),
                NotBefore = DateTime.Now,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            empleado.Token = tokenHandler.WriteToken(token);
            empleado.Pass = string.Empty;

            return empleado;
        }

        public string CalculateHash(string plaintText)
        {
            using var sha1 = System.Security.Cryptography.SHA1.Create();
            var bytes = System.Text.Encoding.UTF8.GetBytes(plaintText);
            var sb = new System.Text.StringBuilder();

            var cipherBytes = sha1.ComputeHash(bytes);
            foreach (var b in cipherBytes)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }

        public Empleado GetEmpleado(int idEmpleado)
        {
            var empleado = this._empleadoRepository.GetEmpleado(idEmpleado);
            empleado.Token = "";
            empleado.Pass = "";
            return empleado;
        }

        public IEnumerable<Empleado> GetEmpleados()
        {
            var empleados = this._empleadoRepository.GetEmpleados();
            return empleados.Select(e =>
            {
                e.Pass = "";
                e.Token = "";
                return e;
            });

        }

        public bool InsertarEmpleado(Empleado empleado)
        {
            var hashPass = empleado.Pass;
            empleado.Pass = this.CalculateHash(hashPass);
            return this._empleadoRepository.Insert(empleado);
        }

        public bool DeleteEmpleado(int idEmpleado)
        {
            return this._empleadoRepository.Delete(idEmpleado);
        }

        public bool UpdateEmpleado(int idEmpleado, Empleado empleado)
        {
            var hashPass = empleado.Pass;
            empleado.Pass = this.CalculateHash(hashPass);
            return this._empleadoRepository.Update(idEmpleado, empleado);
        }
    }
}