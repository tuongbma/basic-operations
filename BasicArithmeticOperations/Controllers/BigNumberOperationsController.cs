using BasicArithmeticOperations.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Numerics;
using System.Reflection;

namespace BasicArithmeticOperations.Controllers
{
    [ApiController]
    [Route("api/bigNumOps")]
    public class BigNumberOperationsController : ControllerBase
    {
        private readonly ILogger<BigNumberOperationsController> _logger;

        public BigNumberOperationsController(ILogger<BigNumberOperationsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add(string firstNum, string secNum)
        {
            try
            {
                _logger.LogInformation(LogEvents.Add, "GET Add called for {firstNum} and {secNum}.", firstNum, secNum);
                BigInteger first, sec;

                bool isFirstSucceeded = BigInteger.TryParse(firstNum, out first);
                bool isSecSucceeded = BigInteger.TryParse(secNum, out sec);

                if (!isFirstSucceeded || !isSecSucceeded) // if cannot parse
                {
                    _logger.LogInformation(LogEvents.BigAdd, "GET Add called for {firstNum} and {subtrahend}.", firstNum, secNum);
                    return BadRequest(Messages.IntegersOnly);
                }

                BigInteger result = Calculator.AddBigNumbers(first, sec);
                return Ok(result.ToString());
            }
            catch (Exception ex) 
            {
                _logger.LogWarning(LogEvents.InternalError, ex, "BigAdd request for {firstNum} and {secNum}", firstNum, secNum);
                return StatusCode(500, Messages.InternalError);
            }
        }

        [HttpGet]
        [Route("subtract")]
        public IActionResult Subtract(string minuend, string subtrahend)
        {
            try
            {
                _logger.LogInformation(LogEvents.BigSubtract, "GET Subtract called for {minuend} and {subtrahend}.", minuend, subtrahend);

                BigInteger min, sub;
                bool isFirstSucceeded = BigInteger.TryParse(minuend, out min);
                bool isSecSucceeded = BigInteger.TryParse(subtrahend, out sub);

                if (!isFirstSucceeded || !isSecSucceeded) // if cannot parse
                {
                    _logger.LogInformation(LogEvents.BigSubtract, "GET Subtract called for {minuend} and {subtrahend}.", minuend, subtrahend);
                    return BadRequest(Messages.IntegersOnly);
                }

                BigInteger result = Calculator.SubtractBigNumbers(min, sub);
                return Ok(result.ToString());
            }
            catch (Exception ex)
            {
                _logger.LogWarning(LogEvents.InternalError, ex, "BigSubtract request for {minuend} and {subtrahend}", minuend, subtrahend);
                return StatusCode(500, Messages.InternalError);
            }
        }

        [HttpGet]
        [Route("multiply")]
        public IActionResult Multiply(string firstNum, string secNum)
        {
            try
            {
                _logger.LogInformation(LogEvents.BigMultiply, "GET Multiply called for {firstNum} and {secNum}.", firstNum, secNum);
                BigInteger first, sec;

                bool isFirstSucceeded = BigInteger.TryParse(firstNum, out first);
                bool isSecSucceeded = BigInteger.TryParse(secNum, out sec);

                if (!isFirstSucceeded || !isSecSucceeded) // if cannot parse
                {
                    _logger.LogInformation(LogEvents.BigMultiply, "GET Multiply called for {firstNum} and {subtrahend}.", firstNum, secNum);
                    return BadRequest(Messages.IntegersOnly);
                }

                BigInteger result = Calculator.MultiplyBigNumbers(first, sec);
                return Ok(result.ToString());
            }
            catch (Exception ex) 
            {
                _logger.LogWarning(LogEvents.InternalError, ex, "BigMultiply request for {firstNum} and {secNum}", firstNum, secNum);
                return StatusCode(500, Messages.InternalError);
            }

        }

        [HttpGet]
        [Route("divide")]
        public IActionResult Divide(string dividend, string divisor)
        {
            try
            {
                _logger.LogInformation(LogEvents.Subtract, "GET Divide called for {dividend} and {divisor}.", dividend, divisor);
                BigInteger divd, divs;

                bool isFirstSucceeded = BigInteger.TryParse(dividend, out divd);
                bool isSecSucceeded = BigInteger.TryParse(divisor, out divs);

                if (!isFirstSucceeded || !isSecSucceeded) // if cannot parse
                {
                    _logger.LogInformation(LogEvents.BigDivide, "GET Divide called for {dividend} and {divisor}.", dividend, divisor);
                    return BadRequest(Messages.IntegersOnly);
                }


                if (divs == 0) // check if divisor is 0
                {
                    _logger.LogWarning(LogEvents.DivisionByZero, "BigDivide {dividend} by {divisor}.", dividend, divisor);
                    return BadRequest(Messages.DivisionByZero);
                }

                BigInteger result = Calculator.DivideBigNumbers(divd, divs);
                return Ok("Result in integer: " + result.ToString());
            }
            catch (Exception ex)
            {
                // result is out of value range
                _logger.LogWarning(LogEvents.InternalError, ex, "BigDivide request for {dividend} and {divisor}", dividend, divisor);
                return StatusCode(500, Messages.InternalError);
            }
        }
    }
}