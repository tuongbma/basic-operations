using BasicArithmeticOperations.Utils;
using BasicArithmeticOperations.Utils.Calculator;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;

namespace BasicArithmeticOperations.Controllers
{
    [ApiController]
    [Route("api/bigNumOps")]
    public class BigNumberOperationsController : ControllerBase
    {
        private readonly ILogger<BigNumberOperationsController> _logger;
        private ICalculator _calculator;


        public BigNumberOperationsController(ILogger<BigNumberOperationsController> logger, ICalculator calculator)
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
                _logger.LogInformation(LogEvents.BigAdd, "GET Add called for {firstNum} and {secNum}.", firstNum, secNum);
                BigInteger first, sec;

                bool isFirstSucceeded = BigInteger.TryParse(firstNum, out first);
                bool isSecSucceeded = BigInteger.TryParse(secNum, out sec);

                if (!isFirstSucceeded || !isSecSucceeded) // if cannot parse
                {
                    _logger.LogInformation(LogEvents.BigAdd, "GET BigAdd called for {firstNum} and {secNum}.", firstNum, secNum);
                    return BadRequest(Messages.IntegersOnly);
                }

                BigInteger result = _calculator.AddBigNumbers(first, sec);

                if (!Helper.IsOutOfBuiltInTypeRange(first) && !Helper.IsOutOfBuiltInTypeRange(sec) && !Helper.IsOutOfBuiltInTypeRange(result))
                {
                    /* Only deny the operation if arguments and result are not bigInt.
                    If 2 arguments are normal number but the result is bigInt, we still allow the operation in bigInt mode */
                    _logger.LogInformation(LogEvents.BigAdd, "{firstNum} and {secNum} and their result {result} are not in the big integer range.", firstNum, secNum, result.ToString());
                    return BadRequest(Messages.NotInBigIntRange);
                }

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

                BigInteger result = _calculator.SubtractBigNumbers(min, sub);

                if (!Helper.IsOutOfBuiltInTypeRange(min) && !Helper.IsOutOfBuiltInTypeRange(sub) && !Helper.IsOutOfBuiltInTypeRange(result))
                {
                    /* Only deny the operation if arguments and result are not bigInt.
                    If 2 arguments are normal number but the result is bigInt, we still allow the operation in bigInt mode */
                    _logger.LogInformation(LogEvents.BigSubtract, "{minuend} and {subtrahend} and their result {result} are not in the big integer range.", minuend, subtrahend, result.ToString());
                    return BadRequest(Messages.NotInBigIntRange);
                }

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
                    _logger.LogInformation(LogEvents.BigMultiply, "GET Multiply called for {firstNum} and {secNum}.", firstNum, secNum);
                    return BadRequest(Messages.IntegersOnly);
                }

                BigInteger result = _calculator.MultiplyBigNumbers(first, sec);

                if (!Helper.IsOutOfBuiltInTypeRange(first) && !Helper.IsOutOfBuiltInTypeRange(sec) && !Helper.IsOutOfBuiltInTypeRange(result))
                {
                    /* Only deny the operation if arguments and result are not bigInt.
                    If 2 arguments are normal number but the result is bigInt, we still allow the operation in bigInt mode */
                    _logger.LogInformation(LogEvents.BigMultiply, "{firstNum} and {secNum} and their result {result} are not in the big integer range.", firstNum, secNum, result.ToString());
                    return BadRequest(Messages.NotInBigIntRange);
                }

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

                BigInteger result = _calculator.DivideBigNumbers(divd, divs);

                if (!Helper.IsOutOfBuiltInTypeRange(divd) && !Helper.IsOutOfBuiltInTypeRange(divs) && !Helper.IsOutOfBuiltInTypeRange(result))
                {
                    /* Only deny the operation if arguments and result are not bigInt.
                    If 2 arguments are normal number but the result is bigInt, we still allow the operation in bigInt mode */
                    _logger.LogInformation(LogEvents.BigDivide, "{divd} and {divs} and their result {result} are not in the big integer range.", divd, divs, result.ToString());
                    return BadRequest(Messages.NotInBigIntRange);
                }

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