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
        public IActionResult Add(decimal firstNum, decimal secNum)
        {
            try
            {
                _logger.LogInformation(LogEvents.Add, "GET Add called for {firstNum} and {secNum}.", firstNum, secNum);
                decimal result = _calculator.Add(firstNum, secNum);
                return Ok(result);
            }
            catch (Exception ex) 
            {
                // result is out of value range
                _logger.LogWarning(LogEvents.RangeLimitExceeded, ex, "Add request for {firstNum} and {secNum}", firstNum, secNum);
                return StatusCode(500, Messages.RangeLimitExceeded);
            }
        }

        [HttpGet]
        [Route("subtract")]
        public IActionResult Subtract(decimal minuend, decimal subtrahend)
        {
            try
            {
                _logger.LogInformation(LogEvents.Subtract, "GET Subtract called for {minuend} and {subtrahend}.", minuend, subtrahend);
                decimal result = _calculator.Subtract(minuend, subtrahend);
                return Ok(result);
            }
            catch (Exception ex) 
            {
                // result is out of value range
                _logger.LogWarning(LogEvents.RangeLimitExceeded, ex, "Subtract request for {minuend} and {subtrahend}", minuend, subtrahend);
                return StatusCode(500, Messages.RangeLimitExceeded);
            }
        }

        [HttpGet]
        [Route("multiply")]
        public IActionResult Multiply(decimal firstNum, decimal secNum)
        {
            try
            {
                _logger.LogInformation(LogEvents.Multiply, "GET Multiply called for {firstNum} and {secNum}.", firstNum, secNum);
                decimal result = _calculator.Multiply(firstNum, secNum);
                return Ok(result);
            }
            catch (Exception ex) 
            {
                // result is out of value range
                _logger.LogWarning(LogEvents.RangeLimitExceeded, ex, "Multiply request for {firstNum} and {secNum}", firstNum, secNum);
                return StatusCode(500, Messages.RangeLimitExceeded);
            }
           
        }

        [HttpGet]
        [Route("divide")]
        public IActionResult Divide(decimal dividend, decimal divisor)
        {
            try
            {
                _logger.LogInformation(LogEvents.Subtract, "GET Divide called for {dividend} and {divisor}.", dividend, divisor);

                if (divisor == 0) // check if divisor is 0
                {
                    _logger.LogWarning(LogEvents.DivisionByZero, "Divide {dividend} by {divisor}.", dividend, divisor);
                    return BadRequest(Messages.DivisionByZero);
                }
                decimal result = _calculator.Divide(dividend, divisor);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // result is out of value range
                _logger.LogWarning(LogEvents.RangeLimitExceeded, ex, "Divide request for {dividend} and {divisor}", dividend, divisor);
                return StatusCode(500, Messages.RangeLimitExceeded);
            }
        }
    }
}