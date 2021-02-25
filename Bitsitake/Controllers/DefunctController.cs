using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bitModel;
using bitDal;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Dapper;
namespace Bitsitake.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DefunctController : ControllerBase
    {
        SqlConnection conn = new SqlConnection("Data Source=YLS;Initial Catalog=Asctions;Integrated Security=True");

        //[EnableCors("any")]  //局部的
        //get api/values/MeName
        //[HttpPost("MeName")]
        //public int GetUsers([FromBody] Users s)
        //{
        //    string sql = $"insert into Users values ('{s.Name}','{s.Age}')";
        //    return conn.Execute(sql);
        //}
    }
}
