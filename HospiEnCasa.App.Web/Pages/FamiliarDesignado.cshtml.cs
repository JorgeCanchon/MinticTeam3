using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Dominio;
using System;
using System.Collections.Generic;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Web.Pages;

public class FamiliarDesignadoModel : PageModel
{
    private readonly ILogger<FamiliarDesignadoModel> _logger;
    private static IRepositorioPaciente _repoPaciente = new RepositorioPaciente(new Persistencia.AppContext());
    public Dictionary<int, string> Genero = new Dictionary<int, string>();
    public List<Paciente> Pacientes = new List<Paciente>();

    public FamiliarDesignadoModel(ILogger<FamiliarDesignadoModel> logger)
    {
        _logger = logger;
    }

    private void SetGeneros()
    {
        Genero.Add(1, "M");
        Genero.Add(2, "F");
    }

    private void SetPacientes()
    {
        Paciente paciente = new Paciente() {
            Id = 1,
            Nombre = "Jorge Luis",
            Apellidos = "Canchon Espinosa"
        };

        Pacientes.Add(paciente);

        Paciente paciente1 = new Paciente() {
            Id = 1,
            Nombre = "Diego Fernando",
            Apellidos = "Canchon Espinosa"
        };

        Pacientes.Add(paciente1);
    }


    public void OnGet()
    {
        SetGeneros();
        SetPacientes();
    }
}
