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
                if (ex is ArgumentException)
                {
                    _logger.LogWarning(LogEvents.Add, "Add request for {firstNum} and {secNum}", firstNum, secNum);
                    return StatusCode(StatusCodes.Status400BadRequest, Messages.NumericArgumentOnly);
                }
                else
                {
                    _logger.LogWarning(LogEvents.RangeLimitExceeded, ex, "Add request for {firstNum} and {secNum}", firstNum, secNum);
                    return StatusCode(StatusCodes.Status400BadRequest, Messages.RangeLimitExceeded);
                }
            }
        }

        [HttpGet]
        [Route("subtract")]
        public IActionResult Subtract(string minuend, string subtrahend)
        {
            try
            {
                _logger.LogInformation(LogEvents.Subtract, "GET Subtract called for {minuend} and {subtrahend}.", minuend, subtrahend);

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

                if (ex is ArgumentException)
                {
                    _logger.LogWarning(LogEvents.Subtract, "Subtract request for {minuend} and {subtrahend}", minuend, subtrahend);
                    return StatusCode(StatusCodes.Status400BadRequest, Messages.NumericArgumentOnly);
                }
                else
                {
                    _logger.LogWarning(LogEvents.Subtract, ex, "Subtract request for {minuend} and {subtrahend}", minuend, subtrahend);
                    return StatusCode(StatusCodes.Status500InternalServerError, Messages.InternalError);
                }
            }
        }

        [HttpGet]
        [Route("multiply")]
        public IActionResult Multiply(string firstNum, string secNum)
        {
            try
            {
                _logger.LogInformation(LogEvents.Multiply, "GET Multiply called for {firstNum} and {secNum}.", firstNum, secNum);

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
                if (ex is ArgumentException)
                {
                    _logger.LogWarning(LogEvents.Multiply, "Multiply request for {firstNum} and {secNum}", firstNum, secNum);
                    return StatusCode(StatusCodes.Status400BadRequest, Messages.NumericArgumentOnly);
                }
                else
                {
                    _logger.LogWarning(LogEvents.Multiply, "Multiply request for {firstNum} and {secNum}", firstNum, secNum);
                    return StatusCode(StatusCodes.Status500InternalServerError, Messages.InternalError);
                }
            }
           
        }

        [HttpGet]
        [Route("divide")]
        public IActionResult Divide(string dividend, string divisor)
        {
            try
            {
                _logger.LogInformation(LogEvents.Subtract, "GET Divide called for {dividend} and {divisor}.", dividend, divisor);

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
                if (ex is ArgumentException)
                {
                    _logger.LogWarning(LogEvents.Divide, "Divide request for {dividend} and {divisor}", dividend, divisor);
                    return StatusCode(StatusCodes.Status400BadRequest, Messages.NumericArgumentOnly);
                }
                else
                {
                    _logger.LogWarning(LogEvents.Divide, "Divide request for {dividend} and {divisor}", dividend, divisor);
                    return StatusCode(StatusCodes.Status500InternalServerError, Messages.InternalError);
                }
            }
        }
    }
}