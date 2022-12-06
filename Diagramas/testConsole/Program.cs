using testConsole.Models.entities;

PizzitasContext context = new PizzitasContext();

var empleado = context.Empleados.FirstOrDefault(e => e.Idempleado == 3);
var cargo = context.Cargos.FirstOrDefault(c => c.Idcargo == empleado.Idcargo);

Console.WriteLine(cargo.Name);