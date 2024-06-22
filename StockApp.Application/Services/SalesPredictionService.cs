using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML;
using StockApp.Application.Interfaces;

namespace StockApp.Application.Services
{
    public class SalesPredictionService : ISalesPredictionService
    {
        private readonly PredictionEngine<ModelInput, ModelOutput> _predictionEngine;

        public SalesPredictionService()
        {
            // Carregar o modelo treinado (substitua 'path_to_model.zip' pelo caminho do seu modelo)
            var mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load("path_to_model.zip", out var modelInputSchema);
            _predictionEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
        }

        public double PredictSales(int productId, int month, int year)
        {
            // Criar um objeto ModelInput com os dados de entrada
            var input = new ModelInput
            {
                ProductId = productId,
                Month = month,
                Year = year
            };

            // Fazer a previsão usando o modelo carregado
            var prediction = _predictionEngine.Predict(input);

            // Retornar a previsão de vendas
            return prediction.PredictedSales;
        }

        // Definição da estrutura de entrada do modelo
        public class ModelInput
        {
            public int ProductId { get; set; }
            public int Month { get; set; }
            public int Year { get; set; }
        }

        // Definição da estrutura de saída do modelo
        public class ModelOutput
        {
            public float PredictedSales { get; set; }
        }
    }
}
