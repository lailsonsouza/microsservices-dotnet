using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNET.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{

    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet("sum/{type}/{firstNumber}/{secondNumber}")]
    public IActionResult Get(int type, string firstNumber, string secondNumber)
    {
        if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            switch (type)
            {
                case 1:
                    var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                    return Ok(sum.ToString());
         
                case 2:
                    var mult = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                    return Ok(mult.ToString());
                case 3:
                    var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                    return Ok(div.ToString());
                case 4:
                    var media = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber))/2;
                    return Ok(media.ToString());
                case 5:
                    var raiz = Math.Sqrt((double)ConvertToDecimal(firstNumber));
                    return Ok(raiz.ToString());
                default: return BadRequest("invalido");
            }
             
        } 
        return BadRequest("invalid Input");
    }
    
    private bool IsNumeric(string strNumber)
    {
        double number;
        bool isNumber = double.TryParse(strNumber, 
            System.Globalization.NumberStyles.Any,
            System.Globalization.NumberFormatInfo.InvariantInfo,
            out number);
        return isNumber;
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
}
