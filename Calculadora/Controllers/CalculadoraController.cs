using Microsoft.AspNetCore.Mvc;

namespace Calculadora.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculadoraController : ControllerBase
{
    private readonly ILogger<CalculadoraController> _logger;

    public CalculadoraController(ILogger<CalculadoraController> logger)
    {
        _logger = logger;
    }

    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    public IActionResult Soma(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);

            return Ok(sum.ToString());
        }
        return BadRequest("Input invalido");
    }

    [HttpGet("sub/{firstNumber}/{secondNumber}")]
    public IActionResult Subtracao(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);

            return Ok(sum.ToString());
        }
        return BadRequest("Input invalido");
    }

    [HttpGet("mul/{firstNumber}/{secondNumber}")]
    public IActionResult Multiplicacao(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);

            return Ok(sum.ToString());
        }
        return BadRequest("Input invalido");
    }

    [HttpGet("Div/{firstNumber}/{secondNumber}")]
    public IActionResult Divisao(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber) && ConvertToDecimal(secondNumber) != 0)
        {
            var sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);

            return Ok(sum.ToString());
        }
        return BadRequest("Input invalido");
    }
    [HttpGet("Media/{firstNumber}/{secondNumber}")]
    public IActionResult Media(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber) && ConvertToDecimal(firstNumber) != 0 && ConvertToDecimal(secondNumber) != 0)
        {
            var sum = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber));
            sum = sum / 2;

            return Ok(sum.ToString());
        }
        return BadRequest("Input invalido");
    }
    [HttpGet("Raiz/{strNumber}")]
    public IActionResult Raiz(string strNumber)
    {
        if (IsNumeric(strNumber) && ConvertToDecimal(strNumber) >= 0)
        {
            var sum = Math.Sqrt((double)ConvertToDecimal(strNumber));

            return Ok(sum.ToString());
        }
        return BadRequest("Input invalido");
    }

    private decimal ConvertToDecimal(string strNumber)
    {
        decimal decimalValue;
        if (decimal.TryParse(strNumber, out decimalValue))
        {
            return decimalValue;
        }
        return 0;
    }

    private bool IsNumeric(string strNumber)
    {
        double number;
        bool isNumber = double.TryParse(
            strNumber,
            System.Globalization.NumberStyles.Any,
            System.Globalization.NumberFormatInfo.InvariantInfo,
            out number //Se a variavel strNumber, que é uma string, conseguir converter para number.
            );
        return isNumber;
    }
}
