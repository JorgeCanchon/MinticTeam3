using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Dominio;
using System;
using System.Linq;
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
        var pacientes = _repoPaciente.GetAllPacientes().ToList();
        Pacientes.AddRange(pacientes);
    }


    public void OnGet()
    {
        SetGeneros();
        SetPacientes();
    }
}
