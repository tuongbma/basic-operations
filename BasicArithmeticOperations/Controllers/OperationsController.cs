using BasicArithmeticOperations.Utils;
using BasicArithmeticOperations.Utils.Calculator;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Drawing;

namespace BasicArithmeticOperations.Controllers
{
    [ApiController]
    [Route("api/ops")]
    public class OperationsController : ControllerBase
    {
        private readonly ILogger<OperationsController> _logger;
        private readonly ICalculator _calculator;
        public OperationsController(ILogger<OperationsController> logger, ICalculator calculator)
        {
            _logger = logger;
            _calculator = calculator;
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add(string firstNum, string secNum)
        {
            try
            {
                _logger.LogInformation(LogEvents.Add, "GET Add called for {firstNum} and {secNum}.", firstNum, secNum);

                if (!Helper.IsNumericString(firstNum) || !Helper.IsNumericString(secNum)) // not numeric arguments
                {
                    _logger.LogWarning(LogEvents.Add, "Add request for {firstNum} and {secNum}", firstNum, secNum);
                    return StatusCode(StatusCodes.Status400BadRequest, Messages.NumericArgumentOnly);
                }

                string result = _calculator.Add(firstNum, secNum);

                if (String.IsNullOrEmpty(result))
                {
                    _logger.LogWarning(LogEvents.Add, "Add request for {firstNum} and {secNum}", firstNum, secNum);
                    return StatusCode(StatusCodes.Status500InternalServerError, Messages.InternalError);
                }

                return Ok(result);
            }
            catch (Exception ex) 
            {
                // result is out of value range
                _logger.LogWarning(LogEvents.RangeLimitExceeded, ex, "Add request for {firstNum} and {secNum}", firstNum, secNum);
                return StatusCode(StatusCodes.Status400BadRequest, Messages.RangeLimitExceeded);
            }
        }

        [HttpGet]
        [Route("subtract")]
        public IActionResult Subtract(string minuend, string subtrahend)
        {
            try
            {
                _logger.LogInformation(LogEvents.Subtract, "GET Subtract called for {minuend} and {subtrahend}.", minuend, subtrahend);

                if (!Helper.IsNumericString(minuend) || !Helper.IsNumericString(subtrahend)) // not numeric arguments
                {
                    _logger.LogWarning(LogEvents.Subtract, "Subtract request for {minuend} and {subtrahend}", minuend, subtrahend);
                    return StatusCode(StatusCodes.Status400BadRequest, Messages.NumericArgumentOnly);
                }

                string result = _calculator.Subtract(minuend, subtrahend);

                if (String.IsNullOrEmpty(result))
                {
                    _logger.LogWarning(LogEvents.Subtract, "Subtract request for {minuend} and {subtrahend}", minuend, subtrahend);
                    return StatusCode(StatusCodes.Status500InternalServerError, Messages.InternalError);
                }

                return Ok(result);
            }
            catch (Exception ex) 
            {
                // result is out of value range
                _logger.LogWarning(LogEvents.RangeLimitExceeded, ex, "Subtract request for {minuend} and {subtrahend}", minuend, subtrahend);
                return StatusCode(StatusCodes.Status400BadRequest, Messages.RangeLimitExceeded);
            }
        }

        [HttpGet]
        [Route("multiply")]
        public IActionResult Multiply(string firstNum, string secNum)
        {
            try
            {
                _logger.LogInformation(LogEvents.Multiply, "GET Multiply called for {firstNum} and {secNum}.", firstNum, secNum);

                if (!Helper.IsNumericString(firstNum) || !Helper.IsNumericString(secNum)) // not numeric arguments
                {
                    _logger.LogWarning(LogEvents.Multiply, "Multiply request for {firstNum} and {secNum}", firstNum, secNum);
                    return StatusCode(StatusCodes.Status400BadRequest, Messages.NumericArgumentOnly);
                }

                string result = _calculator.Multiply(firstNum, secNum);

                if (String.IsNullOrEmpty(result))
                {
                    _logger.LogWarning(LogEvents.Multiply, "Multiply request for {firstNum} and {secNum}", firstNum, secNum);
                    return StatusCode(StatusCodes.Status500InternalServerError, Messages.InternalError);
                }

                return Ok(result);
            }
            catch (Exception ex) 
            {
                // result is out of value range
                _logger.LogWarning(LogEvents.RangeLimitExceeded, ex, "Multiply request for {firstNum} and {secNum}", firstNum, secNum);
                return StatusCode(StatusCodes.Status400BadRequest, Messages.RangeLimitExceeded);
            }
           
        }

        [HttpGet]
        [Route("divide")]
        public IActionResult Divide(string dividend, string divisor)
        {
            try
            {
                _logger.LogInformation(LogEvents.Subtract, "GET Divide called for {dividend} and {divisor}.", dividend, divisor);

                if (!Helper.IsNumericString(dividend) || !Helper.IsNumericString(divisor)) // not numeric arguments
                {
                    _logger.LogWarning(LogEvents.Divide, "Divide request for {dividend} and {divisor}", dividend, divisor);
                    return StatusCode(StatusCodes.Status400BadRequest, Messages.NumericArgumentOnly);
                }

                if (String.Equals(divisor.Trim(), "0")) // check if divisor is 0
                {
                    _logger.LogWarning(LogEvents.DivisionByZero, "Divide {dividend} by {divisor}.", dividend, divisor);
                    return BadRequest(Messages.DivisionByZero);
                }

                string result = _calculator.Divide(dividend, divisor);

                if (String.IsNullOrEmpty(result))
                {
                    _logger.LogWarning(LogEvents.Divide, "Divide request for {dividend} and {divisor}", dividend, divisor);
                    return StatusCode(StatusCodes.Status500InternalServerError, Messages.InternalError);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                // result is out of value range
                _logger.LogWarning(LogEvents.RangeLimitExceeded, ex, "Divide request for {dividend} and {divisor}", dividend, divisor);
                return StatusCode(StatusCodes.Status400BadRequest, Messages.RangeLimitExceeded);
            }
        }
    }
}