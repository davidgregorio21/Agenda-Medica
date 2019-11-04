﻿using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.Interfaces.Domain;
using AgendaMedica.Domain.Interfaces.Repositories;
using AgendaMedica.Domain.Validations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgendaMedica.Domain.Services
{
    public class ConsultaService : Service<Consulta>, IConsultaService
    {
        private readonly IUsuarioProfissionalRepository _usuarioProfissionalRepository;
        private readonly IUsuarioPacienteRepository _usuarioPacienteRepository;

        public ConsultaService(IConsultaRepository consultaRepository,
            IUsuarioProfissionalRepository usuarioProfissionalRepository,
            IUsuarioPacienteRepository usuarioPacienteRepository)
            : base(consultaRepository)
        {
            _usuarioProfissionalRepository = usuarioProfissionalRepository;
            _usuarioPacienteRepository = usuarioPacienteRepository;
        }

        public override void Add(Consulta consulta)
        {
            consulta.Profissional = _usuarioProfissionalRepository.GetAll()
                .Where(x => x.Id == consulta.ProfissionalId)
                .Include(x => x.Agendas)
                    .ThenInclude(x => x.Horarios)
                .Include(x => x.Consultas)
                .SingleOrDefault();

            consulta.Paciente = _usuarioPacienteRepository.GetAll()
                .Where(x => x.Id == consulta.PacienteId)
                .Include(x => x.Consultas)
                .SingleOrDefault();

            consulta.ValidationResult = new ConsultaValidator().Validate(consulta);

            if (consulta.ValidationResult.IsValid)
                base.Add(consulta);
        }

        public IEnumerable<Dictionary<string, string>> RelatorioConsultas(int profissionalId, int ano)
        {
            string[] meses = new string[]
            {
                "Jan",
                "Fev",
                "Mar",
                "Abr",
                "Mai",
                "Jun",
                "Jul",
                "Ago",
                "Set",
                "Out",
                "Nov",
                "Dez"
            };
            List<Dictionary<string, string>> relatorioConsultasPorMes = new List<Dictionary<string, string>>();
            var consultasDoAnoAgrupadas = GetAll()
                .Where(consulta => (consulta.ProfissionalId == profissionalId) && (consulta.Data.Year == ano))
                .Include(consulta => consulta.Especialidade)
                .GroupBy(consulta => consulta.Data.Month, (mes, consultas) => new
                {
                    Mes = mes,
                    EspecialidadesMes = consultas
                        .GroupBy(consulta => consulta.Especialidade.Nome)
                        .Select(grupoConsultasPorEspecialidade => new
                        {
                            Nome = grupoConsultasPorEspecialidade.Key,
                            Quantidade = grupoConsultasPorEspecialidade.Count()
                        })
                });

            foreach (var grupoConsultas in consultasDoAnoAgrupadas)
            {
                Dictionary<string, string> consultasDoMes = new Dictionary<string, string>
                {
                    ["Mes"] = meses[grupoConsultas.Mes - 1]
                };

                foreach (var especialidadeCount in grupoConsultas.EspecialidadesMes)
                {
                    consultasDoMes.Add(especialidadeCount.Nome, especialidadeCount.Quantidade.ToString());
                }

                relatorioConsultasPorMes.Add(consultasDoMes);
            }

            return relatorioConsultasPorMes;
        }

        public Dictionary<int, Dictionary<string, int>> RelatorioConsultas(int profissionalId, int ano, int mes)
        {
            Dictionary<int, Dictionary<string, int>> relatorioConsultasPorMes = new Dictionary<int, Dictionary<string, int>>();
            var consultasDoMes = GetAll()
                .Where(consulta => (consulta.ProfissionalId == profissionalId) && (consulta.Data.Year == ano) && (consulta.Data.Month == mes))
                .Include(consulta => consulta.Especialidade);

            foreach (Consulta consulta in consultasDoMes)
            {
                Dictionary<string, int> countEspecialidade = new Dictionary<string, int>();
                string especialidadeNome = consulta.Especialidade.Nome;

                if (countEspecialidade.ContainsKey(especialidadeNome))
                    countEspecialidade[especialidadeNome]++;
                else
                    countEspecialidade[especialidadeNome] = 1;

                relatorioConsultasPorMes[consulta.Data.Month] = countEspecialidade;
            }

            return relatorioConsultasPorMes;
        }
    }
}
