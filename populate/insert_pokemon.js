const {PythonShell} = require("python-shell");
const mysql = require('mysql2');
const { options } = require("../src/routes/routes");
require("dotenv").config();

let shell = new PythonShell('populate/unite_pokemon.py');

options.JSON;

const pool = mysql.createConnection({
  host: process.env.SQL_HOST,
  user: 'root',
  password: process.env.SQL_PASSWORD,
  database: process.env.SQL_DB
});

shell.on('message', function(message){

  pool.connect(function(err) {  

    if (err) throw err;   
    sql = "INSERT INTO Pokemon(name, sprite, attacktype, attackstyle, role, complexity) VALUES ROW(?)";
    message = JSON.parse(message);
    values = [message["name"], message["sprite"], message["attack_type"], message["attack_style"], message["role"], message["complexity"]];
    pool.query(sql, [values], function (err, result) {
      if(err)
      {
          console.log("An error occured");
          console.error(err);
          return;
      }
      console.log(result);
    });  
    });  
});

shell.end(function (err,code,signal) {
  if (err) throw err;
  console.log('The exit code was: ' + code);
  console.log('The exit signal was: ' + signal);
  console.log('finished');
});