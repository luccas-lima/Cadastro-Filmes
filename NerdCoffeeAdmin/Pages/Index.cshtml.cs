using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;

namespace NerdCoffeeAdmin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            try
            {
                // Exemplo de lógica (pode ser personalizado conforme necessário)
                var result = PerformSomeOperation();
                _logger.LogInformation($"Operation result: {result}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred: {ex.Message}");
            }
        }

        private string PerformSomeOperation()
        {
            // Exemplo: Simula alguma operação e retorna um resultado
            return "Operation successful";
        }
    }
}
