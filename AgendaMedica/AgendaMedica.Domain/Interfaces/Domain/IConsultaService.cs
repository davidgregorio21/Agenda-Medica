﻿using AgendaMedica.Domain.Entities;
using System;
using System.Collections.Generic;

namespace AgendaMedica.Domain.Interfaces.Domain
{
    public interface IConsultaService : IService<Consulta>
    {
        IEnumerable<Dictionary<string, string>> RelatorioConsultas(int profissionalId, int ano);
        Dictionary<int, Dictionary<string, int>> RelatorioConsultas(int profissionalId, int ano, int mes);
    }
}
