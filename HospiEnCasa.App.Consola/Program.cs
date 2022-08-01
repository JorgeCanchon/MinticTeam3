using System;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Consola
{
    class Program
    {
        private static IRepositorioPaciente _repoPaciente = new RepositorioPaciente(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! Entity Framework");
            AddPaciente();
            //BuscarPaciente(1);
        }
        private static void AddPaciente()
        {
            var paciente = new Paciente
            {
                Nombre = "Juan Camilo",
                Apellidos = "Rodriguez",
                Enfermera = 1,
                Medico = 
                Telefono = "3114563456",
                Genero = Genero.masculino,
                Direccion = "Calle 40",
                // Longitud = 9.54F,
                // Latitud = 45.55F,
                Ciudad = "Santa Marta",
                FechaNacimiento = new DateTime(1972, 11, 08)
            };
            _repoPaciente.Create(paciente);
        }

        private static void BuscarPaciente(int idPaciente)
        {
            var paciente = _repoPaciente.GetPaciente(idPaciente);
            Console.WriteLine(paciente.Nombre + " " + paciente.Apellidos + " " + paciente.Genero);
        }
    }
}