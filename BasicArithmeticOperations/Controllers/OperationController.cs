using BasicArithmeticOperations.Utils;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BasicArithmeticOperations.Controllers
{
    [ApiController]
    [Route("api/ops")]
    public class OperationController : ControllerBase
    {
        private readonly ILogger<OperationController> _logger;

        public OperationController(ILogger<OperationController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add(decimal firstNum, decimal secNum)
        {
            try
            {
                _logger.LogInformation(LogEvents.Add, "GET Add called for {firstNum} and {secNum}.", firstNum, secNum);
                decimal result = Calculator.Add(firstNum, secNum);
                return Ok(result);
            }
            catch (Exception ex) 
            {
                // result is out of value range
                _logger.LogWarning(LogEvents.RangeLimitExceeded, ex, "Add request for {firstNum} and {secNum}", firstNum, secNum);
                return BadRequest(Messages.RangeLimitExceeded);
            }
        }

        [HttpGet]
        [Route("subtract")]
        public IActionResult Subtract(decimal minuend, decimal subtrahend)
        {
            try
            {
                _logger.LogInformation(LogEvents.Subtract, "GET Subtract called for {minuend} and {subtrahend}.", minuend, subtrahend);
                decimal result = Calculator.Subtract(minuend, subtrahend);
                return Ok(result);
            }
            catch (Exception ex) 
            {
                // result is out of value range
                _logger.LogWarning(LogEvents.RangeLimitExceeded, ex, "Subtract request for {minuend} and {subtrahend}", minuend, subtrahend);
                return BadRequest(Messages.RangeLimitExceeded);
            }
        }

        [HttpGet]
        [Route("multiply")]
        public IActionResult Multiply(decimal firstNum, decimal secNum)
        {
            try
            {
                _logger.LogInformation(LogEvents.Subtract, "GET Multiply called for {firstNum} and {secNum}.", firstNum, secNum);
                decimal result = Calculator.Multiply(firstNum, secNum);
                return Ok(result);
            }
            catch (Exception ex) 
            {
                // result is out of value range
                _logger.LogWarning(LogEvents.RangeLimitExceeded, ex, "Multiply request for {firstNum} and {secNum}", firstNum, secNum);
                return BadRequest(Messages.RangeLimitExceeded);
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
                decimal result = Calculator.Divide(dividend, divisor);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // result is out of value range
                _logger.LogWarning(LogEvents.RangeLimitExceeded, ex, "Divide request for {dividend} and {divisor}", dividend, divisor);
                return BadRequest(Messages.RangeLimitExceeded);
            }
        }

    }
}