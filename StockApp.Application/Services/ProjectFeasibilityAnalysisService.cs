using StockApp.Application.DTOs;
using StockApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.Services
{
    public class ProjectFeasibilityAnalysisService : IProjectFeasibilityAnalysisService
    {
        public async Task<ProjectFeasibilityDTO> AnalyzeFeasibilityAsync(int projectId)
        {
           var feasibilityScore = CalculateFeasibilityScore(projectId);
            var comments = GenerateComments(feasibilityScore);

            return new ProjectFeasibilityDTO
            {
                ProjectId = projectId,
                FeasibilityScore = feasibilityScore,
                Comments = comments
            };
        }

        private int CalculateFeasibilityScore(int projectId)
        {
             return 90; 
        }

        private string GenerateComments(int feasibilityScore)
        {
             return "Projeto viável com alta taxa de retorno"; 
        }
    }
}